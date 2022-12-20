namespace CapaPresentacion
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Contenedor = new System.Windows.Forms.Panel();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.btnUsuarios = new System.Windows.Forms.ToolStripButton();
            this.btnMantenedor = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnCategoria = new System.Windows.Forms.ToolStripMenuItem();
            this.btnProducto = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNegocio = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVentas = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnRegistrar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnverDetalle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCompras = new System.Windows.Forms.ToolStripButton();
            this.btnClientes = new System.Windows.Forms.ToolStripButton();
            this.btnProveedores = new System.Windows.Forms.ToolStripButton();
            this.btnReportes = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAcercaDe = new System.Windows.Forms.ToolStripButton();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Contenedor
            // 
            this.Contenedor.BackColor = System.Drawing.Color.Silver;
            this.Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Contenedor.Location = new System.Drawing.Point(0, 175);
            this.Contenedor.Margin = new System.Windows.Forms.Padding(4);
            this.Contenedor.Name = "Contenedor";
            this.Contenedor.Size = new System.Drawing.Size(1554, 672);
            this.Contenedor.TabIndex = 7;
            // 
            // menu
            // 
            this.menu.AutoSize = false;
            this.menu.BackColor = System.Drawing.Color.White;
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUsuarios,
            this.btnMantenedor,
            this.btnVentas,
            this.btnCompras,
            this.btnClientes,
            this.btnProveedores,
            this.btnReportes,
            this.btnAcercaDe});
            this.menu.Location = new System.Drawing.Point(0, 90);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1554, 85);
            this.menu.TabIndex = 6;
            this.menu.Text = "toolStrip1";
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.AutoSize = false;
            this.btnUsuarios.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.ForeColor = System.Drawing.Color.Black;
            this.btnUsuarios.Image = global::CapaPresentacion.Properties.Resources.usuarios;
            this.btnUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnUsuarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUsuarios.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(90, 60);
            this.btnUsuarios.Tag = "botones";
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnMantenedor
            // 
            this.btnMantenedor.AutoSize = false;
            this.btnMantenedor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCategoria,
            this.btnProducto,
            this.btnNegocio});
            this.btnMantenedor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMantenedor.ForeColor = System.Drawing.Color.Black;
            this.btnMantenedor.Image = global::CapaPresentacion.Properties.Resources.soporte_en_linea;
            this.btnMantenedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMantenedor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMantenedor.Name = "btnMantenedor";
            this.btnMantenedor.Size = new System.Drawing.Size(90, 60);
            this.btnMantenedor.Tag = "botones";
            this.btnMantenedor.Text = "Mantenedor";
            this.btnMantenedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnCategoria
            // 
            this.btnCategoria.Name = "btnCategoria";
            this.btnCategoria.Size = new System.Drawing.Size(155, 26);
            this.btnCategoria.Text = "Categoria";
            this.btnCategoria.Click += new System.EventHandler(this.btnCategoria_Click);
            // 
            // btnProducto
            // 
            this.btnProducto.Name = "btnProducto";
            this.btnProducto.Size = new System.Drawing.Size(155, 26);
            this.btnProducto.Text = "Producto";
            this.btnProducto.Click += new System.EventHandler(this.btnProducto_Click);
            // 
            // btnNegocio
            // 
            this.btnNegocio.Name = "btnNegocio";
            this.btnNegocio.Size = new System.Drawing.Size(155, 26);
            this.btnNegocio.Text = "Negocio";
            this.btnNegocio.Click += new System.EventHandler(this.btnNegocio_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.AutoSize = false;
            this.btnVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRegistrar,
            this.btnverDetalle});
            this.btnVentas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.ForeColor = System.Drawing.Color.Black;
            this.btnVentas.Image = global::CapaPresentacion.Properties.Resources.venta_al_por_mayor__1_;
            this.btnVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnVentas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(90, 60);
            this.btnVentas.Tag = "botones";
            this.btnVentas.Text = "Ventas";
            this.btnVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(163, 26);
            this.btnRegistrar.Text = "Registar";
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnverDetalle
            // 
            this.btnverDetalle.Name = "btnverDetalle";
            this.btnverDetalle.Size = new System.Drawing.Size(163, 26);
            this.btnverDetalle.Text = "Ver Detalle";
            this.btnverDetalle.Click += new System.EventHandler(this.btnverDetalle_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.AutoSize = false;
            this.btnCompras.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompras.ForeColor = System.Drawing.Color.Black;
            this.btnCompras.Image = global::CapaPresentacion.Properties.Resources.orden__1_;
            this.btnCompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCompras.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCompras.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(90, 60);
            this.btnCompras.Tag = "botones";
            this.btnCompras.Text = "Compras";
            this.btnCompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.AutoSize = false;
            this.btnClientes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.Color.Black;
            this.btnClientes.Image = global::CapaPresentacion.Properties.Resources.clasificacion__1_;
            this.btnClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClientes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClientes.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(90, 60);
            this.btnClientes.Tag = "botones";
            this.btnClientes.Text = "Clientes";
            this.btnClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnProveedores
            // 
            this.btnProveedores.AutoSize = false;
            this.btnProveedores.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProveedores.ForeColor = System.Drawing.Color.Black;
            this.btnProveedores.Image = global::CapaPresentacion.Properties.Resources.proveedor__1_;
            this.btnProveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnProveedores.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProveedores.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(90, 60);
            this.btnProveedores.Tag = "botones";
            this.btnProveedores.Text = "Proveedores";
            this.btnProveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.AutoSize = false;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.Color.Black;
            this.btnReportes.Image = global::CapaPresentacion.Properties.Resources.grafico__1_;
            this.btnReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReportes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(90, 60);
            this.btnReportes.Tag = "botones";
            this.btnReportes.Text = "Reportes";
            this.btnReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnAcercaDe
            // 
            this.btnAcercaDe.AutoSize = false;
            this.btnAcercaDe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcercaDe.ForeColor = System.Drawing.Color.Black;
            this.btnAcercaDe.Image = global::CapaPresentacion.Properties.Resources.acerca_de__1_;
            this.btnAcercaDe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAcercaDe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAcercaDe.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.btnAcercaDe.Name = "btnAcercaDe";
            this.btnAcercaDe.Size = new System.Drawing.Size(90, 60);
            this.btnAcercaDe.Tag = "botones";
            this.btnAcercaDe.Text = "Acerca De";
            this.btnAcercaDe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuStrip2
            // 
            this.menuStrip2.AutoSize = false;
            this.menuStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(78)))), ((int)(((byte)(152)))));
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip2.Size = new System.Drawing.Size(1554, 90);
            this.menuStrip2.TabIndex = 5;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(78)))), ((int)(((byte)(152)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 46);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sistema de Ventas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(78)))), ((int)(((byte)(152)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1160, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Usuario : ";
            // 
            // txtUsuario
            // 
            this.txtUsuario.AutoSize = true;
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(78)))), ((int)(((byte)(152)))));
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.Color.White;
            this.txtUsuario.Location = new System.Drawing.Point(1236, 40);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(40, 20);
            this.txtUsuario.TabIndex = 9;
            this.txtUsuario.Text = "jhon";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1554, 847);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Contenedor);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menuStrip2);
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Contenedor;
        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton btnUsuarios;
        private System.Windows.Forms.ToolStripDropDownButton btnMantenedor;
        private System.Windows.Forms.ToolStripDropDownButton btnVentas;
        private System.Windows.Forms.ToolStripButton btnCompras;
        private System.Windows.Forms.ToolStripButton btnClientes;
        private System.Windows.Forms.ToolStripButton btnProveedores;
        private System.Windows.Forms.ToolStripDropDownButton btnReportes;
        private System.Windows.Forms.ToolStripButton btnAcercaDe;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtUsuario;
        private System.Windows.Forms.ToolStripMenuItem btnCategoria;
        private System.Windows.Forms.ToolStripMenuItem btnProducto;
        private System.Windows.Forms.ToolStripMenuItem btnRegistrar;
        private System.Windows.Forms.ToolStripMenuItem btnverDetalle;
        private System.Windows.Forms.ToolStripMenuItem btnNegocio;
    }
}

