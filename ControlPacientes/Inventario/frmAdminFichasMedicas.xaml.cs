﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ControlPacientes.DatosLN;

namespace ControlPacientes.Inventario
{
    /// <summary>
    /// Lógica de interacción para frmAdminFichasMedicas.xaml
    /// </summary>
    public partial class frmAdminFichasMedicas : Window
    {
        public frmAdminFichasMedicas()
        {
            InitializeComponent();
        }
        FichaMedicaLN oln =new FichaMedicaLN();
        public void ListarFichasM()
        {
            dgEnfermera.DataContext = oln.ViewFichaMedica();
        }
        public void ListarFichasMF(string val)
        {
            dgEnfermera.DataContext = oln.ViewFichaMedicaFiltro(val);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text.Equals(""))
            {
                ListarFichasM();
            }
            else
            {
                string val = txtBuscar.Text;
                ListarFichasMF(val);
            }
        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBuscar.Text.Equals(""))
            {
                ListarFichasM();
            }
            else
            {
                string val = txtBuscar.Text;
                ListarFichasMF(val);
            }
        }
    }
}
