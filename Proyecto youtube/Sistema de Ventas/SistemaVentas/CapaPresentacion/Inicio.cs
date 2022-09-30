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

namespace CapaPresentacion
{
    public partial class Inicio : Form
    {

        private static Usuario UsuarioActual;
        public Inicio(Usuario objUsuario)
        {
            UsuarioActual = objUsuario;
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = UsuarioActual.NombreCompleto;
        }
    }
}
