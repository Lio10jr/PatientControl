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

namespace ControlPacientes.Reports
{
    /// <summary>
    /// Lógica de interacción para frmCRRecetas.xaml
    /// </summary>
    public partial class frmCRRecetas : Window
    {
        public frmCRRecetas()
        {
            InitializeComponent();
        }
        public void GenerarReportes(string val)
        {
            try
            {
                CReportes ds = new CReportes();
                RecetaLN oe = new RecetaLN();
                List<Receta> Lista = oe.ViewRecetaFiltro(val);
                foreach (Receta op in Lista)
                {
                    ds.cp_ListarRecetasFiltro.Addcp_ListarRecetasFiltroRow(op.NumReceta, op.Dosis, op.FecheActual, op.IdMedicamento, op.IdMedico,
                        op.IdPaciente);
                }
                CRRecetas rpt = new CRRecetas();
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
            GenerarReportes(txtBuscar.Text);
        }
    }
}
