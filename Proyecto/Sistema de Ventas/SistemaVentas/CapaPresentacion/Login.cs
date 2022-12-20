﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Capa_Negocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //VERIFICACION DE INICIO DE SECCION
        private void btnInciar_Click(object sender, EventArgs e)
        {
            Usuario ousuario = new CN_Usuario().Lista().Where(u => u.Documento == txtDocumento.Text && u.Clave == txtContraseña.Text).FirstOrDefault();

            if (ousuario != null)
            {
                Inicio principal = new Inicio(ousuario);

                principal.Show();
                this.Hide();
                principal.Show();
                principal.FormClosing += frm_closing;
            }
            else
            {
                MessageBox.Show("El usuario no se encuantra registrado","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        //EVENTO DEL BOTON CERRAR
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //EVENTO PARA CUANDO EL FORMULARIO CIERRE LIMPIE LOS TEXTBOX
        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            txtDocumento.Text = "";
            txtContraseña.Text = "";
            this.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
