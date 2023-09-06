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
    public partial class DashboardFrm : Form
    {
        public DashboardFrm()
        {
            InitializeComponent();
            CargarLabels();
        }



        private void CargarLabels()
        {
            pnlProductos.Tag = lblProductos;
            pnlCompras.Tag = lblCompras;
            pnlVentas.Tag = lblVentas;
            pnlMovimientos.Tag = lblMovimientos;
            pnlDevoluciones.Tag = lblDevoluciones;
            pnlProveedores.Tag = lblProveedores;
            pnlCategorias.Tag = lblCategorias;
            pnlClientes.Tag = lblClientes;
            pnlReportes.Tag = lblReportes;
            pnlUsuarios.Tag = lblUsuarios;
        }

        private Label LabelAnterior { get; set; }

        private void pnlProductos_MouseEnter(object sender, EventArgs e)
        {
            if (LabelAnterior != null)
            {
                LabelAnterior.BackColor = Color.White;
                LabelAnterior.ForeColor= Color.FromArgb(55, 90, 101);
            }

            var label = (Label)((Panel)sender).Tag;
            label.BackColor = Color.FromArgb(94, 145, 169);
            label.ForeColor = Color.White;
            LabelAnterior = label;
        }
    }
}
