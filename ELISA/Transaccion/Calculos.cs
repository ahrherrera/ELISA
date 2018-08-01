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
                            if (!lectura[i, j].EndsWith(Convert.ToString((char) 8203)))
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
                            if (!lectura[i, j].EndsWith(Convert.ToString((char) 8203)))
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
                            if (!lectura[i, j].EndsWith(Convert.ToString((char) 8203)))
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
                            if (!lectura[i, j].EndsWith(Convert.ToString((char) 8203)))
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
                            if (!lectura[i, j].EndsWith(Convert.ToString((char) 8203)))
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
                            if (!lectura[i, j].EndsWith(Convert.ToString((char) 8203)))
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
                            if (!lectura[i, j].EndsWith(Convert.ToString((char) 8203)))
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
                            if (!lectura[i, j].EndsWith(Convert.ToString((char) 8203)))
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
                            if (!lectura[i, j].EndsWith(Convert.ToString((char) 8203)))
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
            Single[] m3men = new Single[] {3, 3, 3};
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
                            if (!lectura[i, j].EndsWith(Convert.ToString((char) 8203)))
                            {
                                cc = Single.Parse(lectura[i, j]);
                                ac += Single.Parse(lectura[i, j]);
                                cont++;
                            }
                        }

                    }
                }

                if (cont <2)
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
                                }else if (columpio< m3men[1])
                                {
                                    m3men[2] = m3men[1];
                                    m3men[1] = columpio;
                                }else if (columpio < m3men[2])
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

            }
        }
    }
}
