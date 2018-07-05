using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ELISA.Transaccion.DatosProtocoloTrans;
using ELISA.UI;
using Excel = Microsoft.Office.Interop.Excel;


namespace ELISA.Utils
{
    public class MainUtils
    {
        //Directorio BASE donde se trabajaran los archivos copiados
        public static string BASE_DIR = AppDomain.CurrentDomain.BaseDirectory;
        //Directorio de trabajo donde se extraera el archivo generado por ELISA
        public static string WORK_DIR = @"C:\AscSW26";
        //Nombre del archivo generado por ELISA
        public static string RESP_FN = "response.txt";
        public static string STORAGE_DIR = "Historico";
        public static List<String> rowHeaderNames()
        {
            List<String> abc = new List<string>();
            abc.Add("A");
            abc.Add("B");
            abc.Add("C");
            abc.Add("D");
            abc.Add("E");
            abc.Add("F");
            abc.Add("G");
            abc.Add("H");
            return abc;
        }

        public static List<String> rowHeadersRead()
        {
            List<String> abc = new List<string>();
            abc.Add("1A");
            abc.Add("1B");
            abc.Add("1C");
            abc.Add("1D");
            abc.Add("1E");
            abc.Add("1F");
            abc.Add("1G");
            abc.Add("1H");
            return abc;
        }

        public enum Controles
        {
            ControlesIgM_CPA,
            ControlesIgM_CPB,
            ControlesIgM_C,
            ControlesIgM_CRP,
            ControlesIgM_CRN,
            ControlesEI_CMin,
            ControlesEI_CPlus

        }

        public enum Test
        {
            //IgM
            IgMDengue,
            IgMZika,
            IgMZikaBei,
            ChinkungunyaCDCCNDR,
            ChinkungunyaCNDR,
            //IgG
            SalivaCIET,
            SalivaCIETRep,
            //EI
            ELISAINHMonoChik,
            ELISAINHHiperChik,
            ELISAINHEnsa,
            ELISAINHRM,
            ELISAINHZika,
            //BOB
            ZikaBOB,
            ZikaBOBCohAnual,
            ZikaBOBCohAnualDup,
            ZikaBOBCohAnualSero,
            //1D
            ELISA1DCohAnual,
            ELISA1DCohAnualDup,
            ELISA1DCohAnualChik,
            ELISA1DCohAnualChikDup,
            ELISA1DSeroChik,
            ELISA1DSeroChikDup,
            Zika1DCohAnual,
            Zika1DCohAnualDup,
            //RM
            RMCohAnual,
            RMCohAnualDup,
            ELISARMCohAnualChik,
            ELISARMCohAnualChikDup,
            ELISARMSeroChik,
            ELISARMSeroChikDup,
            ZIKARMCohAnual,
            ZIKARMCohAnualDup,
            //Rotavirus
            Rotavirus
        }

        public static string CopyAndExtract(string NombreProtocolo, int tipoTest)
        {
            string FullFilePath = System.IO.Path.Combine(WORK_DIR, RESP_FN);
            string DestFullFilePath = System.IO.Path.Combine(BASE_DIR, RESP_FN);
            string StoragePath = System.IO.Path.Combine(BASE_DIR, STORAGE_DIR);
            string nombreTest = ((Test) tipoTest).ToString();
            string currentDate = DateTime.Now.ToString("dd-MM-yyyy");

            string StorageFileName = "response_" + currentDate + "_" + NombreProtocolo + "_" + nombreTest + ".txt";
            string StorageFullFilePath = System.IO.Path.Combine(StoragePath, StorageFileName);

            File.SetAttributes(DestFullFilePath, FileAttributes.Normal);
            

            if (!Directory.Exists(StoragePath))
            {
                Directory.CreateDirectory(StoragePath);
            }

            if (System.IO.File.Exists(FullFilePath))
            {
                try
                {
                    File.Copy(FullFilePath, DestFullFilePath, true);
                    File.Copy(DestFullFilePath, StorageFullFilePath, true);
                    File.SetAttributes(StorageFullFilePath, FileAttributes.Normal);
                    string contenido = File.ReadAllText(DestFullFilePath);
                    return contenido;
            }
                catch (System.IO.IOException ex)
            {
                MessageBox.Show("Error al copiar archivos", "Error detectado");
                Log.logError("Error capturado: Trace: " + ex.StackTrace);
                return null;
            }

        }
            else
            {
                MessageBox.Show("response.txt no existe", "Error detectado");
                Log.logError("response.txt no encontrado");
                return null;
            }
        }

