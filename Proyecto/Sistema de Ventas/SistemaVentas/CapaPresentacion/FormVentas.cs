using Capa_Negocio;
using CapaEntidad;
using CapaPresentacion.Modales;
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
    public partial class FormVentas : Form
    {
        public FormVentas()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (var modal = new ModalClientes())
            {
                var resul = modal.ShowDialog();

                if (resul == DialogResult.OK)
                {
                    txtIdClient.Text = modal.cliente.IdCliente.ToString();
                    txtNombre.Text = modal.cliente.NombreCompleto.ToString();
                    txtDocumentoPro.Text = modal.cliente.Documento.ToString();
                }
            }
        }

        private void FormVentas_Load(object sender, EventArgs e)
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

        private void BuscarProducto_Click(object sender, EventArgs e)
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
    }
}
