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
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            //LLENAR EL COMBOBOX DE ESTADO CON SUS ITEMS CORRESPONDIENTES
            comboEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            comboEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            comboEstado.DisplayMember = "Texto";
            comboEstado.ValueMember = "Valor";
            comboEstado.SelectedIndex = 0;

            //LLENAR EL COMBOBOX DE BUSQUEDA CON EL NOMBRE DE LAS FILAS VISIBLES
            foreach (DataGridViewColumn columna in dataGriwCliente.Columns)
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
            List<Cliente> lista = new CN_Cliente().Lista();
            foreach (Cliente item in lista)
            {
                dataGriwCliente.Rows.Add(new object[]
                { "",item.IdCliente,item.Documento,item.NombreCompleto,item.Correo,item.Telefono,
                     item.Estado == true ? "Activo" : "No activo",
                     item.Estado == true ? 1 : 0,
                });
            }
        }
        //EVENTO BOTON GUARDAR, AGREGA DATOS AL DATAGRIDVIEW
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Cliente cliente = new Cliente()
            {
                IdCliente = Convert.ToInt32(txtId.Text),
                Documento = txtDocumento.Text,
                NombreCompleto = txtNombre.Text,
                Correo = txtCorreo.Text,
                Telefono = txtTelefono.Text,
                Estado = Convert.ToInt32(((OpcionCombo)comboEstado.SelectedItem).Valor) == 1 ? true : false
            };

            if (cliente.IdCliente == 0)
            {
                int idusuariogenerado = new CN_Cliente().Registar(cliente, out mensaje);

                if (idusuariogenerado != 0)
                {
                    dataGriwCliente.Rows.Add(new object[]
                    { "",idusuariogenerado,txtDocumento.Text,txtNombre.Text,txtCorreo.Text,txtTelefono.Text,
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
                bool resultado = new CN_Cliente().Editar(cliente, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dataGriwCliente.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["IdCliente"].Value = txtindice.Text;
                    row.Cells["Documento"].Value = txtDocumento.Text;
                    row.Cells["NombreCompleto"].Value = txtNombre.Text;
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
            txtNombre.ReadOnly = true;
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
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            comboEstado.SelectedIndex = 0;
        }

        //EVENTO QUE PINTA EL CHECK EN EL BOTON DEL DATAGRID
        private void dataGriwCliente_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
        private void dataGriwCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGriwCliente.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtId.Text = dataGriwCliente.Rows[indice].Cells["IdCliente"].Value.ToString();
                    txtDocumento.Text = dataGriwCliente.Rows[indice].Cells["Documento"].Value.ToString();
                    txtNombre.Text = dataGriwCliente.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtCorreo.Text = dataGriwCliente.Rows[indice].Cells["Correo"].Value.ToString();
                    txtTelefono.Text = dataGriwCliente.Rows[indice].Cells["Telefono"].Value.ToString();

                    foreach (OpcionCombo item in comboEstado.Items)
                    {
                        if (Convert.ToInt32(item.Valor) == Convert.ToInt32(dataGriwCliente.Rows[indice].Cells["EstadoValor"].Value))
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
                if (MessageBox.Show("¿Desea eliminar el cliente", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;
                    Cliente cliente = new Cliente()
                    {
                        IdCliente = Convert.ToInt32(txtId.Text)
                    };

                    bool respuesta = new CN_Cliente().Eliminar(cliente, out mensaje);

                    if (respuesta)
                    {
                        dataGriwCliente.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
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
            string columnaFiltro = ((OpcionCombo)comboBusqueda.SelectedItem).Valor.ToString();

            if (dataGriwCliente.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGriwCliente.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;

                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            foreach (DataGridViewRow row in dataGriwCliente.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtNombre.ReadOnly = false;
            txtDocumento.ReadOnly = false;
            txtCorreo.ReadOnly = false;
            txtTelefono.ReadOnly = false;
        }
    }
}
