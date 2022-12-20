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

namespace CapaPresentacion.Modales
{
    public partial class ModalProductos : Form
    {
        public Producto producto { get; set; }

        public ModalProductos()
        {
            InitializeComponent();
        }

        private void ModalProductos_Load(object sender, EventArgs e)
        {

            //LLENAR EL COMBOBOX DE BUSQUEDA CON EL NOMBRE DE LAS FILAS VISIBLES
            foreach (DataGridViewColumn columna in dataGriwProducto.Columns)
            {
                if (columna.Visible == true )
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
                {    item.IdProducto,
                     item.Codigo,
                     item.Nombre,
                     item.ObjCategoria.Descripcion,
                     item.Stock,
                     item.PrecioCompra,
                     item.PrecioVenta
                });
            }
        }

        private void dataGriwProducto_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;

            if (iRow >= 0 && iColum > 0)
            {
                producto = new Producto()
                {
                    IdProducto = Convert.ToInt32(dataGriwProducto.Rows[iRow].Cells["IdProducto"].Value),
                    Codigo = dataGriwProducto.Rows[iRow].Cells["Codigo"].Value.ToString(),
                    Nombre = dataGriwProducto.Rows[iRow].Cells["Nombre"].Value.ToString(),
                    Stock = Convert.ToInt32(dataGriwProducto.Rows[iRow].Cells["Stock"].Value),
                    PrecioVenta = Convert.ToDecimal(dataGriwProducto.Rows[iRow].Cells["Stock"].Value),
                    PrecioCompra = Convert.ToDecimal(dataGriwProducto.Rows[iRow].Cells["Stock"].Value),
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
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
    }
}
