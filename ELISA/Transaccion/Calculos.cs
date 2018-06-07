using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Transaccion.DatosProtocoloTrans;
using ELISA.UI;
using ELISA.Utils;

namespace ELISA.Transaccion
{
    class Calculos
    {
        

        public void CalcularIgM(Principal parent)
        {
            DataGridView tablaLectura = parent.dgv_Lectura;
            DataGridView tablaProtocolo = parent.dgv_Protocolo;
            String[,] lectura = new string[8, 12];
            String[,] protocolo = new string[8, 12];

            //Recolectar los datos de las tablas a una matriz

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    lectura[i, j] = tablaLectura.Rows[i].Cells[j].Value.ToString();
                    protocolo[i, j] = tablaProtocolo.Rows[i].Cells[j].Value.ToString();
                }
            }

            int cont;
            Single ac, cc;
            //En este caso solo se calcula un solo Test

            try
            {
                //Calculo de los Controles Positivos Altos
                ac = 0;
                cont = 0;
                cc = -120;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        if (protocolo[i, j].StartsWith("CA+"))
                        {
                            if (!lectura[i, j].EndsWith(Convert.ToString((char)8203)))
                            {
                                cc = Single.Parse(lectura[i, j]);
                                ac += Single.Parse(lectura[i, j]);
                                cont++;
                            }
                        }
                    }
                }

                if (cont < 1)
                {
                    MessageBox.Show("No existe control positivo alto", "Verifique su protocolo de trabajo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Deshabilitar boton Guardar btn_Save
                    //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                    parent.cpA = 0;
                }
                else
                {
                    parent.cpA = ac / cont;
                    parent.txt_val4.Text = parent.cpA.ToString("0.000");
                }

                //Calculo de los Controles Positivos Bajos

                ac = 0;
                cont = 0;
                cc = -120;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        if (protocolo[i, j].StartsWith("CB+"))
                        {
                            if (!lectura[i, j].EndsWith(Convert.ToString((char)8203)))
                            {
                                cc = Single.Parse(lectura[i, j]);
                                ac += Single.Parse(lectura[i, j]);
                                cont++;
                            }
                        }
                    }
                }

                if (cont < 1)
                {
                    MessageBox.Show("No existe control positivo bajo", "Verifique su protocolo de trabajo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Deshabilitar boton Guardar btn_Save
                    //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                    parent.cpB = 0;
                }
                else
                {
                    parent.cpB = ac / cont;
                    parent.txt_val5.Text = parent.cpB.ToString("0.000");
                }

                //Calculo de los Controles Negativos

                ac = 0;
                cont = 0;
                cc = -120;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        if (protocolo[i, j].StartsWith("C-"))
                        {
                            if (!lectura[i, j].EndsWith(Convert.ToString((char)8203)))
                            {
                                cc = Single.Parse(lectura[i, j]);
                                ac += Single.Parse(lectura[i, j]);
                                cont++;
                            }
                        }
                    }
                }

                if (cont < 2)
                {
                    MessageBox.Show("Tiene que haber mas de un control negativo", "Verifique su protocolo de trabajo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Deshabilitar boton Guardar btn_Save
                    //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                }
                else
                {
                    if (cont > 0)
                    {
                        parent.cn = ac / cont;
                    }
                    else
                        parent.cn = 0;
                }

                parent.txt_val1.Text = (parent.cn * 2).ToString("0.000");
                parent.txt_val6.Text = parent.cn.ToString("0.000");

                //Calculo de los Controles Positivos de Radio

                ac = 0;
                cont = 0;
                cc = -120;
                datosprotocoloigm datos = DatosProtocoloIgM.TraerDatosProtocoloIgM();
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        if (protocolo[i, j].StartsWith("CR+"))
                        {
                            if (!lectura[i, j].EndsWith(Convert.ToString((char)8203)))
                            {
                                cc = Single.Parse(lectura[i, j]);
                                ac += Single.Parse(lectura[i, j]);
                                cont++;

                                if (cc != -120)
                                {

                                    if (!(cc >= datos.ControlPosRadLI && cc <= datos.ControlPosRadLS))
                                    {
                                        MessageBox.Show(protocolo[i, j] + " No cumple Criterios", "Verifique sus datos",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //Deshabilitar btnSave
                                        //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                if (cont < 2 && parent.cb.Checked)
                {
                    MessageBox.Show("Tiene que haber mas de un control de radio positivo",
                        "Verifique su protocolo de trabajo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Deshabilitar btnSave
                    //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                }
                else
                {
                    if (cont == 0)
                    {
                        parent.cpR = 0;
                    }
                    else
                    {
                        parent.cpR = ac / cont;
                    }
                }

                parent.txt_val3.Text = parent.cpR.ToString("0.000");

                //Calculo de los Controles Negativos de Radio

                ac = 0;
                cont = 0;
                cc = -120;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        if (protocolo[i, j].StartsWith("CR-"))
                        {
                            if (!lectura[i, j].EndsWith(Convert.ToString((char)8203)))
                            {
                                cc = Single.Parse(lectura[i, j]);
                                ac += Single.Parse(lectura[i, j]);
                                cont++;

                                if (cc != -120)
                                {
                                    if (!(cc >= datos.ControlNegRadLI && cc <= datos.ControlNegRadLS))
                                    {
                                        MessageBox.Show(protocolo[i, j] + " No cumple Criterios", "Verifique sus datos",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //Deshabilitar btnSave
                                        //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                if (cont < 2 && parent.cb.Checked)
                {
                    MessageBox.Show("Tiene que haber mas de un control de radio positivo",
                        "Verifique su protocolo de trabajo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Deshabilitar btnSave
                    //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                }
                else
                {
                    if (cont == 0)
                    {
                        parent.cnR = 0;
                    }
                    else
                    {
                        parent.cnR = ac / cont;
                    }
                }

                parent.txt_val2.Text = parent.cnR.ToString("0.000");

                if (!parent.cb.Checked)
                {
                    parent.txt_val2.Text = "NA";
                    parent.txt_val3.Text = "NA";
                }

                Single val = (parent.cpA / parent.cn);
                parent.txt_val7.Text = val.ToString("0.000");

                if (val < 5)
                {
                    MessageBox.Show(" - No Cumple criterio de Validación",
                        "Verifique sus datos", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    //Deshabilitar btnSave
                    //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                }

                if (parent.cpB < (parent.cn * 2))
                {
                    MessageBox.Show("El valor de corte es mayor que la media de los controles positivos bajos",
                        "Verifique sus datos - No Cumple criterio de Validación", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    //Deshabilitar btnSave
                    //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error detectado: " + ex.StackTrace);
            }

            //Habilitar Boton Save
            //Deshabilitar placa invalida

        }

    }
}
