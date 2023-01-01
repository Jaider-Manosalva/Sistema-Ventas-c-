﻿namespace CapaPresentacion
{
    partial class FormVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboTipoDocumento = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtIdClient = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDocumentoPro = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCantidad = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPrcioVenta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.txtIdProduc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BuscarProducto = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodigoProd = new System.Windows.Forms.TextBox();
            this.btnRegistar = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotalPagar = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPagaCon = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrcioCom = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(15, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(1449, 610);
            this.label10.TabIndex = 80;
            this.label10.Text = "Registrar Ventas";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ComboTipoDocumento);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFecha);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(67, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(601, 108);
            this.groupBox1.TabIndex = 81;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Informacion Compra ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 16);
            this.label2.TabIndex = 81;
            this.label2.Text = "Tipo Documento :";
            // 
            // ComboTipoDocumento
            // 
            this.ComboTipoDocumento.FormattingEnabled = true;
            this.ComboTipoDocumento.Location = new System.Drawing.Point(276, 57);
            this.ComboTipoDocumento.Name = "ComboTipoDocumento";
            this.ComboTipoDocumento.Size = new System.Drawing.Size(226, 24);
            this.ComboTipoDocumento.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha :";
            // 
            // txtFecha
            // 
            this.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFecha.Location = new System.Drawing.Point(18, 58);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(238, 22);
            this.txtFecha.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.txtIdClient);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtDocumentoPro);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Location = new System.Drawing.Point(699, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(685, 108);
            this.groupBox2.TabIndex = 84;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Informacion Clientes";
            // 
            // txtIdClient
            // 
            this.txtIdClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdClient.Location = new System.Drawing.Point(491, 21);
            this.txtIdClient.Name = "txtIdClient";
            this.txtIdClient.Size = new System.Drawing.Size(36, 22);
            this.txtIdClient.TabIndex = 87;
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Location = new System.Drawing.Point(308, 58);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(219, 22);
            this.txtNombre.TabIndex = 86;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Silver;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscar.ForeColor = System.Drawing.Color.Silver;
            this.btnBuscar.Image = global::CapaPresentacion.Properties.Resources.buscar;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(238, 52);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(39, 34);
            this.btnBuscar.TabIndex = 85;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(305, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 81;
            this.label3.Text = "Nombre :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Numero Documento :";
            // 
            // txtDocumentoPro
            // 
            this.txtDocumentoPro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocumentoPro.Location = new System.Drawing.Point(18, 58);
            this.txtDocumentoPro.Name = "txtDocumentoPro";
            this.txtDocumentoPro.Size = new System.Drawing.Size(214, 22);
            this.txtDocumentoPro.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtCantidad);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtPrcioVenta);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtPrcioCom);
            this.groupBox3.Controls.Add(this.txtProducto);
            this.groupBox3.Controls.Add(this.txtIdProduc);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.BuscarProducto);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtCodigoProd);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox3.Location = new System.Drawing.Point(67, 195);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1182, 124);
            this.groupBox3.TabIndex = 85;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Informacion de Producto ";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(870, 72);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(61, 22);
            this.txtCantidad.TabIndex = 94;
            this.txtCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(662, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 16);
            this.label8.TabIndex = 93;
            this.label8.Text = "Precio :";
            // 
            // txtPrcioVenta
            // 
            this.txtPrcioVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrcioVenta.Location = new System.Drawing.Point(665, 72);
            this.txtPrcioVenta.Name = "txtPrcioVenta";
            this.txtPrcioVenta.Size = new System.Drawing.Size(142, 22);
            this.txtPrcioVenta.TabIndex = 92;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(867, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 91;
            this.label7.Text = "Cantidad :";
            // 
            // txtProducto
            // 
            this.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProducto.Location = new System.Drawing.Point(215, 72);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(364, 22);
            this.txtProducto.TabIndex = 89;
            // 
            // txtIdProduc
            // 
            this.txtIdProduc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdProduc.Location = new System.Drawing.Point(119, 38);
            this.txtIdProduc.Name = "txtIdProduc";
            this.txtIdProduc.Size = new System.Drawing.Size(36, 22);
            this.txtIdProduc.TabIndex = 89;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 88;
            this.label5.Text = "Producto :";
            // 
            // BuscarProducto
            // 
            this.BuscarProducto.BackColor = System.Drawing.Color.Silver;
            this.BuscarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BuscarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BuscarProducto.ForeColor = System.Drawing.Color.Silver;
            this.BuscarProducto.Image = global::CapaPresentacion.Properties.Resources.buscar;
            this.BuscarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BuscarProducto.Location = new System.Drawing.Point(161, 65);
            this.BuscarProducto.Name = "BuscarProducto";
            this.BuscarProducto.Size = new System.Drawing.Size(39, 34);
            this.BuscarProducto.TabIndex = 88;
            this.BuscarProducto.UseVisualStyleBackColor = false;
            this.BuscarProducto.Click += new System.EventHandler(this.BuscarProducto_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Cod. Producto:";
            // 
            // txtCodigoProd
            // 
            this.txtCodigoProd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoProd.Location = new System.Drawing.Point(13, 72);
            this.txtCodigoProd.Name = "txtCodigoProd";
            this.txtCodigoProd.Size = new System.Drawing.Size(142, 22);
            this.txtCodigoProd.TabIndex = 0;
            this.txtCodigoProd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProd_KeyDown);
            // 
            // btnRegistar
            // 
            this.btnRegistar.BackColor = System.Drawing.Color.IndianRed;
            this.btnRegistar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistar.ForeColor = System.Drawing.Color.White;
            this.btnRegistar.Location = new System.Drawing.Point(1281, 565);
            this.btnRegistar.Name = "btnRegistar";
            this.btnRegistar.Size = new System.Drawing.Size(133, 36);
            this.btnRegistar.TabIndex = 102;
            this.btnRegistar.Text = "Registrar";
            this.btnRegistar.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(1278, 507);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 16);
            this.label11.TabIndex = 101;
            this.label11.Text = "Total A pagar:";
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalPagar.Location = new System.Drawing.Point(1281, 526);
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.Size = new System.Drawing.Size(133, 22);
            this.txtTotalPagar.TabIndex = 100;
            this.txtTotalPagar.Text = "0";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.LightGreen;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(1281, 204);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(103, 115);
            this.btnAgregar.TabIndex = 99;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdProducto,
            this.Producto,
            this.PrecioCompra,
            this.PrecioVenta,
            this.Cantidad,
            this.SubTotal,
            this.btnEliminar});
            this.dataGridView1.Location = new System.Drawing.Point(67, 330);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1185, 274);
            this.dataGridView1.TabIndex = 103;
            // 
            // IdProducto
            // 
            this.IdProducto.HeaderText = "IdProducto";
            this.IdProducto.MinimumWidth = 6;
            this.IdProducto.Name = "IdProducto";
            this.IdProducto.ReadOnly = true;
            this.IdProducto.Visible = false;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.MinimumWidth = 6;
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            // 
            // PrecioCompra
            // 
            this.PrecioCompra.HeaderText = "Precio";
            this.PrecioCompra.MinimumWidth = 6;
            this.PrecioCompra.Name = "PrecioCompra";
            this.PrecioCompra.ReadOnly = true;
            // 
            // PrecioVenta
            // 
            this.PrecioVenta.HeaderText = "Precio Venta";
            this.PrecioVenta.MinimumWidth = 6;
            this.PrecioVenta.Name = "PrecioVenta";
            this.PrecioVenta.ReadOnly = true;
            this.PrecioVenta.Visible = false;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // SubTotal
            // 
            this.SubTotal.HeaderText = "SubTotal";
            this.SubTotal.MinimumWidth = 6;
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.HeaderText = "";
            this.btnEliminar.MinimumWidth = 6;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ReadOnly = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(1278, 358);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 16);
            this.label12.TabIndex = 105;
            this.label12.Text = "Paga con :";
            // 
            // txtPagaCon
            // 
            this.txtPagaCon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPagaCon.Location = new System.Drawing.Point(1281, 377);
            this.txtPagaCon.Name = "txtPagaCon";
            this.txtPagaCon.Size = new System.Drawing.Size(133, 22);
            this.txtPagaCon.TabIndex = 104;
            this.txtPagaCon.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(1278, 429);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 16);
            this.label13.TabIndex = 107;
            this.label13.Text = "Cambio :";
            // 
            // txtCambio
            // 
            this.txtCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCambio.Location = new System.Drawing.Point(1281, 448);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.Size = new System.Drawing.Size(133, 22);
            this.txtCambio.TabIndex = 106;
            this.txtCambio.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1001, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 16);
            this.label9.TabIndex = 95;
            this.label9.Text = "Descuento :";
            // 
            // txtPrcioCom
            // 
            this.txtPrcioCom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrcioCom.Location = new System.Drawing.Point(1004, 72);
            this.txtPrcioCom.Name = "txtPrcioCom";
            this.txtPrcioCom.Size = new System.Drawing.Size(142, 22);
            this.txtPrcioCom.TabIndex = 90;
            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 638);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtCambio);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPagaCon);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnRegistar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTotalPagar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label10);
            this.Name = "FormVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormVentas";
            this.Load += new System.EventHandler(this.FormVentas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboTipoDocumento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtIdClient;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDocumentoPro;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown txtCantidad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPrcioVenta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.TextBox txtIdProduc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BuscarProducto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodigoProd;
        private System.Windows.Forms.Button btnRegistar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTotalPagar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.DataGridViewButtonColumn btnEliminar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPagaCon;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPrcioCom;
    }
}