using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EjemploDiseño
{
    public partial class MenuLateral : Form
    {
        public MenuLateral()
        {
            InitializeComponent();
        }

        private void Click_close(object sender, EventArgs e)
        {
            this.Close();
        }


        private void DesmarcarBotones()
        {
            Color color = Color.FromArgb(10, 10, 10);
            btnTodos.BackColor = color;
            btnAgregar.BackColor = color;
            btnEditar.BackColor = color;
            btnEliminar.BackColor = color;
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            DesmarcarBotones();
            btnTodos.BackColor = Color.Gold;
            FormHijo(new FrmTodos());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DesmarcarBotones();
            btnAgregar.BackColor = Color.Gold;
            FormHijo(new FrmAgregar());
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DesmarcarBotones();
            btnEditar.BackColor = Color.Gold;
            FormHijo(new FrmEditar());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DesmarcarBotones();
            btnEliminar.BackColor = Color.Gold;
            FormHijo(new FrmEliminar());
        }



        private Form formActivo = null;
        private void FormHijo(Form formHijo)
        {
            if(formActivo != null) formActivo.Close();
            formActivo = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            pnlContenedor.Controls.Add(formHijo);
            pnlContenedor.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }
    }
}
