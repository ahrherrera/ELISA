﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELISA.Utils;

namespace ELISA.Transaccion
{
    class ControlesTrans
    {

        public static void updateControlIgM(String CodigoControl, controles_igm update)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    controles_igm control = context.controles_igm.Single(x => x.Cod_Asign_ContIgM == CodigoControl);
                    control.Tipo_Control = control.Tipo_Control;
                    if (update.D_Optica != null)
                    {
                        control.D_Optica = update.D_Optica.Value;
                    }
                    else
                    {
                        control.D_Optica = null;}

                    control.Volumen = update.Volumen;
                    if (update.Fecha_Finalizacion != null)
                    {
                        control.Fecha_Finalizacion = update.Fecha_Finalizacion.Value;
                    }
                    else
                    {
                        control.Fecha_Finalizacion = null;}

                    if (update.Fecha_Inicio != null)
                    {
                        control.Fecha_Inicio = update.Fecha_Inicio.Value;
                    }
                    else
                    {
                        control.Fecha_Inicio = null;}
                    control.Oservaciones = update.Oservaciones;
                    context.SaveChanges();
                    Task.Run(() =>
                    {
                        MessageBox.Show("Ha sido actualizado correctamente");
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Trace: " + ex.Message);
            }
        }
        public static void removeControl(String test, String CodigoControl)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    
                    if (test.Contains("IgM"))
                    {
                        controles_igm control = context.controles_igm.Single(x => x.Cod_Asign_ContIgM == CodigoControl);

                        context.controles_igm.Remove(control);
                    }
                    else if (test.Contains("EI"))
                    {
                        controles_ei control = context.controles_ei.Single(x => x.Codigo_Asig_ContEI == CodigoControl);

                        context.controles_ei.Remove(control);
                    }
                    else
                    {

                    }

                    context.SaveChanges();
                    Task.Run(() =>
                    {
                        MessageBox.Show("Ha sido eliminado correctamente");
                    });
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Trace: " + ex.Message);
            }
        }

        public static void addControlesIgM(controles_igm controlNuevo)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    context.controles_igm.Add(controlNuevo);
                    context.SaveChanges();
                    Task.Run(() =>
                    {
                        MessageBox.Show("Ha sido agregado correctamente");
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Trace: " + ex.Message);
            }
        }

        public static void addControlesEI(controles_ei controlNuevo)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    context.controles_ei.Add(controlNuevo);
                    context.SaveChanges();
                    Task.Run(() =>
                    {
                        MessageBox.Show("Ha sido agregado correctamente");
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Trace: " + ex.Message);
            }
        }
        public static void getControles(String test, String tipoControl, DataGridView tabla)
        {
            tabla.DataSource = null;
            try
            {
                using (var context = new elisaEntities2())
                {
                    if (test.Contains("IgM"))
                    {
                        List<controles_igm> lista = null;
                        lista = context.controles_igm.Where(x => x.Tipo_Control == tipoControl).ToList();
                        tabla.DataSource = lista;
                    }
                    else if (test.Contains("EI"))
                    {
                        List<controles_ei> lista = null;
                        lista = context.controles_ei.Where(x => x.Tipo == tipoControl).ToList();
                        tabla.DataSource = lista;
                    }
                    else
                    {
                        //var lista = context.
                    }

                    
                }
                    
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema conectando a la base de datos.\n Por favor contacte al administrador del Sistema", "Error detectado");
                Log.logError("Error capturado: Trace: " + ex.Message);
            }
        }
    }
}