﻿using System;
using System.Linq;
using System.Windows.Forms;
using ELISA.Utils;

namespace ELISA.Transaccion
{
    class LaboratoristasTrans
    {

        public static void LlenarLaboratoristas(ComboBox cmb)
        {
            try
            {
                using (var context = new elisaEntities2())
                {
                    var listaLaboratoristas = context.laboratoristas.ToList();
                    cmb.DataSource = listaLaboratoristas;
                    cmb.DisplayMember = "Cod";
                    cmb.ValueMember = "Cod";
                    cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
                    cmb.Invalidate();
                    Log.logInfo("Lista de laboratorista cargado correctamente");
                    cmb.SelectedItem = null;
                    cmb.SelectedText = "";
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
