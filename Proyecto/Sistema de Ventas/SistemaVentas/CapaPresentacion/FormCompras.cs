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
using CapaEntidad;
using CapaPresentacion.Utilidades;
using CapaPresentacion.Modales;
using Capa_Negocio;
using DocumentFormat.OpenXml.Wordprocessing;
using Color = System.Drawing.Color;

namespace CapaPresentacion
{
    public partial class FormCompras : Form
    {
        //OBJETOS
        private Usuario _Usuario;

        public FormCompras(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }

        private void FormCompras_Load(object sender, EventArgs e)
        {
            //LLENAR EL COMBOBOX DE TIPO DOCUMENTO CON SUS ITEMS CORRESPONDIENTES
            ComboTipoDocumento.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Factura" });
            ComboTipoDocumento.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Boleta" });
            ComboTipoDocumento.DisplayMember = "Texto";
            ComboTipoDocumento.ValueMember = "Valor";
            ComboTipoDocumento.SelectedIndex = 0;

            //FORMATO DEL TEXTBOX DE FECHA
            txtFecha.Text = DateTime.Now.ToString("dd/mm/yyyy");
        }
        //LLAMAR EL MODAL PROVEEDORES
        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            using (var modal = new ModalProveedores())
            {
                var resul = modal.ShowDialog();

                if (resul == DialogResult.OK)
                {
                    txtIdProvee.Text = modal.proveedor.IdProveedor.ToString();
                    txtRazonSocial.Text = modal.proveedor.RazonSocial.ToString();
                    txtDocumentoPro.Text = modal.proveedor.Documento.ToString();
                }
            }
        }
        //LLAMAR EL MODAL PRODUCTOS
        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (var modal = new ModalProductos())
            {
                var resul = modal.ShowDialog();

                if (resul == DialogResult.OK)
                {
                    txtIdProduc.Text = modal.producto.IdProducto.ToString();
                    txtCodigoProd.Text = modal.producto.Codigo.ToString();
                    txtProducto.Text = modal.producto.Nombre.ToString();
                    txtPrcioCom.Select();
                }
                else
                {
                    txtProducto.Select();
                }
            }
        }
        //BUSCAR EL PRODUTO POR EL CODIGO 
        private void txtCodigoProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Producto obj = new CN_Producto().Lista().Where(p => p.Codigo == txtCodigoProd.Text && p.Estado == true).FirstOrDefault();

                if (obj != null)
                {
                    txtCodigoProd.BackColor = Color.Honeydew;
                    txtIdProduc.Text = obj.IdProducto.ToString();
                    txtCodigoProd.Text = obj.Codigo.ToString();
                    txtProducto.Text = obj.Nombre.ToString();
                    txtPrcioCom.Select();
                }
                else
                {
                    txtCodigoProd.BackColor = Color.MistyRose;
                    txtIdProduc.Text = "0";
                    txtProducto.Text = "";
                }
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal precioCompra = 0;
            decimal precioVenta = 0;
            bool productoExiste = false;

            if (int.Parse(txtIdProduc.Text) == 0)
            {
                MessageBox.Show("Debe Seleccionar un producto", "Mensaje", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            else if(!decimal.TryParse(txtPrcioCom.Text,out precioCompra))
            {
                MessageBox.Show("Precio Compra - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (!decimal.TryParse(txtPrcioVenta.Text, out precioCompra))
            {
                MessageBox.Show("Precio Venta - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == txtIdProduc.Text) 
                {
                    productoExiste = true;
                    break;
                }
            }
            if (!productoExiste)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    txtIdProduc.Text,
                    txtProducto.Text,
                    precioCompra.ToString("0.00"),
                    precioVenta.ToString("0.00"),
                    txtCantidad.Value.ToString(),
                    (txtCantidad.Value * precioCompra).ToString("0.00")
                });
            }
            CalcularTotal();
            limpiarProducto();
            txtCodigoProd.Select();
        }
        //FUNCION PARA LIMPIAR CAMPOS
        private void limpiarProducto()
        {
            txtIdProduc.Text = "0";
            txtCodigoProd.Text = "";
            txtCodigoProd.BackColor = Color.White;
            txtIdProduc.Text = "";
            txtPrcioCom.Text = "";
            txtPrcioVenta.Text = "";
            txtCantidad.Value = 1;
        }
        //FUNCION PARA CALCULAR EL TOTAL EN LA TABLA
        private void CalcularTotal()
        {
            decimal total = 0;
            foreach(DataGridViewRow row in dataGridView1.Rows )
            {
                total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString());
            }
            txtTotalPagar.Text = total.ToString("0.00");
        }
        //PINTA EL CHECK DE ELIMINAR EN EL BOTON ELIMINAR
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            else if (e.ColumnIndex == 6)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var with = Properties.Resources.basura__1_.Width;
                var height = Properties.Resources.basura__1_.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - with) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - height) / 2;

                e.Graphics.DrawImage(Properties.Resources.basura__1_, new Rectangle(x, y, with, height));
                e.Handled = true;
            }
        }
        //ELIMINA UN DATO CUANDO SE ACTIVA EL CHECK
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    dataGridView1.Rows.RemoveAt(indice);
                    CalcularTotal();
                }
            }
        }
        //ASEGURA QUE EL FORMATO DE LA MONEDA ESTE CORRETO EN EL CAMPO COMPRA
        private void txtPrcioCom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else
            {
                if (txtPrcioCom.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                    e.Handled = true;
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                        e.Handled = false;
                    else
                        e.Handled = true;
                }
            }
        }
        //ASEGURA QUE EL FORMATO DE LA MONEDA ESTE CORRETO EN EL CAMPO VENTA
        private void txtPrcioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else
            {
                if (txtPrcioVenta.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                    e.Handled = true;
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                        e.Handled = false;
                    else
                        e.Handled = true;
                }
            }
        }

        private void SiPorcentaje_Click(object sender, EventArgs e)
        {
            if (SiPorcentaje.Checked)
            {
                TxtPorcentaje.Visible = true;
                txtPrcioVenta.ReadOnly = true;
                simbolPor.Visible = true;
                TxtPorcentaje.Value = 0;
                TxtPorcentaje.Select();
            }
            else
            {
                simbolPor.Visible = false;
                TxtPorcentaje.Visible = false;
                txtPrcioVenta.ReadOnly = false;
            }
        }

        private void TxtPorcentaje_ValueChanged(object sender, EventArgs e)
        {
            if (TxtPorcentaje.Value < 0)
                txtPrcioVenta.Text = "";
            else
            {
                double calculo = (Convert.ToDouble(txtPrcioCom.Text) * Convert.ToInt32(TxtPorcentaje.Value) / 100) + Convert.ToDouble(txtPrcioCom.Text);
                txtPrcioVenta.Text = calculo.ToString();
            }
        }
    }
}
