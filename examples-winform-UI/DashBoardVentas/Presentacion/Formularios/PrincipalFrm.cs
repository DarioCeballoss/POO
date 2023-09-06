using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Formularios
{
    public partial class PrincipalFrm : Form
    {
        public PrincipalFrm()
        {
            InitializeComponent();
        }
        private void PrincipalFrm_Load(object sender, EventArgs e)
        {
            Buttons_Click(btnDashBoard, null);
        }

        private Form FormActivo = null;

        private void tmrHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFecha.Text = DateTime.Now.ToString("dd-MMM-yyyy");
        }

        private Button BotonAnterior { get; set; }
        private void Buttons_Click(object sender, EventArgs e)
        {
            if (BotonAnterior != null)
                BotonAnterior.BackColor = Color.FromArgb(23, 42, 51);

            var button = ((Button)sender);
            button.BackColor = Color.FromArgb(94, 145, 169);
            BotonAnterior = button;
            AbrirFormulario(button.Name);
        }

        private void AbrirFormulario(string name)
        {
            switch (name)
            {
                case "btnDashBoard":
                    OpenFormHijo(new DashboardFrm());
                    break;
                case "btnProductos":
                    OpenFormHijo(new ProductosFrm());
                    break;
                case "btnCompras":
                    OpenFormHijo(new ComprasFrm());
                    break;
                case "btnVentas":
                    OpenFormHijo(new VentasFrm());
                    break;
                case "btnMovimientos":
                    OpenFormHijo(new MovimientosFrm());
                    break;
                case "btnDevoluciones":
                    OpenFormHijo(new DevolucionesFrm());
                    break;
                case "btnReportes":
                    OpenFormHijo(new ReportesFrm());
                    break;
                case "btnConfiguraciones":
                    OpenFormHijo(new ConfiguracionesFrm());
                    break;
            }
        }

        private void OpenFormHijo(Form formHijo)
        {
            FormActivo?.Close();
            FormActivo = formHijo;
            FormActivo.TopLevel = false;
            FormActivo.FormBorderStyle = FormBorderStyle.None;
            FormActivo.Dock = DockStyle.Fill;
            pnlContenedor.Controls.Add(FormActivo);
            pnlContenedor.Tag = formHijo;
            FormActivo.BringToFront();
            FormActivo.Show();
        }
    }
}
