namespace usuarios_admin
{
    partial class UsuariosForm2
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txt_Nombre = new TextBox();
            txt_Tienda = new TextBox();
            txt_Contra = new TextBox();
            txt_Email = new TextBox();
            blb_Nombre = new Label();
            lbl_Tienda = new Label();
            lbl_Contra = new Label();
            lbl_Email = new Label();
            btn_Insertar = new Button();
            dtgv_Base = new DataGridView();
            btn_Modificar = new Button();
            btn_Eliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgv_Base).BeginInit();
            SuspendLayout();
            // 
            // txt_Nombre
            // 
            txt_Nombre.Location = new Point(34, 42);
            txt_Nombre.Name = "txt_Nombre";
            txt_Nombre.Size = new Size(100, 23);
            txt_Nombre.TabIndex = 0;
            // 
            // txt_Tienda
            // 
            txt_Tienda.Location = new Point(149, 42);
            txt_Tienda.Name = "txt_Tienda";
            txt_Tienda.Size = new Size(100, 23);
            txt_Tienda.TabIndex = 1;
            // 
            // txt_Contra
            // 
            txt_Contra.Location = new Point(266, 42);
            txt_Contra.Name = "txt_Contra";
            txt_Contra.Size = new Size(100, 23);
            txt_Contra.TabIndex = 2;
            // 
            // txt_Email
            // 
            txt_Email.Location = new Point(384, 42);
            txt_Email.Name = "txt_Email";
            txt_Email.Size = new Size(100, 23);
            txt_Email.TabIndex = 3;
            // 
            // blb_Nombre
            // 
            blb_Nombre.AutoSize = true;
            blb_Nombre.Location = new Point(34, 24);
            blb_Nombre.Name = "blb_Nombre";
            blb_Nombre.Size = new Size(51, 15);
            blb_Nombre.TabIndex = 4;
            blb_Nombre.Text = "Nombre";
            // 
            // lbl_Tienda
            // 
            lbl_Tienda.AutoSize = true;
            lbl_Tienda.Location = new Point(149, 24);
            lbl_Tienda.Name = "lbl_Tienda";
            lbl_Tienda.Size = new Size(43, 15);
            lbl_Tienda.TabIndex = 5;
            lbl_Tienda.Text = "Tienda";
            // 
            // lbl_Contra
            // 
            lbl_Contra.AutoSize = true;
            lbl_Contra.Location = new Point(266, 24);
            lbl_Contra.Name = "lbl_Contra";
            lbl_Contra.Size = new Size(67, 15);
            lbl_Contra.TabIndex = 6;
            lbl_Contra.Text = "Contraseña";
            // 
            // lbl_Email
            // 
            lbl_Email.AutoSize = true;
            lbl_Email.Location = new Point(384, 24);
            lbl_Email.Name = "lbl_Email";
            lbl_Email.Size = new Size(36, 15);
            lbl_Email.TabIndex = 7;
            lbl_Email.Text = "Email";
            // 
            // btn_Insertar
            // 
            btn_Insertar.Location = new Point(500, 42);
            btn_Insertar.Name = "btn_Insertar";
            btn_Insertar.Size = new Size(75, 23);
            btn_Insertar.TabIndex = 8;
            btn_Insertar.Text = "Insertar";
            btn_Insertar.UseVisualStyleBackColor = true;
            btn_Insertar.Click += btn_Insertar_Click;
            // 
            // dtgv_Base
            // 
            dtgv_Base.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgv_Base.Location = new Point(34, 100);
            dtgv_Base.Name = "dtgv_Base";
            dtgv_Base.Size = new Size(622, 321);
            dtgv_Base.TabIndex = 9;
            dtgv_Base.CellClick += dtgv_Base_CellClick_1;
            // 
            // btn_Modificar
            // 
            btn_Modificar.Location = new Point(581, 42);
            btn_Modificar.Name = "btn_Modificar";
            btn_Modificar.Size = new Size(75, 23);
            btn_Modificar.TabIndex = 10;
            btn_Modificar.Text = "Modificar";
            btn_Modificar.UseVisualStyleBackColor = true;
            btn_Modificar.Click += btn_Modificar_Click;
            // 
            // btn_Eliminar
            // 
            btn_Eliminar.Location = new Point(662, 42);
            btn_Eliminar.Name = "btn_Eliminar";
            btn_Eliminar.Size = new Size(75, 23);
            btn_Eliminar.TabIndex = 11;
            btn_Eliminar.Text = "Eliminar";
            btn_Eliminar.UseVisualStyleBackColor = true;
            btn_Eliminar.Click += btn_Eliminar_Click;
            // 
            // UsuariosForms1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Eliminar);
            Controls.Add(btn_Modificar);
            Controls.Add(dtgv_Base);
            Controls.Add(btn_Insertar);
            Controls.Add(lbl_Email);
            Controls.Add(lbl_Contra);
            Controls.Add(lbl_Tienda);
            Controls.Add(blb_Nombre);
            Controls.Add(txt_Email);
            Controls.Add(txt_Contra);
            Controls.Add(txt_Tienda);
            Controls.Add(txt_Nombre);
            Name = "UsuariosForms1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dtgv_Base).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_Nombre;
        private TextBox txt_Tienda;
        private TextBox txt_Contra;
        private TextBox txt_Email;
        private Label blb_Nombre;
        private Label lbl_Tienda;
        private Label lbl_Contra;
        private Label lbl_Email;
        private Button btn_Insertar;
        private DataGridView dtgv_Base;
        private Button btn_Modificar;
        private Button btn_Eliminar;
    }
}