        public static void CargarProtocolo(string path, DataGridView dgvProtocolo, TextBox txtPlaca, Principal parent)
        {
            dgvProtocolo.Rows.Clear();
            Excel.Application MyApp= new Excel.Application();
            MyApp.Visible = false;
            Excel.Workbook book = MyApp.Workbooks.Open(path);
            Excel.Worksheet sheet = (Excel.Worksheet) book.Sheets[1];
            string [] values = new string[96];
            int cont = 0;
            for (int i = 6; i <= 13; i++)
            {
                for (int j = 2; j <= 13; j++)
                {
                    values[cont] = ((Excel.Range) sheet.Cells[i, j]).Value;
                    cont++;
                }
            }

            string[,] tabla = new string[8, 12];
            int m = 0;
            for (int j = 0; j < 8; j++)
            {
                for (int k = 0; k < 12; k++)
                {
                    tabla[j, k] = values[m];
                    m++;
                }

            }

            for (int r = 0; r < 8; r++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvProtocolo);

                for (int c = 0; c < 12; c++)
                {
                    if (tabla[r, c] != null)
                    {
                        row.Cells[c].Value = tabla[r, c];
                    }
                    else
                    {
                        row.Cells[c].Value = "SINM1";
                    }
                }

                dgvProtocolo.Rows.Add(row);
            }

            int rowNumber = 0;
            foreach (DataGridViewRow row in dgvProtocolo.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = MainUtils.rowHeaderNames()[rowNumber];
                rowNumber = rowNumber + 1;
            }
            dgvProtocolo.AutoResizeRowHeadersWidth(
                DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            txtPlaca.Text = ((Excel.Range) sheet.Cells[4, 12]).Value +"";
            parent.toggleCombobox(((Excel.Range)sheet.Cells[3, 4]).Value);
            book.Close(false);
            MyApp.Quit();
        }

        public static string contar(string[,] protocolo, string control)
        {
            string Pcontrol = control;
            int c = 1;
            bool exist;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (protocolo[i, j].StartsWith(Pcontrol))
                    {
                        c++;
                    }
                }
            }

            for (int j = 1; j <= c; j++)
            {
                exist = false;
                for (int i = 0; i < 8; i++)
                {
                    for (int k = 0; k < 12; k++)
                    {
                        if (protocolo[i, k] == Pcontrol + j)
                        {
                            exist = true;
                        }
                    }
                }

                if (!exist)
                {
                    c = j;
                }
            }

