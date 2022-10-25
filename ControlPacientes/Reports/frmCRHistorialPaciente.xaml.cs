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
    /// Lógica de interacción para frmCRHistorialPaciente.xaml
    /// </summary>
    public partial class frmCRHistorialPaciente : Window
    {
        public frmCRHistorialPaciente()
        {
            InitializeComponent();
        }

        public void GenerarReportes(string val)
        {
            try
            {
                CReportes ds = new CReportes();
                HistorialPacienteLN oe = new HistorialPacienteLN();
                List<HistorialPaciente> Lista = oe.ViewHistorialPacienteFiltro(val);
                foreach (HistorialPaciente op in Lista)
                {
                    ds.cp_ListarHistorialPacienteFiltro.Addcp_ListarHistorialPacienteFiltroRow(op.IdRegPaciente, op.NumConsultas, op.UltimaFechaC, op.IdPaciente, op.IdRegPaciente);
                }
                CRHistorialPaciente rpt = new CRHistorialPaciente();
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
