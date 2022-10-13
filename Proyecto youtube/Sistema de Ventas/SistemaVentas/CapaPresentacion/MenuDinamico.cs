using Capa_Negocio;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class MenuDinamico : Form
    {
        //MENU DE PRUEBA REALIZADO POR EL PROFESOR TIMY
        public MenuDinamico(Usuario usuario)
        {
            UsuarioActual = usuario;
            InitializeComponent();
        }

        private void MenuDinamico_Click(object sender, EventArgs e)
        {
            MessageBox.Show("funciona");
        }

        private static Usuario UsuarioActual;
        private void MenuDinamico_Load(object sender, EventArgs e)
        {

            //List<Permiso> ListaPermisos = new CN_Permiso().Listar(UsuarioActual.IdUsuario);

            //ToolStrip mainMenu = new ToolStrip();
            //Controls.Add(mainMenu);

            //foreach (var item in ListaPermisos)
            //{

            //    ToolStripButton x = new ToolStripButton(item.NombreMenu,Properties.Resources.acerca_de__1_,MenuDinamico_Click);
            //    mainMenu.Items.Add(x);
            //}

        }
    }
}
