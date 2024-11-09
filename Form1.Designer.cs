namespace CuartoEM
{
    partial class Form1
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.comboBoxPersonaje1 = new System.Windows.Forms.ComboBox();
            this.comboBoxPersonaje2 = new System.Windows.Forms.ComboBox();
            this.comboBoxTipoRelacion = new System.Windows.Forms.ComboBox();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFin = new System.Windows.Forms.DateTimePicker();
            this.addRelationButton = new System.Windows.Forms.Button();
            this.textBoxFechaInicio = new System.Windows.Forms.TextBox();
            this.textBoxFechaFin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(140, 70);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(390, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(390, 106);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(390, 135);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(390, 164);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 4;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(390, 193);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 5;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(390, 222);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 6;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(390, 251);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(200, 100);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(390, 370);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 23);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "Agregar";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // comboBoxPersonaje1
            // 
            this.comboBoxPersonaje1.FormattingEnabled = true;
            this.comboBoxPersonaje1.Location = new System.Drawing.Point(140, 120);
            this.comboBoxPersonaje1.Name = "comboBoxPersonaje1";
            this.comboBoxPersonaje1.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPersonaje1.TabIndex = 9;
            // 
            // comboBoxPersonaje2
            // 
            this.comboBoxPersonaje2.FormattingEnabled = true;
            this.comboBoxPersonaje2.Location = new System.Drawing.Point(140, 150);
            this.comboBoxPersonaje2.Name = "comboBoxPersonaje2";
            this.comboBoxPersonaje2.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPersonaje2.TabIndex = 10;
            // 
            // comboBoxTipoRelacion
            // 
            this.comboBoxTipoRelacion.FormattingEnabled = true;
            this.comboBoxTipoRelacion.Location = new System.Drawing.Point(140, 180);
            this.comboBoxTipoRelacion.Name = "comboBoxTipoRelacion";
            this.comboBoxTipoRelacion.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTipoRelacion.TabIndex = 11;
            this.comboBoxTipoRelacion.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoRelacion_SelectedIndexChanged);
            // 
            // dateTimePickerInicio
            // 
            this.dateTimePickerInicio.Location = new System.Drawing.Point(140, 210);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerInicio.TabIndex = 12;
            this.dateTimePickerInicio.Visible = false;
            // 
            // dateTimePickerFin
            // 
            this.dateTimePickerFin.Location = new System.Drawing.Point(140, 240);
            this.dateTimePickerFin.Name = "dateTimePickerFin";
            this.dateTimePickerFin.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFin.TabIndex = 13;
            this.dateTimePickerFin.Visible = false;
            // 
            // addRelationButton
            // 
            this.addRelationButton.Location = new System.Drawing.Point(140, 270);
            this.addRelationButton.Name = "addRelationButton";
            this.addRelationButton.Size = new System.Drawing.Size(100, 23);
            this.addRelationButton.TabIndex = 14;
            this.addRelationButton.Text = "Agregar Relación";
            this.addRelationButton.UseVisualStyleBackColor = true;
            this.addRelationButton.Click += new System.EventHandler(this.addRelationButton_Click);
            // 
            // textBoxFechaInicio
            // 
            this.textBoxFechaInicio.Location = new System.Drawing.Point(140, 305);
            this.textBoxFechaInicio.Name = "textBoxFechaInicio";
            this.textBoxFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.textBoxFechaInicio.TabIndex = 15;
            this.textBoxFechaInicio.Visible = false;
            // 
            // textBoxFechaFin
            // 
            this.textBoxFechaFin.Location = new System.Drawing.Point(140, 331);
            this.textBoxFechaFin.Name = "textBoxFechaFin";
            this.textBoxFechaFin.Size = new System.Drawing.Size(200, 20);
            this.textBoxFechaFin.TabIndex = 16;
            this.textBoxFechaFin.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxFechaFin);
            this.Controls.Add(this.textBoxFechaInicio);
            this.Controls.Add(this.addRelationButton);
            this.Controls.Add(this.dateTimePickerFin);
            this.Controls.Add(this.dateTimePickerInicio);
            this.Controls.Add(this.comboBoxTipoRelacion);
            this.Controls.Add(this.comboBoxPersonaje2);
            this.Controls.Add(this.comboBoxPersonaje1);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ComboBox comboBoxPersonaje1;
        private System.Windows.Forms.ComboBox comboBoxPersonaje2;
        private System.Windows.Forms.ComboBox comboBoxTipoRelacion;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerFin;
        private System.Windows.Forms.Button addRelationButton;
        private System.Windows.Forms.TextBox textBoxFechaInicio;
        private System.Windows.Forms.TextBox textBoxFechaFin;
    }
}
