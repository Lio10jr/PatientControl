using System;
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
using ControlPacientes.Entidades;
using CrystalDecisions.CrystalReports.Engine;

namespace ControlPacientes.Reports
{
    /// <summary>
    /// Lógica de interacción para frmCRFichasMedicas.xaml
    /// </summary>
    public partial class frmCRFichasMedicas : Window
    {
        public frmCRFichasMedicas()
        {
            InitializeComponent();
        }
        public void GenerarReportes(string val)
        {
            try
            {
                CReportes ds = new CReportes();
                FichaMedicaLN oe = new FichaMedicaLN();
                List<FichaMedica> Lista = oe.ViewFichaMedicaFiltro(val);
                foreach (FichaMedica op in Lista)
                {
                    ds.cp_ListarFichaMedicaFiltro.Addcp_ListarFichaMedicaFiltroRow(op.IdFichaM, op.IdPaciente, op.Madre, op.Padre, op.Estudios,
                        op.GrupoSanguineo, op.Edad, op.Peso, op.Estatura);
                }
                CRFichasMedicas rpt = new CRFichasMedicas();
                rpt.SetDataSource(ds);
                crystalReportViewer1.ViewerCore.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string val = txtBuscar.Text;
            GenerarReportes(val);
        }
    }
}
