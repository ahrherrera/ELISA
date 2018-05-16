using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        }

        public static int contarCPA(string [,] protocolo)
        {
            //contarCPA
            int c = 1;
            bool exist;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (protocolo[i, j].StartsWith("CA+"))
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
                        if (protocolo[i, k] == "CA+" + j)
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

            return c;
        }

        public static int contarCPB(string[,] protocolo)
        {
            int c = 1;
            bool exist;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (protocolo[i, j].StartsWith("CB+"))
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
                        if (protocolo[i, k] == "CB+" + j)
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

            return c;
        }
    }
}
