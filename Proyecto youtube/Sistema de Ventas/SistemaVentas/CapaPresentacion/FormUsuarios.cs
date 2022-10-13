using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaPresentacion.Utilidades;
using CapaEntidad;
using Capa_Negocio;

namespace CapaPresentacion
{
    public partial class FormUsuarios : Form
    {
        public FormUsuarios()
        {
            InitializeComponent();
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            //LLENAR EL COMBOBOX DE ESTADO CON SUS ITEMS CORRESPONDIENTES
            comboEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            comboEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            comboEstado.DisplayMember = "Texto";
            comboEstado.ValueMember = "Valor";
            comboEstado.SelectedIndex = 0;

            //LLENAR EL COMBOBOX DE ROLES CON SUS ITEMS CORREPONDIENTES DESDE LA LISTA ROL QUE SE LLENA CON LA DB
            List<Rol> listaRol = new CN_Rol().Lista();
            foreach (Rol item in listaRol)
            {
                comboRol.Items.Add(new OpcionCombo() { Valor = item.IdRol, Texto = item.Descripcion });
            }
            comboRol.DisplayMember = "Texto";
            comboRol.ValueMember = "Valor";
            comboRol.SelectedIndex = 0;

            //LLENAR EL COMBOBOX DE BUSQUEDA CON EL NOMBRE DE LAS FILAS VISIBLES
            foreach(DataGridViewColumn columna in dataGriwUsuario.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    comboBusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            comboBusqueda.DisplayMember = "Texto";
            comboBusqueda.ValueMember = "Valor";
            comboBusqueda.SelectedIndex = 0;

            //MOSTRAR TODOS LOS USUARIOS
            List<Usuario> lista = new CN_Usuario().Lista();
            foreach (Usuario item in lista)
            {
                dataGriwUsuario.Rows.Add(new object[]
                { "",item.IdUsuario,item.Documento,item.NombreCompleto,item.Correo,item.Clave,
                     item.ObjRol.IdRol,
                     item.ObjRol.Descripcion,
                     item.Estado == true ? "activo" : "No activo",
                     item.Estado == true ? 1 : 0,
                });
            }
        }

        //EVENTO BOTON GUARDAR, AGREGA DATOS AL DATAGRIDVIEW
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            dataGriwUsuario.Rows.Add(new object[] 
            { "",txtId.Text,txtDocumento.Text,txtNombre.Text,txtCorreo.Text,txtClave.Text,
                ((OpcionCombo)comboRol.SelectedItem).Valor.ToString(), 
                ((OpcionCombo)comboRol.SelectedItem).Texto,
                ((OpcionCombo)comboEstado.SelectedItem).Texto.ToString(),
                ((OpcionCombo)comboEstado.SelectedItem).Valor.ToString()
            });

            Clear();
        }

        //METODO PARA LIMPIAR LOS TEXTBOX Y REINICIAR EL COMBOBOX DE LLENADO DE DATOS
        private void Clear()
        {
            txtindice.Text = "-1";
            txtId.Text = "";
            txtDocumento.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtConfimarclave.Text = "";
            txtClave.Text = "";
            comboRol.SelectedIndex = 0;
            comboEstado.SelectedIndex = 0;
        }

        private void dataGriwUsuario_CellPainting(object sender,DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            else if(e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var with = Properties.Resources.comprobar.Width;
                var height = Properties.Resources.comprobar.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - with) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - height) / 2;

                e.Graphics.DrawImage(Properties.Resources.comprobar, new Rectangle(x,y,with,height));
                e.Handled = true;
            }
        }

        private void dataGriwUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGriwUsuario.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtId.Text = dataGriwUsuario.Rows[indice].Cells["IdUsuario"].Value.ToString();
                    txtDocumento.Text = dataGriwUsuario.Rows[indice].Cells["Documento"].Value.ToString();
                    txtNombre.Text = dataGriwUsuario.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtCorreo.Text = dataGriwUsuario.Rows[indice].Cells["Correo"].Value.ToString();
                    txtClave.Text = dataGriwUsuario.Rows[indice].Cells["Clave"].Value.ToString();
                    txtConfimarclave.Text = dataGriwUsuario.Rows[indice].Cells["Clave"].Value.ToString();

                    foreach (OpcionCombo item in comboRol.Items)
                    {
                        if (Convert.ToInt32(item.Valor) == Convert.ToInt32(dataGriwUsuario.Rows[indice].Cells["IdRol"].Value))
                        {
                            int indice_combo = comboRol.Items.IndexOf(item);
                            comboRol.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                    foreach (OpcionCombo item in comboEstado.Items)
                    {
                        if (Convert.ToInt32(item.Valor) == Convert.ToInt32(dataGriwUsuario.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = comboEstado.Items.IndexOf(item);
                            comboEstado.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                }
            }
        }
    }
}
