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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapaPresentacion
{
    public partial class FormCategoria : Form
    {
        public FormCategoria()
        {
            InitializeComponent();
        }

        private void FormCategoria_Load(object sender, EventArgs e)
        {
            //LLENAR EL COMBOBOX DE ESTADO CON SUS ITEMS CORRESPONDIENTES
            comboEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            comboEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            comboEstado.DisplayMember = "Texto";
            comboEstado.ValueMember = "Valor";
            comboEstado.SelectedIndex = 0;

            //LLENAR EL COMBOBOX DE BUSQUEDA CON EL NOMBRE DE LAS FILAS VISIBLES
            foreach (DataGridViewColumn columna in dataGriwCategoria.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    comboBusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            comboBusqueda.DisplayMember = "Texto";
            comboBusqueda.ValueMember = "Valor";
            comboBusqueda.SelectedIndex = 0;

            //MOSTRAR TODOS Las Categorias
            List<Categoria> lista = new CN_Categoria().Lista();
            foreach (Categoria item in lista)
            {
                dataGriwCategoria.Rows.Add(new object[]
                { "",item.IdCategoria,
                     item.Descripcion,
                     item.Estado == true ? 1 : 0,
                     item.Estado == true ? "activo" : "No activo",
                });
            }
        }

        //EVENTO BOTON GUARDAR, AGREGA DATOS AL DATAGRIDVIEW
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Categoria obj = new Categoria()
            {
                IdCategoria = Convert.ToInt32(txtId.Text),
                Descripcion = txtDescripcion.Text,
                Estado = Convert.ToInt32(((OpcionCombo)comboEstado.SelectedItem).Valor) == 1 ? true : false
            };

            if (obj.IdCategoria == 0)
            {
                int idgenerado = new CN_Categoria().Registar(obj, out mensaje);

                if (idgenerado != 0)
                {
                    dataGriwCategoria.Rows.Add(new object[]
                    { "",idgenerado,
                        txtDescripcion.Text,
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
                bool resultado = new CN_Categoria().Editar(obj, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dataGriwCategoria.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["IdCategoria"].Value = txtId.Text;
                    row.Cells["Descripcion"].Value = txtDescripcion.Text;
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)comboEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)comboEstado.SelectedItem).Texto.ToString();
                    Clear();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            txtDescripcion.ReadOnly = true;
        }

        //METODO PARA LIMPIAR LOS TEXTBOX Y REINICIAR EL COMBOBOX DE LLENADO DE DATOS
        private void Clear()
        {
            txtindice.Text = "-1";
            txtId.Text = "";
            txtDescripcion.Text = "";
            comboEstado.SelectedIndex = 0;
        }

        //EVENTO QUE PINTA EL CHECK EN EL BOTON DEL DATAGRID
        private void dataGriwUsuario_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
        private void dataGriwCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGriwCategoria.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtId.Text = dataGriwCategoria.Rows[indice].Cells["IdCategoria"].Value.ToString();
                    txtDescripcion.Text = dataGriwCategoria.Rows[indice].Cells["Descripcion"].Value.ToString();

                    foreach (OpcionCombo item in comboEstado.Items)
                    {
                        if (Convert.ToInt32(item.Valor) == Convert.ToInt32(dataGriwCategoria.Rows[indice].Cells["EstadoValor"].Value))
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
                if (MessageBox.Show("¿Desea eliminar el usuario", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;
                    Categoria categoria = new Categoria()
                    {
                        IdCategoria = Convert.ToInt32(txtId.Text)
                    };

                    bool respuesta = new CN_Categoria().Eliminar(categoria, out mensaje);

                    if (respuesta)
                    {
                        dataGriwCategoria.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                    }
                    else
                    {
                        MessageBox.Show(mensaje);
                    }
                    Clear();
                }
            }
            txtindice.Text = "0";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)comboBusqueda.SelectedItem).Valor.ToString();

            if (dataGriwCategoria.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGriwCategoria.Rows)
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
            foreach (DataGridViewRow row in dataGriwCategoria.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtDescripcion.ReadOnly = false;
        }
    }
}
