using Capa_Negocio;
using CapaEntidad;
using CapaPresentacion.Utilidades;
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
    public partial class FormProveedores : Form
    {
        public FormProveedores()
        {
            InitializeComponent();
        }

        private void FormProveedores_Load(object sender, EventArgs e)
        {
            //LLENAR EL COMBOBOX DE ESTADO CON SUS ITEMS CORRESPONDIENTES
            comboEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            comboEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            comboEstado.DisplayMember = "Texto";
            comboEstado.ValueMember = "Valor";
            comboEstado.SelectedIndex = 0;

            //LLENAR EL COMBOBOX DE BUSQUEDA CON EL NOMBRE DE LAS FILAS VISIBLES
            foreach (DataGridViewColumn columna in dataGriwProveedor.Columns)
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
            List<Proveedor> lista = new CN_Proveedor().Lista();
            foreach (Proveedor item in lista)
            {
                dataGriwProveedor.Rows.Add(new object[]
                { "",item.IdProveedor,item.Documento,item.RazonSocial,item.Correo,item.Telefono,
                     item.Estado == true ? "Activo" : "No activo",
                     item.Estado == true ? 1 : 0,
                });
            }
        }
        //EVENTO BOTON GUARDAR, AGREGA DATOS AL DATAGRIDVIEW
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Proveedor proveedor = new Proveedor()
            {
                IdProveedor = Convert.ToInt32(txtId.Text),
                Documento = txtDocumento.Text,
                RazonSocial = txtRazonSocial.Text,
                Correo = txtCorreo.Text,
                Telefono = txtTelefono.Text,
                Estado = Convert.ToInt32(((OpcionCombo)comboEstado.SelectedItem).Valor) == 1 ? true : false
            };

            if (proveedor.IdProveedor == 0)
            {
                int idproveedorgenerado = new CN_Proveedor().Registar(proveedor, out mensaje);

                if (idproveedorgenerado != 0)
                {
                    dataGriwProveedor.Rows.Add(new object[]
                    { "",idproveedorgenerado,txtDocumento.Text,txtRazonSocial.Text,txtCorreo.Text,txtTelefono.Text,
                    ((OpcionCombo)comboEstado.SelectedItem).Texto.ToString(),
                    ((OpcionCombo)comboEstado.SelectedItem).Valor.ToString()
                    });

                    Clear();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool resultado = new CN_Proveedor().Editar(proveedor, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dataGriwProveedor.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["IdProveedor"].Value = txtindice.Text;
                    row.Cells["Documento"].Value = txtDocumento.Text;
                    row.Cells["RazonSocial"].Value = txtRazonSocial.Text;
                    row.Cells["Correo"].Value = txtCorreo.Text;
                    row.Cells["Telefono"].Value = txtTelefono.Text;
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)comboEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)comboEstado.SelectedItem).Texto.ToString();
                    Clear();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            txtRazonSocial.ReadOnly = true;
            txtDocumento.ReadOnly = true;
            txtCorreo.ReadOnly = true;
            txtTelefono.ReadOnly = true;

        }

        //METODO PARA LIMPIAR LOS TEXTBOX Y REINICIAR EL COMBOBOX DE LLENADO DE DATOS
        private void Clear()
        {
            txtindice.Text = "-1";
            txtId.Text = "";
            txtDocumento.Text = "";
            txtRazonSocial.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            comboEstado.SelectedIndex = 0;
        }

        //EVENTO QUE PINTA EL CHECK EN EL BOTON DEL DATAGRID
        private void dataGriwProveedor_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            else if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var with = Properties.Resources.comprobar.Width;
                var height = Properties.Resources.comprobar.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - with) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - height) / 2;

                e.Graphics.DrawImage(Properties.Resources.comprobar, new Rectangle(x, y, with, height));
                e.Handled = true;
            }
        }
        //EVENTO PARA SELECCIONAR LOS DATOS DE CADA USUARIO EN LA TABLA
        private void dataGriwProveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGriwProveedor.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtId.Text = dataGriwProveedor.Rows[indice].Cells["IdProveedor"].Value.ToString();
                    txtDocumento.Text = dataGriwProveedor.Rows[indice].Cells["Documento"].Value.ToString();
                    txtRazonSocial.Text = dataGriwProveedor.Rows[indice].Cells["RazonSocial"].Value.ToString();
                    txtCorreo.Text = dataGriwProveedor.Rows[indice].Cells["Correo"].Value.ToString();
                    txtTelefono.Text = dataGriwProveedor.Rows[indice].Cells["Telefono"].Value.ToString();

                    foreach (OpcionCombo item in comboEstado.Items)
                    {
                        if (Convert.ToInt32(item.Valor) == Convert.ToInt32(dataGriwProveedor.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = comboEstado.Items.IndexOf(item);
                            comboEstado.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtindice.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar el proveedor", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;
                    Proveedor proveedor = new Proveedor()
                    {
                        IdProveedor = Convert.ToInt32(txtId.Text)
                    };

                    bool respuesta = new CN_Proveedor().Eliminar(proveedor, out mensaje);

                    if (respuesta)
                    {
                        dataGriwProveedor.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                    }
                    else
                    {
                        MessageBox.Show(mensaje);
                    }
                    Clear();
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtRazonSocial.ReadOnly = false;
            txtDocumento.ReadOnly = false;
            txtCorreo.ReadOnly = false;
            txtTelefono.ReadOnly = false;
        }
    }
}
