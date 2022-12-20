using Capa_Negocio;
using CapaEntidad;
using CapaPresentacion.Utilidades;
using ClosedXML.Excel;
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
    public partial class FormProducto : Form
    {
        public FormProducto()
        {
            InitializeComponent();
        }

        private void FormProducto_Load(object sender, EventArgs e)
        {
            //LLENAR EL COMBOBOX DE ESTADO CON SUS ITEMS CORRESPONDIENTES
            comboEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            comboEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            comboEstado.DisplayMember = "Texto";
            comboEstado.ValueMember = "Valor";
            comboEstado.SelectedIndex = 0;

            //LLENAR EL COMBOBOX DE CATEGORIAS CON SUS ITEMS CORREPONDIENTES DESDE LA LISTA CATEGORIA QUE SE LLENA CON LA DB
            List<Categoria> listaCategoria = new CN_Categoria().Lista();
            foreach (Categoria item in listaCategoria)
            {
                comboCategoria.Items.Add(new OpcionCombo() { Valor = item.IdCategoria, Texto = item.Descripcion });
            }
            comboCategoria.DisplayMember = "Texto";
            comboCategoria.ValueMember = "Valor";
            comboCategoria.SelectedIndex = 0;

            //LLENAR EL COMBOBOX DE BUSQUEDA CON EL NOMBRE DE LAS FILAS VISIBLES
            foreach (DataGridViewColumn columna in dataGriwProducto.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    comboBusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            comboBusqueda.DisplayMember = "Texto";
            comboBusqueda.ValueMember = "Valor";
            comboBusqueda.SelectedIndex = 0;

            //MOSTRAR TODOS LOS PRODUCTOS
            List<Producto> lista = new CN_Producto().Lista();
            foreach (Producto item in lista)
            {
                dataGriwProducto.Rows.Add(new object[]
                { "",item.IdProducto,item.Codigo,item.Nombre,item.Descripcion,
                     item.ObjCategoria.IdCategoria,
                     item.ObjCategoria.Descripcion,
                     item.Stock,
                     item.PrecioCompra,
                     item.PrecioVenta,
                     item.Estado == true ? "Activo" : "No activo",
                     item.Estado == true ? 1 : 0,
                });
            }
        }
        //EVENTO BOTON GUARDAR, AGREGA DATOS AL DATAGRIDVIEW
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Producto Producto = new Producto()
            {
                IdProducto = Convert.ToInt32(txtId.Text),
                Codigo = txtCodigo.Text,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                ObjCategoria = new Categoria() { IdCategoria = Convert.ToInt32(((OpcionCombo)comboCategoria.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpcionCombo)comboEstado.SelectedItem).Valor) == 1 ? true : false
            };

            if (Producto.IdProducto == 0)
            {
                int idgenerado = new CN_Producto().Registar(Producto, out mensaje);

                if (idgenerado != 0)
                {
                    dataGriwProducto.Rows.Add(new object[]
                    { "",idgenerado,txtCodigo.Text,txtNombre.Text,txtDescripcion.Text,
                    ((OpcionCombo)comboCategoria.SelectedItem).Valor.ToString(),
                    ((OpcionCombo)comboCategoria.SelectedItem).Texto,
                    "0",
                    "0.00",
                    "0.00",
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
                bool resultado = new CN_Producto().Editar(Producto, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dataGriwProducto.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["IdProducto"].Value = txtId.Text;
                    row.Cells["Codigo"].Value = txtCodigo.Text;
                    row.Cells["Nombre"].Value = txtNombre.Text;
                    row.Cells["Descripcion"].Value = txtDescripcion.Text;
                    row.Cells["IdCategoria"].Value = ((OpcionCombo)comboCategoria.SelectedItem).Valor.ToString();
                    row.Cells["Categoria"].Value = ((OpcionCombo)comboCategoria.SelectedItem).Texto.ToString();
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
            txtCodigo.ReadOnly = true;
            txtDescripcion.ReadOnly = true;

        }

        //METODO PARA LIMPIAR LOS TEXTBOX Y REINICIAR EL COMBOBOX DE LLENADO DE DATOS
        private void Clear()
        {
            txtIndice.Text = "-1";
            txtId.Text = "";
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            comboCategoria.SelectedIndex = 0;
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
        private void dataGriwUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGriwProducto.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dataGriwProducto.Rows[indice].Cells["IdProducto"].Value.ToString();
                    txtCodigo.Text = dataGriwProducto.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtNombre.Text = dataGriwProducto.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtDescripcion.Text = dataGriwProducto.Rows[indice].Cells["Descripcion"].Value.ToString();

                    foreach (OpcionCombo item in comboCategoria.Items)
                    {
                        if (Convert.ToInt32(item.Valor) == Convert.ToInt32(dataGriwProducto.Rows[indice].Cells["IdCategoria"].Value))
                        {
                            int indice_combo = comboCategoria.Items.IndexOf(item);
                            comboCategoria.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                    foreach (OpcionCombo item in comboEstado.Items)
                    {
                        if (Convert.ToInt32(item.Valor) == Convert.ToInt32(dataGriwProducto.Rows[indice].Cells["EstadoValor"].Value))
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
            if (Convert.ToInt32(txtIndice.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar el usuario", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Producto Producto = new Producto()
                    {
                        IdProducto = Convert.ToInt32(txtId.Text)
                    };

                    bool respuesta = new CN_Producto().Eliminar(Producto, out mensaje);

                    if (respuesta)
                    {
                        dataGriwProducto.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
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

            if (dataGriwProducto.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGriwProducto.Rows)
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
            foreach (DataGridViewRow row in dataGriwProducto.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtNombre.ReadOnly = false;
            txtCodigo.ReadOnly = false;
            txtDescripcion.ReadOnly = false;
        }

        private void btnDescargarExcel_Click(object sender, EventArgs e)
        {
            if (dataGriwProducto.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();

                foreach (DataGridViewColumn item in dataGriwProducto.Columns)
                {
                    if (item.HeaderText != "" && item.Visible)
                    {
                        dt.Columns.Add(item.HeaderText, typeof(string));
                    }
                }

                foreach (DataGridViewRow item in dataGriwProducto.Rows)
                {
                    if (item.Visible)
                    {
                        dt.Rows.Add(new object[]
                        {
                            item.Cells[2].Value.ToString(),
                            item.Cells[3].Value.ToString(),
                            item.Cells[4].Value.ToString(),
                            item.Cells[6].Value.ToString(),
                            item.Cells[7].Value.ToString(),
                            item.Cells[8].Value.ToString(),
                            item.Cells[9].Value.ToString(),
                            item.Cells[11].Value.ToString(),
                        });
                    }
                }

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = string.Format("ReporteProductos_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                saveFile.Filter = "Excel Files | * .xlsx";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(saveFile.FileName);
                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("No se pudo generar el archivo");
                    }
                }
            }
        }
    }
}