            return Pcontrol + c;
        }

        public static void InitializeExcelWorkSheet(Principal principal, string testName)
        {
            Excel.Application MyApp = new Excel.Application();
            MyApp.Visible = false;
            object misValue = System.Reflection.Missing.Value;
            Excel.Workbook xlWorkBook = MyApp.Workbooks.Add(misValue);
            Excel.Worksheet xlWorkSheet = (Excel.Worksheet) xlWorkBook.Sheets[1];

            //Titulo
            xlWorkSheet.get_Range("A1").Value = "MINISTERIO DE SALUD NICARAGUA";
            xlWorkSheet.get_Range("A1:M1").Merge();
            xlWorkSheet.get_Range("A1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlWorkSheet.get_Range("A1").Font.Bold = true;
            xlWorkSheet.get_Range("A1").Font.Size = 12;
            xlWorkSheet.get_Range("A1").RowHeight = 21.75;

            //Subtitulo
            xlWorkSheet.get_Range("A2").Value =
                "CENTRO NACIONAL DE DIAGNOSTICO Y REFERENCIA - DEPARTAMENTO DE VIROLOGIA";
            xlWorkSheet.get_Range("A2:M2").Merge();
            xlWorkSheet.get_Range("A2").Font.Size = 12;
            xlWorkSheet.get_Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlWorkSheet.get_Range("A2").Font.Bold = true;
            xlWorkSheet.get_Range("A2").RowHeight = 21.75;

            xlWorkSheet.get_Range("A3").Value = "TEST DE ELISA:";
            xlWorkSheet.get_Range("A3").Font.Bold = true;
            xlWorkSheet.get_Range("A3").RowHeight = 21.75;

            xlWorkSheet.get_Range("A4").Value = "ANALISIS DE:";
            xlWorkSheet.get_Range("A4").Font.Bold = true;
            xlWorkSheet.get_Range("A4").RowHeight = 21.75;

            xlWorkSheet.get_Range("K3").Value = "FECHA:";
            xlWorkSheet.get_Range("K3").Font.Bold = true;
            xlWorkSheet.get_Range("K3").RowHeight = 21.75;

            xlWorkSheet.get_Range("K4").Value = "PLACA:";
            xlWorkSheet.get_Range("K4").Font.Bold = true;
            xlWorkSheet.get_Range("K4").RowHeight = 21.75;

            int[] intArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            Excel.Range rngHeaderNumber = xlWorkSheet.get_Range("B5", "M5");
            rngHeaderNumber.Value = intArray;
            rngHeaderNumber.RowHeight = 21.75;
            rngHeaderNumber.ColumnWidth = 9;

            int index = 0;
            for (int i = 6; i <= 34; i+=4)
            {
                xlWorkSheet.Cells[i, 1] = rowHeaderNames()[index];
                index++;
            }

            xlWorkSheet.get_Range("6:37").RowHeight = 10;

            for (int i = 6; i <= 34; i += 4)
            {
                xlWorkSheet.get_Range("A" + i + ":A" + (i + 3)).Merge();
                xlWorkSheet.get_Range("A" + i + ":A" + (i + 3)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                xlWorkSheet.get_Range("A" + i + ":A" + (i + 3)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            }

            xlWorkSheet.get_Range("A5:M5").Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            xlWorkSheet.get_Range("A5:M5").Font.Bold = true;
            xlWorkSheet.get_Range("A5:A37").Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            xlWorkSheet.get_Range("A5:A37").Font.Bold = true;
            xlWorkSheet.get_Range("A5:A37").Interior.ColorIndex = 15;

            var range = xlWorkSheet.get_Range("B6", "M37");
            foreach (Excel.Range cell in range.Cells)
            {
                cell.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                cell.Font.Size = 8;
                cell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            }

            for (int i = 9; i <= 37; i += 4)
            {
                xlWorkSheet.get_Range("B" + i, "M" + i).Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle =
                    Excel.XlLineStyle.xlContinuous;
            }
            string[,] protocolo = new string[8, 12];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    protocolo[i, j] = principal.dgv_Protocolo.Rows[i].Cells[j].Value.ToString();
                }
            }

            for (int i = 6; i <= 34; i += 4)
            {
                for (int j = 2; j <= 13; j++)
                {
                    int iIndex = ((int)(i / 4)) - 1;
                    int jIndex = (int)(j - 2);
                    xlWorkSheet.Cells[i, j].Value = protocolo[iIndex, jIndex];
                }
            }
            xlWorkSheet.get_Range("L3").Value = "-" + DateTime.Now.ToString("dd/MM/yyyy") + "-";
            xlWorkSheet.get_Range("L4").Value = principal.txt_Placa.TextBox.Text;
            xlWorkSheet.get_Range("C3").Value = testName.Remove(testName.IndexOf("Protocolo "), "Protocolo ".Length);

            for (int i = 7; i <= 35; i+=4)
            {
                for (int j = 2; j <= 13; j++)
                {
                    int iIndex = ((int) (i / 4)) - 1;
                    int jIndex = ((int) (j - 2));
                    xlWorkSheet.Cells[i, j].Value = principal.Absorbancia[iIndex, jIndex];
                }
            }

            xlWorkSheet.get_Range("A38").Value = "LABORATORISTA 1:";
            xlWorkSheet.get_Range("A38").Font.Bold = true;
            xlWorkSheet.get_Range("D38").Value = principal.cmb_Lab1.ComboBox.SelectedValue;
            xlWorkSheet.get_Range("H38").Value = "LABORATORISTA 2:";
            xlWorkSheet.get_Range("H38").Font.Bold = true;
            xlWorkSheet.get_Range("K38").Value = principal.cmb_Lab2.ComboBox.SelectedValue;

            switch ((Test) principal.selectedTest)
            {
                case Test.IgMDengue:
                {
                    for (int i = 8; i <= 36; i += 4)
                    {
                        for (int j = 2; j <= 13; j++)
                        {
                            int iIndex = ((int)(i / 4)) - 2;
                            int jIndex = ((int)(j - 2));
                            xlWorkSheet.Cells[i, j].Value = Single.Parse(principal.Unidades[iIndex, jIndex]).ToString("0.00");
                        }
                    }

                    for (int i = 9; i <= 37; i+=4)
                    {
                        for (int j = 2; j <= 13; j++)
                        {
                            int iIndex = ((int) (i / 4)) - 2;
                            int jIndex = ((int) (j - 2));
                            xlWorkSheet.Cells[i, j].Value = principal.Resultados[iIndex, jIndex];
                        }
                    }


                    xlWorkSheet.get_Range("A40").Value = "Valor de Corte: ";
                    xlWorkSheet.get_Range("A40").Font.Bold = true;
                    xlWorkSheet.get_Range("A41").Value = "Validación: ";
                    xlWorkSheet.get_Range("A41").Font.Bold = true;
                    xlWorkSheet.get_Range("A42").Value = "Valor Control Positivo Bajo: ";
                    xlWorkSheet.get_Range("A42").Font.Bold = true;
                    xlWorkSheet.get_Range("D40").Value = principal.txt_val1.Text;
                    xlWorkSheet.get_Range("D41").Value = principal.txt_val7.Text;
                    xlWorkSheet.get_Range("D42").Value = principal.txt_val5.Text;

                    datosprotocoloigm datos = DatosProtocoloIgM.TraerDatosProtocoloIgM();

                    xlWorkSheet.get_Range("F40").Value = "Codigo de Controles: ";
                    xlWorkSheet.get_Range("H40").Value = "CPA: ";
                    xlWorkSheet.get_Range("H40").Font.Bold = true;
                    xlWorkSheet.get_Range("H41").Value = "CPB: ";
                    xlWorkSheet.get_Range("H41").Font.Bold = true;
                    xlWorkSheet.get_Range("H42").Value = "CN: ";
                    xlWorkSheet.get_Range("H42").Font.Bold = true;

                    xlWorkSheet.get_Range("I40").Value = datos.ControlPosA;
                    xlWorkSheet.get_Range("I41").Value = datos.ControlPosB;
                    xlWorkSheet.get_Range("I42").Value = datos.ControlNeg;

                    if (principal.cb.Checked)
                    {
                        xlWorkSheet.get_Range("J40").Value = "Controles de Radio: ";
                        xlWorkSheet.get_Range("L40").Value = "CRP: ";
                        xlWorkSheet.get_Range("L41").Value = "CRN: ";
                        xlWorkSheet.get_Range("L40").Font.Bold = true;
                        xlWorkSheet.get_Range("L41").Font.Bold = true;
                        xlWorkSheet.get_Range("M40").Value = datos.ControlRadPos;
                        xlWorkSheet.get_Range("M41").Value = datos.ControlRadNeg;
                    }

                    xlWorkSheet.get_Range("A44").Value = "ANTI-GLOBULINA";
                    xlWorkSheet.get_Range("C44").Value = datos.LoteIgM;

                    xlWorkSheet.get_Range("A44:M50").Font.Size = 8;
                    xlWorkSheet.get_Range("A44:A48").Font.Bold = true;
                    xlWorkSheet.get_Range("E44:E48").Font.Bold = true;
                    xlWorkSheet.get_Range("H44:H48").Font.Bold = true;
                    xlWorkSheet.get_Range("K44:K48").Font.Bold = true;

                    xlWorkSheet.get_Range("A45").Value = "ESTUDIO";
                    xlWorkSheet.get_Range("C45").Value = datos.TipoEstudio;
                    xlWorkSheet.get_Range("A46").Value = "COATTING";
                    xlWorkSheet.get_Range("C46").Value = datos.Coatting;
                    xlWorkSheet.get_Range("A47").Value = "PB";
                    xlWorkSheet.get_Range("C47").Value = datos.PB;
                    xlWorkSheet.get_Range("A48").Value = "H2O";
                    xlWorkSheet.get_Range("C48").Value = datos.ProcH2O;

                    if (!xlWorkSheet.get_Range("A44").Value.Equals("GOAT ANTI-HUMAN IgM"))
                    {
                        xlWorkSheet.get_Range("E44").Value = "GAMMAGLOBULINA";
                        xlWorkSheet.get_Range("E45").Value = "LOTE";
                        xlWorkSheet.get_Range("F45").Value = datos.GGLOB;
                        xlWorkSheet.get_Range("E46").Value = "FECHA";
                        xlWorkSheet.get_Range("F46").Value = "-" + datos.fechafijGG.Value.ToString("dd/MM/yyyy") + "-";
                        xlWorkSheet.get_Range("E47").Value = "VOLUMEN";
                        xlWorkSheet.get_Range("F47").Value = datos.VolUsado;

                        }
                    else
                    {
                        xlWorkSheet.get_Range("E44").Value = "Fijacion Igm";
                        xlWorkSheet.get_Range("E46").Value = "FECHA";
                        xlWorkSheet.get_Range("F46").Value = "-" + datos.fechafijGG.Value.ToString("dd/MM/yyyy") + "-";
                        xlWorkSheet.get_Range("E47").Value = "VOLUMEN";
                        xlWorkSheet.get_Range("F47").Value = datos.VolUsado;
                    }

                    xlWorkSheet.get_Range("E48").Value = "";
                    xlWorkSheet.get_Range("H44").Value = "BLOQUEO";
                    xlWorkSheet.get_Range("H45").Value = "TIPO";
                    xlWorkSheet.get_Range("I45").Value = datos.TB;
                    xlWorkSheet.get_Range("H46").Value = "FECHA";
                    xlWorkSheet.get_Range("I46").Value = "-" + datos.FB.Value.ToString("dd/MM/yyyy") + "-";
                    xlWorkSheet.get_Range("H47").Value = "TEMP";
                    xlWorkSheet.get_Range("I47").Value = datos.TMPB;
                    xlWorkSheet.get_Range("H48").Value = "TIEMPO";
                    xlWorkSheet.get_Range("I48").Value = "-" + datos.TIMEB + "-";
                    xlWorkSheet.get_Range("K44").Value = "ANTIGENO";
                    xlWorkSheet.get_Range("L44").Value = datos.LoteAntigeno;
                    xlWorkSheet.get_Range("K45").Value = "CONJUGA";
                    xlWorkSheet.get_Range("L45").Value = datos.Conjugado;
                    xlWorkSheet.get_Range("K46").Value = "SHN";
                    xlWorkSheet.get_Range("L46").Value = datos.SHN;
                    xlWorkSheet.get_Range("K47").Value = "SUBSTRAT";
                    xlWorkSheet.get_Range("L47").Value = datos.Substrato;
                    xlWorkSheet.get_Range("K48").Value = "Tiempo Subs";
                    xlWorkSheet.get_Range("L48").Value = datos.TSubstrato;
                    xlWorkSheet.get_Range("K49").Value = "STOP";
                    xlWorkSheet.get_Range("L49").Value = datos.STOP;
                        

                        string nombreArchivo = BASE_DIR  + testName + " " + DateTime.Now.ToString("dd-MM-yyyy") +
                                           " " + principal.txt_Placa.TextBox.Text + ".xls";
                        xlWorkBook.SaveAs(nombreArchivo);
                    xlWorkBook.Close(true);
                    MyApp.Quit();


                }
                    break;
            }
        }
    }
}
