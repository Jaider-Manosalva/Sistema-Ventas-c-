using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidad;
using Capa_Negocio;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapaPresentacion
{
    public partial class Inicio : Form
    {
        //ATRIBUTOS 
        private static Usuario UsuarioActual;
        private static ToolStripButton MenuActivo = null;
        private static ToolStripDropDownButton MenuAction = null;
        private static Form FormularioActivo = null;

        //RECOMENDACION: Quitar el null de parametro de inicio !! CUANDO SE LANZE A PRODUCCION O SE PRUEBE
        public Inicio(Usuario objUsuario = null)
        {
            //RECOMENDACION ELIMINAR CONDICION !!  CUANDO SE LANZE A PRODUCCION O SE PRUEBE
            if (objUsuario == null)
            {
                UsuarioActual = new Usuario() { NombreCompleto = "admin predefinido", IdUsuario = 1 };
            }
            //RECOMENDACION QUITAR COMENTADO DE LA SIGUIENTE LINEA !! CUANDO SE LANZE A PRODUCCION O SE PRUEBE
            //UsuarioActual = objUsuario;
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            //SEGUN EL ROL DEL USUARIO SE RESTRINGIRA EL USU DE CIERTAS OPCIONES DEL MENU
            string menu = new CN_Permiso().tipopermiso(UsuarioActual.IdUsuario);

            if (menu.Equals("2"))
            {
                btnUsuarios.Visible = false;
                btnMantenedor.Visible = false;
                btnReportes.Visible = false;
            }

            txtUsuario.Text = UsuarioActual.NombreCompleto;
        }

        //METODO PARA LA ITERACCION DEL MENU CUANDO ES ToolStripButton
        private void OpenForm(ToolStripButton menu , Form Formulario )
        {
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.FromArgb(255, 103, 0);
            }

            if (MenuAction != null)
            {
                MenuAction.BackColor = Color.FromArgb(255, 103, 0);
            }

            menu.BackColor = Color.FromArgb(58, 110, 165);
            MenuActivo = menu;

            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }

            FormularioActivo = Formulario;

            Formulario.TopLevel = false;
            Formulario.FormBorderStyle = FormBorderStyle.None;
            Formulario.Dock = DockStyle.Fill;
            Formulario.BackColor = Color.SteelBlue;

            Contenedor.Controls.Add(FormularioActivo);
            Formulario.Show();

        }

        //METODO PARA LA ITERACCION DEL MENU ToolStripDropDownButton
        private void OpenForm(ToolStripDropDownButton menu, Form Formulario)
        {
            if (MenuAction != null)
            {
                MenuAction.BackColor = Color.FromArgb(255, 103, 0);
            }

            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.FromArgb(255, 103, 0);
            }

            menu.BackColor = Color.FromArgb(58, 110, 165);
            MenuAction = menu;

            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }

            FormularioActivo = Formulario;

            Formulario.TopLevel = false;
            Formulario.FormBorderStyle = FormBorderStyle.None;
            Formulario.Dock = DockStyle.Fill;
            Formulario.BackColor = Color.SteelBlue;

            Contenedor.Controls.Add(FormularioActivo);
            Formulario.Show();
        }

        //EVENTOS BOTONES MENU

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            OpenForm((ToolStripButton)sender,new FormUsuarios());
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            OpenForm((ToolStripButton)sender, new FormCompras());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            OpenForm((ToolStripButton)sender, new FormClientes());
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            OpenForm((ToolStripButton)sender, new FormProveedores());
        }

        //EVENTOS BOTONES SUBMENUS

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            //toolStripDropDownButton
            OpenForm(btnMantenedor, new FormCategoria());
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            OpenForm(btnMantenedor, new FormProducto());
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            OpenForm(btnVentas, new FormVentas());
        }

        private void btnverDetalle_Click(object sender, EventArgs e)
        {
            OpenForm(btnVentas, new FormVerDetalle());
        }
    }
}
