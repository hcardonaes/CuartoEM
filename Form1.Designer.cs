namespace CuartoEM
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

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
            this.addRelationButton = new System.Windows.Forms.Button();
            this.textBoxFechaInicio = new System.Windows.Forms.TextBox();
            this.textBoxFechaFin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxParentescos = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(38, 55);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(38, 82);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(38, 111);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(38, 140);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(38, 169);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 4;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(38, 198);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 5;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(38, 227);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 6;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(38, 256);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(200, 100);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(38, 375);
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
            this.comboBoxPersonaje1.Location = new System.Drawing.Point(318, 80);
            this.comboBoxPersonaje1.Name = "comboBoxPersonaje1";
            this.comboBoxPersonaje1.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPersonaje1.TabIndex = 9;
            this.comboBoxPersonaje1.SelectedIndexChanged += new System.EventHandler(this.comboBoxPersonaje1_SelectedIndexChanged);
            // 
            // comboBoxPersonaje2
            // 
            this.comboBoxPersonaje2.FormattingEnabled = true;
            this.comboBoxPersonaje2.Location = new System.Drawing.Point(318, 110);
            this.comboBoxPersonaje2.Name = "comboBoxPersonaje2";
            this.comboBoxPersonaje2.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPersonaje2.TabIndex = 10;
            // 
            // comboBoxTipoRelacion
            // 
            this.comboBoxTipoRelacion.FormattingEnabled = true;
            this.comboBoxTipoRelacion.Location = new System.Drawing.Point(318, 140);
            this.comboBoxTipoRelacion.Name = "comboBoxTipoRelacion";
            this.comboBoxTipoRelacion.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTipoRelacion.TabIndex = 11;
            this.comboBoxTipoRelacion.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoRelacion_SelectedIndexChanged);
            // 
            // addRelationButton
            // 
            this.addRelationButton.Location = new System.Drawing.Point(318, 230);
            this.addRelationButton.Name = "addRelationButton";
            this.addRelationButton.Size = new System.Drawing.Size(100, 23);
            this.addRelationButton.TabIndex = 14;
            this.addRelationButton.Text = "Agregar Parentesco";
            this.addRelationButton.UseVisualStyleBackColor = true;
            this.addRelationButton.Click += new System.EventHandler(this.addRelationButton_Click);
            // 
            // textBoxFechaInicio
            // 
            this.textBoxFechaInicio.Location = new System.Drawing.Point(318, 167);
            this.textBoxFechaInicio.Name = "textBoxFechaInicio";
            this.textBoxFechaInicio.Size = new System.Drawing.Size(121, 20);
            this.textBoxFechaInicio.TabIndex = 15;
            this.textBoxFechaInicio.Visible = false;
            // 
            // textBoxFechaFin
            // 
            this.textBoxFechaFin.Location = new System.Drawing.Point(318, 193);
            this.textBoxFechaFin.Name = "textBoxFechaFin";
            this.textBoxFechaFin.Size = new System.Drawing.Size(121, 20);
            this.textBoxFechaFin.TabIndex = 16;
            this.textBoxFechaFin.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Personajes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Parentescos";
            // 
            // comboBoxParentescos
            // 
            this.comboBoxParentescos.FormattingEnabled = true;
            this.comboBoxParentescos.Location = new System.Drawing.Point(318, 259);
            this.comboBoxParentescos.Name = "comboBoxParentescos";
            this.comboBoxParentescos.Size = new System.Drawing.Size(200, 21);
            this.comboBoxParentescos.TabIndex = 1;
            this.comboBoxParentescos.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFechaFin);
            this.Controls.Add(this.textBoxFechaInicio);
            this.Controls.Add(this.addRelationButton);
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
            this.Controls.Add(this.comboBoxParentescos);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

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
        private System.Windows.Forms.Button addRelationButton;
        private System.Windows.Forms.TextBox textBoxFechaInicio;
        private System.Windows.Forms.TextBox textBoxFechaFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxParentescos;
    }
}
