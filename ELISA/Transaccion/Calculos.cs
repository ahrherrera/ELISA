using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Pkcs;
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

            parent.btn_Save.Enabled = true;

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
                    parent.btn_Save.Enabled = false;
                    //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                    parent.cpA = 0;
                }
                else
                {
                    parent.cpA = ac / cont;
                }

                parent.txt_val4.Text = parent.cpA.ToString("0.000");

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
                    parent.btn_Save.Enabled = false;
                    //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
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
                    parent.btn_Save.Enabled = false;
                    //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
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
                                        parent.btn_Save.Enabled = false;
                                        //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                                        parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                                        return;
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
                    parent.btn_Save.Enabled = false;
                    //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
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
                                        parent.btn_Save.Enabled = false;
                                        //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                                        parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
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
                    MessageBox.Show("No Cumple criterio de Validación",
                        "Verifique sus datos", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    //Deshabilitar btnSave
                    parent.btn_Save.Enabled = false;
                    //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                }

                if (parent.cpB < (parent.cn * 2))
                {
                    MessageBox.Show("El valor de corte es mayor que la media de los controles positivos bajos",
                        "Verifique sus datos - No Cumple criterio de Validación", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    //Deshabilitar btnSave
                    parent.btn_Save.Enabled = false;
                    //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error detectado: " + ex.StackTrace);
            }

            //Habilitar btnSave
            parent.btn_Save.Enabled = true;
            //Deshabilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
            parent.guardarPlacaInválidaToolStripMenuItem.Enabled = false;

        }

        public void CalcularIgmZika(Principal parent)
        {
            DataGridView tablaLectura = parent.dgv_Lectura;
            DataGridView tablaProtocolo = parent.dgv_Protocolo;
            String[,] lectura = new string[8, 12];
            String[,] protocolo = new string[8, 12];

            parent.btn_Save.Enabled = true;

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
            Single fact1, fact2;

            try
            {
                ///// CALCULO DE LOS CONTROLES POSITIVOS

                ac = 0;
                cont = 0;
                cc = -120;

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        if (protocolo[i, j].StartsWith("C+"))
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
                    MessageBox.Show("No existe control positivo", "Verifique su protocolo de trabajo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Deshabilitar boton Guardar btn_Save
                    parent.btn_Save.Enabled = false;
                    //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                    parent.cpA = 0;
                }
                else
                {
                    parent.cpA = ac / cont;
                }

                parent.txt_val5.Text = parent.cpA.ToString("0.000");

                datosprotocoloigmzika datos = DatosProtocoloIgMZika.TraerDatosprotocoloigmzika();

                ///// CALCULO DE LOS CONTROLES NEGATIVOS
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

                                //Validacion del rango de los controles
                                if (cc != -120)
                                {
                                    if (cc >= datos.ControlNegLI && cc <= datos.ControlNegLS)
                                    {
                                        MessageBox.Show(protocolo[i, j] + " No cumple Criterios", "Verifique sus datos",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //Deshabilitar btnSave
                                        parent.btn_Save.Enabled = false;
                                        //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                                        parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                if (cont < 2)
                {
                    MessageBox.Show("Tiene que haber mas de un control negativo", "Verifique sus datos",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parent.btn_Save.Enabled = true;
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                }
                else
                {
                    parent.cn = cont > 0 ? ac / cont : 0;
                }

                fact1 = datos.Factor;
                fact2 = datos.Factor2;
                parent.txt_val1.Text = ((parent.cn * fact1).ToString("0.000"));
                parent.txt_val2.Text = ((parent.cn * fact2).ToString("0.000"));
                parent.txt_val6.Text = parent.cn.ToString("0.000");

                //// CALCULO DE LOS CONTROLES POSITIVOS DE RADIO

                ac = 0;
                cont = 0;

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
                                    if (cc >= datos.ControlPosRadLI && cc <= datos.ControlPosRadLS)
                                    {
                                        MessageBox.Show(protocolo[i, j] + " No cumple Criterios", "Verifique sus datos",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //Deshabilitar btnSave
                                        parent.btn_Save.Enabled = false;
                                        //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                                        parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
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
                    parent.btn_Save.Enabled = false;
                    //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                }
                else
                {
                    parent.cpR = cont == 0 ? 0 : ac / cont;
                }

                parent.txt_val3.Text = parent.cpR.ToString("0.000");

                ///// CALCULO DE LOS CONTROLES NEGATIVOS DE RADIO
                ac = 0;
                cont = 0;
                cc = -120;
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
                                    if (cc >= datos.ControlNegRadLI && cc <= datos.ControlNegRadLS)
                                    {
                                        MessageBox.Show(protocolo[i, j] + " No cumple Criterios", "Verifique sus datos",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //Deshabilitar btnSave
                                        parent.btn_Save.Enabled = false;
                                        //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                                        parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                if (cont < 2 && parent.cb.Checked)
                {
                    MessageBox.Show("Tiene que haber mas de un control de radio negativo",
                        "Verifique su protocolo de trabajo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Deshabilitar btnSave
                    parent.btn_Save.Enabled = false;
                    //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                }
                else
                {
                    parent.cnR = cont == 0 ? 0 : ac / cont;
                }

                parent.txt_val4.Text = parent.cnR.ToString("0.000");

                if (!parent.cb.Checked)
                {
                    parent.txt_val3.Text = "NA";
                    parent.txt_val4.Text = "NA";
                }

                parent.txt_val7.Text = (parent.cpA / parent.cn).ToString("0.000");

                if (Single.Parse(parent.txt_val7.Text) < 5)
                {
                    MessageBox.Show("No cumple criterio de validación", "Verifique sus datos", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    parent.btn_Save.Enabled = false;
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                    return;
                }

                if (Single.Parse(parent.txt_val5.Text) < Single.Parse(parent.txt_val1.Text))
                {
                    MessageBox.Show("No cumple criterio de validación.\n El valor de corte es " +
                                    "mayor que la media de los controles positivos",
                        "Verifique sus datos", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    parent.btn_Save.Enabled = false;
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                    return;
                }

                //Habilitar btnSave
                parent.btn_Save.Enabled = true;
                //Deshabilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                parent.guardarPlacaInválidaToolStripMenuItem.Enabled = false;
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error detectado: " + ex.StackTrace);
            }

        }

        public void CalcularIgG(Principal parent)
        {
            DataGridView tablaLectura = parent.dgv_Lectura;
            DataGridView tablaProtocolo = parent.dgv_Protocolo;
            String[,] lectura = new string[8, 12];
            String[,] protocolo = new string[8, 12];

            parent.btn_Save.Enabled = true;

            //Recolectar los datos de las tablas a una matriz

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    lectura[i, j] = tablaLectura.Rows[i].Cells[j].Value.ToString();
                    protocolo[i, j] = tablaProtocolo.Rows[i].Cells[j].Value.ToString();
                }
            }

            //Calculo Controles Positivos
            int cont;
            Single ac, cc, columpio;
            Single[] m3men = new Single[] { 3, 3, 3 };
            datosprotocoloigg datos = DatosProtocoloIgG.TraerDatosprotocoloIgG();
            try
            {
                ac = 0;
                cont = 0;

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        cc = -120;
                        if (protocolo[i, j].StartsWith("C+"))
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
                    MessageBox.Show("No Cumple criterios",
                        "Verifique sus datos", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    //Deshabilitar btnSave
                    parent.btn_Save.Enabled = false;
                    return;
                }
                else
                {
                    parent.MxCP = ac / cont;
                }

                //Calculo Controles Negativos
                ac = 0;
                cont = 0;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        cc = -120;
                        if (protocolo[i, j].StartsWith("C-"))
                        {
                            if (!lectura[i, j].EndsWith(Convert.ToString((char)8203)))
                            {
                                cc = Single.Parse(lectura[i, j]);
                                ac += Single.Parse(lectura[i, j]);
                                cont++;

                                if (!(cc >= datos.ControlNegLI && cc <= datos.ControlNegLS))
                                {
                                    MessageBox.Show(protocolo[i, j] + " No cumple Criterios", "Verifique sus datos",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //Deshabilitar btnSave
                                    parent.btn_Save.Enabled = false;
                                    //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                                    return;
                                }
                            }
                        }

                    }
                }
                if (cont < 2)
                {
                    MessageBox.Show("No Cumple criterios",
                        "Verifique sus datos", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    //Deshabilitar btnSave
                    parent.btn_Save.Enabled = false;
                    return;
                }
                else
                {
                    parent.MxCN = ac / cont;
                }

                //Calculo Controles Negativos de Saliva
                ac = 0;
                cont = 0;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        cc = -120;
                        if (protocolo[i, j].StartsWith("S-"))
                        {
                            if (!lectura[i, j].EndsWith(Convert.ToString((char)8203)))
                            {
                                cc = Single.Parse(lectura[i, j]);
                                ac += Single.Parse(lectura[i, j]);
                                cont++;

                                if (!(cc >= datos.ControlNegSalLI && cc <= datos.ControlNegSalLS))
                                {
                                    MessageBox.Show(protocolo[i, j] + " No cumple Criterios", "Verifique sus datos",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //Deshabilitar btnSave
                                    parent.btn_Save.Enabled = false;
                                    //Habilitar Guardar placa Invalida guardarPlacaInválidaToolStripMenuItem
                                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                                    return;
                                }
                            }
                        }

                    }
                }
                if (cont < 2)
                {
                    MessageBox.Show("No Cumple criterios",
                        "Verifique sus datos", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    //Deshabilitar btnSave
                    parent.btn_Save.Enabled = false;
                    return;
                }
                else
                {
                    parent.MxCNS = ac / cont;
                }

                parent.txt_val2.Text = parent.MxCP.ToString("0.000");
                parent.txt_val1.Text = parent.MxCNS.ToString("0.000");
                parent.txt_val3.Text = parent.MxCN.ToString("0.000");

                //3 OD menores

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        columpio = 3;
                        if (protocolo[i, j].StartsWith("SINM"))
                        {
                            if (!lectura[i, j].EndsWith(Convert.ToString((char)8203)))
                            {
                                columpio = Single.Parse(lectura[i, j]);
                                if (columpio < m3men[0])
                                {
                                    m3men[2] = m3men[1];
                                    m3men[1] = m3men[0];
                                    m3men[0] = columpio;
                                }
                                else if (columpio < m3men[1])
                                {
                                    m3men[2] = m3men[1];
                                    m3men[1] = columpio;
                                }
                                else if (columpio < m3men[2])
                                {
                                    m3men[2] = columpio;
                                }
                            }
                        }

                    }
                }

                parent.med3men = (m3men[0] + m3men[1] + m3men[2]) / 3;
                parent.txt_val4.Text = parent.med3men.ToString("0.000");
                parent.btn_Save.Enabled = true;
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error detectado: " + ex.StackTrace);
            }
        }

        public void CalcularIgMZikaBei(Principal parent)
        {
            DataGridView tablaLectura = parent.dgv_Lectura;
            DataGridView tablaProtocolo = parent.dgv_Protocolo;
            String[,] lectura = new string[8, 12];
            String[,] protocolo = new string[8, 12];

            parent.btn_Save.Enabled = true;

            //Recolectar los datos de las tablas a una matriz

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    lectura[i, j] = tablaLectura.Rows[i].Cells[j].Value.ToString();
                    protocolo[i, j] = tablaProtocolo.Rows[i].Cells[j].Value.ToString();
                }
            }

            //Calcular Controles Positivos / Densidad optica de los controles positivos
            int cont;
            Single ac, odcontrolv, odcontroln;
            try
            {
                ac = 0;
                cont = 0;

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        if (protocolo[i, j].StartsWith("C+v"))
                        {
                            if (!lectura[i, j].EndsWith(Convert.ToString((char)8203)))
                            {
                                if (i != 7 && j != 11)
                                {
                                    odcontrolv = Single.Parse(lectura[i, j]);
                                    odcontroln = Single.Parse(lectura[i, j + 1]);
                                }
                                else
                                {
                                    odcontrolv = Single.Parse(lectura[i, j]);
                                    odcontroln = 0;
                                }
                                cont++;
                                if (parent.txt_val2.Text.Equals(""))
                                {
                                    parent.txt_val2.Text = (odcontrolv - odcontroln).ToString("0.000");
                                }
                                else
                                {
                                    parent.txt_val2.Text += " , " + (odcontrolv - odcontroln).ToString("0.000");
                                }

                                if ((odcontrolv - odcontroln) <= 0.8)
                                {
                                    MessageBox.Show("Control positivo no cumple criterios de validacion",
                                        "Verifique su protocolo de trabajo", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                                    parent.btn_Save.Enabled = false;
                                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                                    return;
                                }
                            }


                        }

                    }
                }

                if (cont < 1)
                {
                    MessageBox.Show("No existe control positivo",
                        "Verifique su protocolo de trabajo", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    parent.btn_Save.Enabled = false;
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                    return;
                }

                //Calculo controles negativos / Densidad optica de los controles negativos

                cont = 0;

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        if (protocolo[i, j].StartsWith("C-v"))
                        {
                            if (!lectura[i, j].EndsWith(Convert.ToString((char)8203)))
                            {
                                if (i != 7 && j != 11)
                                {
                                    odcontrolv = Single.Parse(lectura[i, j]);
                                    odcontroln = Single.Parse(lectura[i, j + 1]);
                                }
                                else
                                {
                                    odcontrolv = Single.Parse(lectura[i, j]);
                                    odcontroln = 0;
                                }

                                cont++;

                                if (parent.txt_val1.Text.Equals(""))
                                {
                                    parent.txt_val1.Text = (odcontrolv - odcontroln).ToString("0.000");
                                }
                                else
                                {
                                    parent.txt_val1.Text += " , " + (odcontrolv - odcontroln).ToString("0.000");
                                }

                                if ((odcontrolv - odcontroln) >= 0.2)
                                {
                                    MessageBox.Show("Control negativo no cumple criterios de validacion",
                                        "Verifique su protocolo de trabajo", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                                    parent.btn_Save.Enabled = false;
                                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                                    return;
                                }
                            }
                        }

                    }
                }

                if (cont < 1)
                {
                    MessageBox.Show("No existe control negativo",
                        "Verifique su protocolo de trabajo", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    parent.btn_Save.Enabled = false;
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                    return;
                }

                parent.btn_Save.Enabled = true;
                parent.guardarPlacaInválidaToolStripMenuItem.Enabled = false;

            }
            catch (IOException ex)
            {
                MessageBox.Show("Error detectado: " + ex.StackTrace);
            }
        }

        //CalcularEINHNew
        public void CalcularEINH(Principal parent)
        {
            DataGridView tablaLectura = parent.dgv_Lectura;
            DataGridView tablaProtocolo = parent.dgv_Protocolo;
            String[,] lectura = new string[8, 12];
            String[,] protocolo = new string[8, 12];

            parent.btn_Save.Enabled = true;

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
            Single ac;
            Single cc = 0;
            List<Single> cpE = new List<Single>();
            List<String> cpC = new List<String>();
            int cps, e, a;
            double w;
            long Y = 0;
            String Tit = "";
            Boolean flag50;
            datosprotocoloei datosEI = null;
            datosprotocoloeizika datosEIZika = null;
            try
            {
                ac = 0;
                cont = 0;
                if (parent.selectedTest == 30 || parent.selectedTest == 31)
                {
                    datosEIZika = DatosProtocoloEI.TraerDatosProtocoloEIZika();
                }
                else
                {
                    datosEI = DatosProtocoloEI.TraerDatosProtocoloEI();
                }

                // Calculo de Controles Negativos
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
                            if (cc != -120)
                            {
                                if (cc != -120)
                                {
                                    if (parent.selectedTest == 30 || parent.selectedTest == 31)
                                    {
                                        if (!(cc >= datosEIZika.ControlNegLI && cc <= datosEIZika.ControlNegLS))
                                        {
                                            MessageBox.Show(protocolo[i, j] + " No cumple Criterios",
                                                "Verifique sus datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            parent.btn_Save.Enabled = false;
                                            parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (!(cc >= datosEI.ControlNegLI && cc <= datosEI.ControlNegLS))
                                        {
                                            MessageBox.Show(protocolo[i, j] + " No cumple Criterios",
                                                "Verifique sus datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            parent.btn_Save.Enabled = false;
                                            parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                                            return;
                                        }
                                    }
                                }
                            }
                        }

                    }
                }

                if (cont < 2)
                {
                    MessageBox.Show("No cumple Criterios en los controles negativos",
                        "Verifique su protocolo de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parent.btn_Save.Enabled = false;
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                    return;
                }
                else
                {
                    parent.MxCNEI = ac / cont;
                    parent.txt_val3.Text = parent.MxCNEI.ToString("0.000");
                }

                parent.txt_val1.Text = (parent.MxCNEI / 2).ToString("0.000");

                e = 0;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        if (protocolo[i, j].StartsWith("CPd"))
                        {
                            cpC.Add(protocolo[i, j].Substring(protocolo[i, j].Length - 2, 2));
                            Single lect = Single.Parse(lectura[i, j]);
                            Single resultado = (1 - (lect / parent.MxCNEI)) * 100;
                            cpE.Add(Convert.ToSingle(resultado.ToString("0.000")));
                            e++;
                        }
                    }
                }

                flag50 = false;

                for (int i = 0; i <= e - 1; i++)
                {
                    if (cpE[i] < 50)
                    {
                        flag50 = true;
                        switch (i)
                        {
                            case 0:
                                {
                                    switch (cpC[i])
                                    {
                                        case "d1":
                                            {
                                                Tit = "<10";
                                            }
                                            break;
                                        case "d2":
                                            {
                                                Tit = "<100";
                                            }
                                            break;

                                        case "d3":
                                            {
                                                Tit = "<1000";
                                            }
                                            break;
                                        case "d6":
                                            {
                                                Tit = "<20";
                                            }
                                            break;
                                        case "d7":
                                            {
                                                Tit = "<200";
                                            }
                                            break;
                                        case "d8":
                                            {
                                                Tit = "<2000";
                                            }
                                            break;
                                    }

                                    break;
                                }
                            case 1:
                                {
                                    switch (cpC[i])
                                    {
                                        case "d2":
                                            {
                                                if (i==0)
                                                {
                                                    w = ((0 - 50) / (0 - cpE[i])) + Math.Log10(10);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                                else
                                                {
                                                    w = ((cpE[i-1] - 50) / (cpE[i-1] - cpE[i])) + Math.Log10(10);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                            }
                                            break;
                                        case "d3":
                                        {
                                            if (i == 0)
                                            {
                                                w = ((0 - 50) / (0 - cpE[i])) + Math.Log10(100);
                                                Y = Convert.ToInt64(Math.Pow(10, w));
                                            }
                                            else
                                            {
                                                w = ((cpE[i - 1] - 50) / (cpE[i - 1] - cpE[i])) + Math.Log10(100);
                                                Y = Convert.ToInt64(Math.Pow(10, w));
                                            }
                                        }
                                            break;
                                        case "d4":
                                        {
                                            if (i == 0)
                                            {
                                                w = ((0 - 50) / (0 - cpE[i])) + Math.Log10(1000);
                                                Y = Convert.ToInt64(Math.Pow(10, w));
                                            }
                                            else
                                            {
                                                w = ((cpE[i - 1] - 50) / (cpE[i - 1] - cpE[i])) + Math.Log10(1000);
                                                Y = Convert.ToInt64(Math.Pow(10, w));
                                            }
                                        }
                                            break;
                                        case "d7":
                                        {
                                            if (i == 0)
                                            {
                                                w = ((0 - 50) / (0 - cpE[i])) + Math.Log10(20);
                                                Y = Convert.ToInt64(Math.Pow(10, w));
                                            }
                                            else
                                            {
                                                w = ((cpE[i - 1] - 50) / (cpE[i - 1] - cpE[i])) + Math.Log10(20);
                                                Y = Convert.ToInt64(Math.Pow(10, w));
                                            }
                                        }
                                            break;
                                        case "d8":
                                        {
                                            if (i == 0)
                                            {
                                                w = ((0 - 50) / (0 - cpE[i])) + Math.Log10(200);
                                                Y = Convert.ToInt64(Math.Pow(10, w));
                                            }
                                            else
                                            {
                                                w = ((cpE[i - 1] - 50) / (cpE[i - 1] - cpE[i])) + Math.Log10(200);
                                                Y = Convert.ToInt64(Math.Pow(10, w));
                                            }
                                        }
                                            break;
                                        case "d9":
                                        {
                                            if (i == 0)
                                            {
                                                w = ((0 - 50) / (0 - cpE[i])) + Math.Log10(2000);
                                                Y = Convert.ToInt64(Math.Pow(10, w));
                                            }
                                            else
                                            {
                                                w = ((cpE[i - 1] - 50) / (cpE[i - 1] - cpE[i])) + Math.Log10(2000);
                                                Y = Convert.ToInt64(Math.Pow(10, w));
                                            }
                                        }
                                            
                                            break;
                                    }
                                    Tit = Convert.ToString(Y);
                                    break;
                                }
                            case 2:
                            {
                                    switch (cpC[i])
                                    {
                                        case "d3":
                                            {
                                                if (i == 0)
                                                {
                                                    w = ((0 - 50) / (0 - cpE[i])) + Math.Log10(100);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                                else
                                                {
                                                    w = ((cpE[i - 1] - 50) / (cpE[i - 1] - cpE[i])) + Math.Log10(100);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                            }
                                            break;
                                        case "d4":
                                            {
                                                if (i == 0)
                                                {
                                                    w = ((0 - 50) / (0 - cpE[i])) + Math.Log10(1000);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                                else
                                                {
                                                    w = ((cpE[i - 1] - 50) / (cpE[i - 1] - cpE[i])) + Math.Log10(1000);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                            }
                                            break;
                                        case "d5":
                                            {
                                                if (i == 0)
                                                {
                                                    w = ((0 - 50) / (0 - cpE[i])) + Math.Log10(10000);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                                else
                                                {
                                                    w = ((cpE[i - 1] - 50) / (cpE[i - 1] - cpE[i])) + Math.Log10(10000);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                            }
                                            break;
                                        case "d8":
                                            {
                                                if (i == 0)
                                                {
                                                    w = ((0 - 50) / (0 - cpE[i])) + Math.Log10(200);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                                else
                                                {
                                                    w = ((cpE[i - 1] - 50) / (cpE[i - 1] - cpE[i])) + Math.Log10(200);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                            }
                                            break;
                                        case "d9":
                                            {
                                                if (i == 0)
                                                {
                                                    w = ((0 - 50) / (0 - cpE[i])) + Math.Log10(2000);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                                else
                                                {
                                                    w = ((cpE[i - 1] - 50) / (cpE[i - 1] - cpE[i])) + Math.Log10(2000);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                            }
                                            break;
                                        case "10":
                                            {
                                                if (i == 0)
                                                {
                                                    w = ((0 - 50) / (0 - cpE[i])) + Math.Log10(20000);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                                else
                                                {
                                                    w = ((cpE[i - 1] - 50) / (cpE[i - 1] - cpE[i])) + Math.Log10(20000);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                            }

                                            break;
                                    }
                                    Tit = Convert.ToString(Y);
                                    break;
                            }
                            case 3:
                            {
                                    switch (cpC[i])
                                    {
                                        case "d4":
                                            {
                                                if (i == 0)
                                                {
                                                    w = ((0 - 50) / (0 - cpE[i])) + Math.Log10(1000);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                                else
                                                {
                                                    w = ((cpE[i - 1] - 50) / (cpE[i - 1] - cpE[i])) + Math.Log10(1000);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                            }
                                            break;
                                        case "d5":
                                            {
                                                if (i == 0)
                                                {
                                                    w = ((0 - 50) / (0 - cpE[i])) + Math.Log10(10000);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                                else
                                                {
                                                    w = ((cpE[i - 1] - 50) / (cpE[i - 1] - cpE[i])) + Math.Log10(10000);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                            }
                                            break;
                                        case "d9":
                                            {
                                                if (i == 0)
                                                {
                                                    w = ((0 - 50) / (0 - cpE[i])) + Math.Log10(2000);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                                else
                                                {
                                                    w = ((cpE[i - 1] - 50) / (cpE[i - 1] - cpE[i])) + Math.Log10(2000);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                            }
                                            break;
                                        case "10":
                                            {
                                                if (i == 0)
                                                {
                                                    w = ((0 - 50) / (0 - cpE[i])) + Math.Log10(20000);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                                else
                                                {
                                                    w = ((cpE[i - 1] - 50) / (cpE[i - 1] - cpE[i])) + Math.Log10(20000);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                            }
                                            break;
                                    }
                                    Tit = Convert.ToString(Y);
                                    break;
                                }
                            case 4:
                            {
                                    switch (cpC[i])
                                    {
                                        case "d5":
                                            {
                                                if (i == 0)
                                                {
                                                    w = ((0 - 50) / (0 - cpE[i])) + Math.Log10(10000);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                                else
                                                {
                                                    w = ((cpE[i - 1] - 50) / (cpE[i - 1] - cpE[i])) + Math.Log10(10000);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                            }
                                            break;
                                        case "10":
                                            {
                                                if (i == 0)
                                                {
                                                    w = ((0 - 50) / (0 - cpE[i])) + Math.Log10(20000);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                                else
                                                {
                                                    w = ((cpE[i - 1] - 50) / (cpE[i - 1] - cpE[i])) + Math.Log10(20000);
                                                    Y = Convert.ToInt64(Math.Pow(10, w));
                                                }
                                            }
                                            break;
                                    }
                                    Tit = Convert.ToString(Y);
                                    break;
                                }
                                
                        }
                    }

                    if (flag50)
                    {
                        if (flag50== false)
                        {
                            i = e - 1;
                            switch (cpC[i])
                            {
                                case "d3":
                                {
                                    Tit = ">1000";
                                    break;
                                }
                                case "d4":
                                {
                                    Tit = ">10000";
                                    break;
                                }
                                case "d5":
                                {
                                    Tit = ">100000";
                                    break;
                                }
                                case "d8":
                                {
                                    Tit = ">2000";
                                    break;
                                }
                                case "d9":
                                {
                                    Tit = ">20000";
                                    break;
                                }
                                case "10":
                                {
                                    Tit = ">200000";
                                    break;
                                }
                            }
                        }

                        parent.txt_val2.Text = Tit;

                        if (parent.selectedTest == 11 || parent.selectedTest == 30 || parent.selectedTest == 31)
                        {
                            if ((Y < 1000 && Y!=0) || Tit == "<10" || Tit == "<100" || Tit== "<1000")
                            {
                                parent.btn_Save.Enabled = false;
                                parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                                MessageBox.Show("No cumple criterio de Validación", "Verifique", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            if ((Y < 4500 && Y != 0) || Tit == "<10" || Tit == "<100" || Tit == "<1000")
                            {
                                if (parent.selectedTest == 9)
                                {
                                    parent.btn_Save.Enabled = true;
                                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = false;
                                }
                                else
                                {
                                    parent.btn_Save.Enabled = false;
                                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                                    MessageBox.Show("No cumple criterio de Validación", "Verifique", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                    }
                }
                parent.btn_Save.Enabled = true;
                parent.guardarPlacaInválidaToolStripMenuItem.Enabled = false;

            }
            catch (IOException ex)
            {
                MessageBox.Show("Error detectado: " + ex.StackTrace);
            }

        }

        public void CalcularEI1D(Principal parent)
        {
            DataGridView tablaLectura = parent.dgv_Lectura;
            DataGridView tablaProtocolo = parent.dgv_Protocolo;
            String[,] lectura = new string[8, 12];
            String[,] protocolo = new string[8, 12];

            parent.btn_Save.Enabled = true;

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
            Single ac;
            Single cc = 0;
            List<Single> cpE = new List<Single>();
            List<String> cpC = new List<String>();
            int cps, e;
            Single PI;
            datosprotocoloei datosEI = null;
            datosprotocoloeizika datosEIZika = null;

            try
            {
                ac = 0;
                cont = 0;
                if (parent.selectedTest == 22 || parent.selectedTest == 23)
                {
                    datosEIZika = DatosProtocoloEI.TraerDatosProtocoloEIZika();
                }
                else
                {
                    datosEI = DatosProtocoloEI.TraerDatosProtocoloEI();
                }

                //Calculo de los Controles Positivos
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        if (protocolo[i,j].StartsWith("C+"))
                        {
                            if (!lectura[i,j].EndsWith(Convert.ToString((char)8203)))
                            {
                                cc = Single.Parse(lectura[i, j]);
                                ac += Single.Parse(lectura[i, j]);
                                cpE.Add(cc);
                                cpC.Add(lectura[i,j]);
                                cont++;
                            }
                        }
                    }
                }

                cps = cont;
                if (cont < 2)
                {
                    MessageBox.Show("No cumple Criterios en los controles positivos",
                        "Verifique su protocolo de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parent.btn_Save.Enabled = false;
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                    return;
                }
                else
                {
                    parent.MxCPEI = ac / cont;
                    parent.txt_val2.Text = (parent.MxCPEI).ToString("0.000");
                }

                ac = 0;
                cont = 0;
                //Calculo de los Controles Negativos
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
                            if (cc != -120)
                            {
                                if (parent.selectedTest == 22 || parent.selectedTest == 23)
                                {
                                    if (!(cc >= datosEIZika.ControlNegLI && cc <= datosEIZika.ControlNegLS))
                                    {
                                        MessageBox.Show(protocolo[i, j] + " No cumple Criterios",
                                            "Verifique sus datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        parent.btn_Save.Enabled = false;
                                        parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                                        return;
                                    }
                                }
                                else
                                {
                                    if (!(cc >= datosEI.ControlNegLI && cc <= datosEI.ControlNegLS))
                                    {
                                        MessageBox.Show(protocolo[i, j] + " No cumple Criterios",
                                            "Verifique sus datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        parent.btn_Save.Enabled = false;
                                        parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }

                if (cont < 2)
                {
                    MessageBox.Show("No cumple Criterios en los controles negativos",
                        "Verifique su protocolo de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parent.btn_Save.Enabled = false;
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                    return;
                }
                else
                {
                    parent.MxCNEI = ac / cont;
                    parent.txt_val3.Text = parent.MxCNEI.ToString("0.000");
                }

                parent.txt_val1.Text = (parent.MxCNEI / 2).ToString("0.000");

                for (int i = 0; i < cps -1; i++)
                {
                    if (cpE[i] > (parent.MxCNEI /2))
                    {
                        MessageBox.Show("El control positivo " + cpC[i] + " No cumple criterios",
                            "OD Control: " + cpE[i], MessageBoxButtons.OK, MessageBoxIcon.Error);
                        parent.btn_Save.Enabled = false;
                        parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                        return;
                    }
                }

                parent.btn_Save.Enabled = true;
                parent.guardarPlacaInválidaToolStripMenuItem.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error detectado: " + ex.StackTrace);
            }
        }

        public void CalculoRV(Principal parent)
        {
            DataGridView tablaLectura = parent.dgv_Lectura;
            DataGridView tablaProtocolo = parent.dgv_Protocolo;
            String[,] lectura = new string[8, 12];
            String[,] protocolo = new string[8, 12];

            parent.btn_Save.Enabled = true;

            //Recolectar los datos de las tablas a una matriz

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    lectura[i, j] = tablaLectura.Rows[i].Cells[j].Value.ToString();
                    protocolo[i, j] = tablaProtocolo.Rows[i].Cells[j].Value.ToString();
                }
            }

            Single ac, cc =0;
            int cont;
            datosprotocolorotaviru datos = DatosProtocoloRotavirus.TraerDatosprotocoloRotavirus();

            //Calculo de Controles Positivos

            try
            {
                ac = 0;
                cont = 0;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        if (protocolo[i,j].StartsWith("C+"))
                        {
                            if (!lectura[i, j].EndsWith(Convert.ToString((char)8203)))
                            {
                                cc = Single.Parse(lectura[i, j]);
                                ac += Single.Parse(lectura[i, j]);
                                cont++;
                            }

                            if (cc != -120)
                            {
                                if (!(cc > datos.ControlPosLI && cc<= datos.ControlPosLS))
                                {
                                    MessageBox.Show(protocolo[i, j] + " No cumple con Criterios", "Verifique sus datos",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    parent.btn_Save.Enabled = false;
                                }
                            }
                        }
                    }
                }

                if (cont < 1)
                {
                    MessageBox.Show("No existe control positivo", "Verifique su protocolo de trabajo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parent.btn_Save.Enabled = false;
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                    parent.cpB = 0;
                }
                else
                {
                    parent.cpB = ac / cont;
                }

                parent.txt_val3.Text = parent.cpB.ToString("0.000");


                //Calculo de Controles Negativos

                ac = 0;
                cont = 0;

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        if (protocolo[i,j].StartsWith("C-"))
                        {
                            if (!lectura[i, j].EndsWith(Convert.ToString((char)8203)))
                            {
                                cc = Single.Parse(lectura[i, j]);
                                ac += Single.Parse(lectura[i, j]);
                                cont++;
                            }

                            if (cc != -120)
                            {
                                if (!(cc >= datos.ControlNegLI && cc < datos.ControlNegLS))
                                {
                                    MessageBox.Show(protocolo[i, j] + " No Cumple Criterios", "Verifique sus datos",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    parent.btn_Save.Enabled = false;
                                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                                    return;
                                }
                            }
                        }
                    }
                }

                if (cont < 1)
                {
                    MessageBox.Show("Tiene que haber control negativo", "Verifique su protocolo de trabajo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parent.btn_Save.Enabled = false;
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                    return;
                }
                else
                {
                    if (cont > 0)
                    {
                        parent.cn = ac / cont;
                    }
                    else
                    {
                        parent.cn = 0;
                    }
                }

                parent.txt_val1.Text = (parent.cn + 0.2).ToString("0.000");
                parent.txt_val2.Text = parent.cn.ToString("0.000");

                parent.btn_Save.Enabled = true;
                parent.guardarPlacaInválidaToolStripMenuItem.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error detectado: " + ex.StackTrace);
            }



        }

        public void CalculoChik(Principal parent)
        {
            DataGridView tablaLectura = parent.dgv_Lectura;
            DataGridView tablaProtocolo = parent.dgv_Protocolo;
            String[,] lectura = new string[8, 12];
            String[,] protocolo = new string[8, 12];

            parent.btn_Save.Enabled = true;

            //Recolectar los datos de las tablas a una matriz

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    lectura[i, j] = tablaLectura.Rows[i].Cells[j].Value.ToString();
                    protocolo[i, j] = tablaProtocolo.Rows[i].Cells[j].Value.ToString();
                }
            }

            Single ac, cc = 0;
            int cont;

            try
            {
                ac = 0;
                cont = 0;

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        cc = -120;
                        if (protocolo[i,j].StartsWith("C+v"))
                        {
                            if (!lectura[i,j].EndsWith(Convert.ToString((char)8203)))
                            {
                                cc = Single.Parse(lectura[i, j]);
                                ac += Single.Parse(lectura[i, j]);
                                cont++;
                            }
                        }
                    }
                }

                if (cont< 1)
                {
                    MessageBox.Show("No existe control positivo", "Verifique su protocolo de trabajo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parent.btn_Save.Enabled = false;
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                    parent.cpB = 0;
                }
                else
                {
                    parent.cpB = ac / cont;
                }

                parent.txt_val3.Text = parent.cpB.ToString("0.000");

                //Calculo Controles Negativos AV
                ac = 0;
                cont = 0;

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        cc = -120;
                        if (protocolo[i,j].StartsWith("C-v"))
                        {
                            if (!lectura[i,j].EndsWith(Convert.ToString((char)8203)))
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
                    MessageBox.Show("Tiene que haber control negativo", "Verifique su protocolo de trabajo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parent.btn_Save.Enabled = false;
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                    return;
                }
                else
                {
                    if (cont > 0)
                    {
                        parent.cn = ac / cont;
                    }
                    else
                    {
                        parent.cn = 0;
                    }
                }

                parent.txt_val1.Text = (parent.cpB / parent.cn).ToString("0.###");

                parent.txt_val2.Text = parent.cn.ToString("0.###");

                if (!((parent.cpB / parent.cn) >= 2))
                {
                    MessageBox.Show("El ensayo no es válido y debe ser repetido");
                    parent.btn_Save.Enabled = false;
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                    return;
                }

                //Calculo de los controles posirivos AN

                ac = 0;
                cont = 0;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        cc = -120;
                        if (protocolo[i, j].StartsWith("C+n"))
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
                    MessageBox.Show("No existe control positivo", "Verifique su protocolo de trabajo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parent.btn_Save.Enabled = false;
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                    parent.cpR = 0;
                }
                else
                {
                    parent.cpR = ac / cont;
                }

                if ((parent.cpB / parent.cpR) < 2)
                {
                    MessageBox.Show("Ruido de fondo en la reacción para el control positivo",
                        "No puede ser interpretado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parent.btn_Save.Enabled = false;
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                    return;
                }

                //Calculo Controles Negativos AN

                ac = 0;
                cont = 0;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        cc = -120;
                        if (protocolo[i, j].StartsWith("C-n"))
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
                    MessageBox.Show("No existe control negativo", "Verifique su protocolo de trabajo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parent.btn_Save.Enabled = false;
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                    parent.cnR = 0;
                }
                else
                {
                    parent.cnR = ac / cont;
                }

                parent.btn_Save.Enabled = true;
                parent.guardarPlacaInválidaToolStripMenuItem.Enabled = false;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public void CalcularChikCNDR(Principal parent)
        {
            DataGridView tablaLectura = parent.dgv_Lectura;
            DataGridView tablaProtocolo = parent.dgv_Protocolo;
            String[,] lectura = new string[8, 12];
            String[,] protocolo = new string[8, 12];

            parent.btn_Save.Enabled = true;

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
            Single ac, cc = 0;
            datosprotocolochik datos = DatosProtocoloChik.TraerDatosprotocoloChik();

            //Calcular controles Positivos
            try
            {
                ac = 0;
                cont = 0;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        cc = -120;
                        if (protocolo[i, j].StartsWith("C+"))
                        {
                            if (!lectura[i, j].EndsWith(Convert.ToString((char)8203)))
                            {
                                cc = Single.Parse(lectura[i, j]);
                                ac += Single.Parse(lectura[i, j]);
                                cont++;
                            }

                            if (cc != -120)
                            {
                                if (!(cc > datos.LimCPI && cc <= datos.LimCPS))
                                {
                                    MessageBox.Show(protocolo[i, j] + " No cumple con Criterios", "Verifique sus datos",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    parent.btn_Save.Enabled = false;
                                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                                }
                            }
                        }
                    }
                }
                if (cont < 1)
                {
                    MessageBox.Show("Tiene que haber al menos un control positivo", "Verifique su protocolo de trabajo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parent.btn_Save.Enabled = false;
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                    return;
                }
                else
                {
                    if (cont > 0)
                    {
                        parent.cn = ac / cont;
                    }
                    else
                    {
                        parent.cn = 0;
                    }
                }

                parent.txt_val3.Text = parent.cn.ToString("0.000");

                //Calculo de los controles negativos
                ac = 0;
                cont = 0;

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        cc = -120;
                        if (protocolo[i, j].StartsWith("C-"))
                        {
                            if (!lectura[i, j].EndsWith(Convert.ToString((char)8203)))
                            {
                                cc = Single.Parse(lectura[i, j]);
                                ac += Single.Parse(lectura[i, j]);
                                cont++;
                            }

                            if (cc != -120)
                            {
                                if (!(cc > datos.LimCNS && cc <= datos.LimCNI))
                                {
                                    MessageBox.Show(protocolo[i, j] + " No cumple con Criterios", "Verifique sus datos",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    parent.btn_Save.Enabled = false;
                                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                                }
                            }
                        }
                    }
                }

                if (cont < 2)
                {
                    MessageBox.Show("Tiene que haber al menos dos controles negativos",
                        "Verifique su protocolo de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parent.btn_Save.Enabled = false;
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                    return;
                }
                else
                {
                    if (cont > 0)
                    {
                        parent.cn = ac / cont;
                    }
                    else
                    {
                        parent.cn = 0;
                    }
                }

                parent.txt_val2.Text = parent.cn.ToString("0.000");

                parent.txt_val1.Text =
                    (Single.Parse(parent.txt_val3.Text) / Single.Parse(parent.txt_val2.Text)).ToString("0.000");
                parent.btn_Save.Enabled = true;
                parent.guardarPlacaInválidaToolStripMenuItem.Enabled = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }

        public void CalcularZikaBob(Principal parent)
        {
            DataGridView tablaLectura = parent.dgv_Lectura;
            DataGridView tablaProtocolo = parent.dgv_Protocolo;
            String[,] lectura = new string[8, 12];
            String[,] protocolo = new string[8, 12];

            parent.btn_Save.Enabled = true;

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
            Single ac, cc = 0;
            List<Single> cpE = new List<Single>();
            List<String> cpC = new List<String>();
            int cps;
            Single PI;

            try
            {
                ac = 0;
                cont = 0;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        cc = -120;
                        if (protocolo[i, j].StartsWith("MAX"))
                        {
                            if (!lectura[i, j].EndsWith(Convert.ToString((char)8203)))
                            {
                                cc = Single.Parse(lectura[i, j]);
                                ac += Single.Parse(lectura[i, j]);
                                cpE.Add(cc);
                                cpC.Add(protocolo[i,j]);
                                cont++;
                            }
                        }
                    }
                }

                cps = cont;

                if (cont < 0)
                {
                    MessageBox.Show("No cumple criterios en los controles maximos", "Verifique su protocolo de Trabajo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parent.btn_Save.Enabled = false;
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                    return;
                }
                else
                {
                    parent.MxCPEI = ac / cont;
                    parent.txt_val1.Text = parent.MxCPEI.ToString("0.000");
                }

                //Calculo de los controles negativos

                ac = 0;
                cont = 0;

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; i < 12; i++)
                    {
                        cc = -120;
                        if (protocolo[i, j].StartsWith("MIN"))
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

                if (cont < 0)
                {
                    MessageBox.Show("No cumple criterios en los controles minimos", "Verifique su protocolo de trabajo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parent.btn_Save.Enabled = false;
                    parent.guardarPlacaInválidaToolStripMenuItem.Enabled = true;
                    return;
                }
                else
                {
                    parent.MxCNEI = ac / cont;
                    parent.txt_val2.Text = parent.MxCNEI.ToString("0.000");
                }

                if (Single.Parse(parent.txt_val2.Text) >= 0.08)
                {
                    MessageBox.Show(
                        "No cumple criterio de validación, en el valor de la media de MNM es mayor o igual a 0.08",
                        "Verifique sus datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (Single.Parse(parent.txt_val1.Text) < 0.9)
                {
                    MessageBox.Show("No cumple criterio de validación, el valor de la media de MXM es menor a 0.9",
                        "Verifique sus datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                parent.btn_Save.Enabled = true;
                parent.guardarPlacaInválidaToolStripMenuItem.Enabled = false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
