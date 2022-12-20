using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Negocio;
using CapaEntidad;
using DocumentFormat.OpenXml.Drawing;

namespace CapaPresentacion
{
    public partial class FormNegocio : Form
    {
        public FormNegocio()
        {
            InitializeComponent();
        }
        //Funcion para Convertir una array de bytes a un map de bits
        public Image ByteToImage(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(bytes, 0, bytes.Length);
            Image imagen = new Bitmap(ms);

            return imagen;
        }
        private void FormNegocio_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] imagen = new CN_Negocio().ObtenerLogo(out obtenido);

            if (obtenido)
            {
                picLogo.Image = ByteToImage(imagen);
            }
            Negocio datos = new CN_Negocio().ObtenerDatos();

            txtRazonSocial.Text = datos.Nombre;
            txtRuc.Text = datos.Ruc;
            txtDireccion.Text = datos.Direccion;

        }
        private void btnSubir_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            OpenFileDialog op = new OpenFileDialog();
            op.FileName = "Files|*.jpg;*.jpeg;*.png";

            if (op.ShowDialog() == DialogResult.OK)
            {
                byte[] image = File.ReadAllBytes(op.FileName);
                bool respuesta = new CN_Negocio().ActualizarLogo(image,out mensaje);

                if (respuesta)
                {
                    picLogo.Image = ByteToImage(image);
                }
                else
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Negocio obj = new Negocio()
            {
                Nombre = txtRazonSocial.Text,
                Ruc = txtRuc.Text,
                Direccion = txtDireccion.Text
            };

            bool respuesta = new CN_Negocio().Registar(obj,out mensaje);

            if (respuesta)
            {
                MessageBox.Show("Los Cambios Fueron Guardados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Los Cambios No Fueron Guardados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}
