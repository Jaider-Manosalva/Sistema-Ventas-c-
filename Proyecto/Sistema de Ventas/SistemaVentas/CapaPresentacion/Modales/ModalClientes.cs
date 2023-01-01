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
    public partial class ModalClientes : Form
    {
        public Cliente cliente { get; set; }

        public ModalClientes()
        {
            InitializeComponent();
        }

        private void ModalClientes_Load(object sender, EventArgs e)
        {
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
            List<Cliente> lista = new CN_Cliente().Lista();
            foreach (Cliente item in lista)
            {
                dataGriwProveedor.Rows.Add(new object[]
                {item.IdCliente,item.Documento,item.NombreCompleto
                });
            }
        }

        private void dataGriwProveedor_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;

            if (iRow >= 0 && iColum > 0)
            {
                cliente = new Cliente()
                {
                    IdCliente = Convert.ToInt32(dataGriwProveedor.Rows[iRow].Cells["IdCliente"].Value),
                    Documento = dataGriwProveedor.Rows[iRow].Cells["Document"].Value.ToString(),
                    NombreCompleto = dataGriwProveedor.Rows[iRow].Cells["Nombre"].Value.ToString()
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)comboBusqueda.SelectedItem).Valor.ToString();

            if (dataGriwProveedor.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGriwProveedor.Rows)
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
            foreach (DataGridViewRow row in dataGriwProveedor.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
