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
            this.masterPersonasComboBox = new System.Windows.Forms.ComboBox();
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
            this.comboBoxPersonaje1Sociopolitica = new System.Windows.Forms.ComboBox();
            this.comboBoxPersonaje2Sociopolitica = new System.Windows.Forms.ComboBox();
            this.comboBoxTipoRelacionSociopolitica = new System.Windows.Forms.ComboBox();
            this.textBoxFechaInicioSociopolitica = new System.Windows.Forms.TextBox();
            this.textBoxFechaFinSociopolitica = new System.Windows.Forms.TextBox();
            this.comboBoxRelacionesSociopoliticas = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxPersonajeInstitucion = new System.Windows.Forms.ComboBox();
            this.comboBoxInstitucion = new System.Windows.Forms.ComboBox();
            this.comboBoxTipoRelacionInstitucion = new System.Windows.Forms.ComboBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.addInstitucionRelation = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // masterPersonasComboBox
            // 
            this.masterPersonasComboBox.FormattingEnabled = true;
            this.masterPersonasComboBox.Location = new System.Drawing.Point(38, 55);
            this.masterPersonasComboBox.Name = "masterPersonasComboBox";
            this.masterPersonasComboBox.Size = new System.Drawing.Size(121, 21);
            this.masterPersonasComboBox.TabIndex = 0;
            this.masterPersonasComboBox.SelectedIndexChanged += new System.EventHandler(this.masterPersonasComboBox_selectedIndexChanged);
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
            this.comboBoxPersonaje1.Location = new System.Drawing.Point(284, 80);
            this.comboBoxPersonaje1.Name = "comboBoxPersonaje1";
            this.comboBoxPersonaje1.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPersonaje1.TabIndex = 9;
            this.comboBoxPersonaje1.SelectedIndexChanged += new System.EventHandler(this.comboBoxPersonaje1_SelectedIndexChanged);
            // 
            // comboBoxPersonaje2
            // 
            this.comboBoxPersonaje2.FormattingEnabled = true;
            this.comboBoxPersonaje2.Location = new System.Drawing.Point(284, 110);
            this.comboBoxPersonaje2.Name = "comboBoxPersonaje2";
            this.comboBoxPersonaje2.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPersonaje2.TabIndex = 10;
            // 
            // comboBoxTipoRelacion
            // 
            this.comboBoxTipoRelacion.FormattingEnabled = true;
            this.comboBoxTipoRelacion.Location = new System.Drawing.Point(284, 140);
            this.comboBoxTipoRelacion.Name = "comboBoxTipoRelacion";
            this.comboBoxTipoRelacion.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTipoRelacion.TabIndex = 11;
            this.comboBoxTipoRelacion.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoRelacion_SelectedIndexChanged);
            // 
            // addRelationButton
            // 
            this.addRelationButton.Location = new System.Drawing.Point(272, 224);
            this.addRelationButton.Name = "addRelationButton";
            this.addRelationButton.Size = new System.Drawing.Size(147, 23);
            this.addRelationButton.TabIndex = 14;
            this.addRelationButton.Text = "Agregar Parentesco";
            this.addRelationButton.UseVisualStyleBackColor = true;
            this.addRelationButton.Click += new System.EventHandler(this.addRelationButton_Click);
            // 
            // textBoxFechaInicio
            // 
            this.textBoxFechaInicio.Location = new System.Drawing.Point(284, 167);
            this.textBoxFechaInicio.Name = "textBoxFechaInicio";
            this.textBoxFechaInicio.Size = new System.Drawing.Size(121, 20);
            this.textBoxFechaInicio.TabIndex = 15;
            this.textBoxFechaInicio.Visible = false;
            // 
            // textBoxFechaFin
            // 
            this.textBoxFechaFin.Location = new System.Drawing.Point(284, 193);
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
            this.label2.Location = new System.Drawing.Point(281, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Parentescos";
            // 
            // comboBoxParentescos
            // 
            this.comboBoxParentescos.FormattingEnabled = true;
            this.comboBoxParentescos.Location = new System.Drawing.Point(284, 255);
            this.comboBoxParentescos.Name = "comboBoxParentescos";
            this.comboBoxParentescos.Size = new System.Drawing.Size(121, 21);
            this.comboBoxParentescos.TabIndex = 1;
            this.comboBoxParentescos.Visible = false;
            // 
            // comboBoxPersonaje1Sociopolitica
            // 
            this.comboBoxPersonaje1Sociopolitica.FormattingEnabled = true;
            this.comboBoxPersonaje1Sociopolitica.Location = new System.Drawing.Point(492, 80);
            this.comboBoxPersonaje1Sociopolitica.Name = "comboBoxPersonaje1Sociopolitica";
            this.comboBoxPersonaje1Sociopolitica.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPersonaje1Sociopolitica.TabIndex = 19;
            this.comboBoxPersonaje1Sociopolitica.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBoxPersonaje2Sociopolitica
            // 
            this.comboBoxPersonaje2Sociopolitica.FormattingEnabled = true;
            this.comboBoxPersonaje2Sociopolitica.Location = new System.Drawing.Point(492, 108);
            this.comboBoxPersonaje2Sociopolitica.Name = "comboBoxPersonaje2Sociopolitica";
            this.comboBoxPersonaje2Sociopolitica.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPersonaje2Sociopolitica.TabIndex = 20;
            // 
            // comboBoxTipoRelacionSociopolitica
            // 
            this.comboBoxTipoRelacionSociopolitica.FormattingEnabled = true;
            this.comboBoxTipoRelacionSociopolitica.Location = new System.Drawing.Point(492, 136);
            this.comboBoxTipoRelacionSociopolitica.Name = "comboBoxTipoRelacionSociopolitica";
            this.comboBoxTipoRelacionSociopolitica.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTipoRelacionSociopolitica.TabIndex = 21;
            // 
            // textBoxFechaInicioSociopolitica
            // 
            this.textBoxFechaInicioSociopolitica.Location = new System.Drawing.Point(492, 164);
            this.textBoxFechaInicioSociopolitica.Name = "textBoxFechaInicioSociopolitica";
            this.textBoxFechaInicioSociopolitica.Size = new System.Drawing.Size(121, 20);
            this.textBoxFechaInicioSociopolitica.TabIndex = 22;
            // 
            // textBoxFechaFinSociopolitica
            // 
            this.textBoxFechaFinSociopolitica.Location = new System.Drawing.Point(492, 191);
            this.textBoxFechaFinSociopolitica.Name = "textBoxFechaFinSociopolitica";
            this.textBoxFechaFinSociopolitica.Size = new System.Drawing.Size(121, 20);
            this.textBoxFechaFinSociopolitica.TabIndex = 23;
            // 
            // comboBoxRelacionesSociopoliticas
            // 
            this.comboBoxRelacionesSociopoliticas.FormattingEnabled = true;
            this.comboBoxRelacionesSociopoliticas.Location = new System.Drawing.Point(492, 255);
            this.comboBoxRelacionesSociopoliticas.Name = "comboBoxRelacionesSociopoliticas";
            this.comboBoxRelacionesSociopoliticas.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRelacionesSociopoliticas.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(481, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 29);
            this.button1.TabIndex = 25;
            this.button1.Text = "Añadir relación social";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(492, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Relaciones personales";
            // 
            // comboBoxPersonajeInstitucion
            // 
            this.comboBoxPersonajeInstitucion.FormattingEnabled = true;
            this.comboBoxPersonajeInstitucion.Location = new System.Drawing.Point(670, 82);
            this.comboBoxPersonajeInstitucion.Name = "comboBoxPersonajeInstitucion";
            this.comboBoxPersonajeInstitucion.Size = new System.Drawing.Size(131, 21);
            this.comboBoxPersonajeInstitucion.TabIndex = 27;
            // 
            // comboBoxInstitucion
            // 
            this.comboBoxInstitucion.FormattingEnabled = true;
            this.comboBoxInstitucion.Location = new System.Drawing.Point(670, 109);
            this.comboBoxInstitucion.Name = "comboBoxInstitucion";
            this.comboBoxInstitucion.Size = new System.Drawing.Size(131, 21);
            this.comboBoxInstitucion.TabIndex = 28;
            // 
            // comboBoxTipoRelacionInstitucion
            // 
            this.comboBoxTipoRelacionInstitucion.FormattingEnabled = true;
            this.comboBoxTipoRelacionInstitucion.Location = new System.Drawing.Point(670, 136);
            this.comboBoxTipoRelacionInstitucion.Name = "comboBoxTipoRelacionInstitucion";
            this.comboBoxTipoRelacionInstitucion.Size = new System.Drawing.Size(131, 21);
            this.comboBoxTipoRelacionInstitucion.TabIndex = 29;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(670, 163);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(131, 20);
            this.textBox7.TabIndex = 30;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(670, 189);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(131, 20);
            this.textBox8.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 352);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Instituciones";
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(670, 255);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(128, 21);
            this.comboBox5.TabIndex = 33;
            // 
            // addInstitucionRelation
            // 
            this.addInstitucionRelation.Location = new System.Drawing.Point(669, 219);
            this.addInstitucionRelation.Name = "addInstitucionRelation";
            this.addInstitucionRelation.Size = new System.Drawing.Size(128, 28);
            this.addInstitucionRelation.TabIndex = 34;
            this.addInstitucionRelation.Text = "Añadir rel. instituciones";
            this.addInstitucionRelation.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(667, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Rel. con Instituciones";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.addInstitucionRelation);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.comboBoxTipoRelacionInstitucion);
            this.Controls.Add(this.comboBoxInstitucion);
            this.Controls.Add(this.comboBoxPersonajeInstitucion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxRelacionesSociopoliticas);
            this.Controls.Add(this.textBoxFechaFinSociopolitica);
            this.Controls.Add(this.textBoxFechaInicioSociopolitica);
            this.Controls.Add(this.comboBoxTipoRelacionSociopolitica);
            this.Controls.Add(this.comboBoxPersonaje2Sociopolitica);
            this.Controls.Add(this.comboBoxPersonaje1Sociopolitica);
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
            this.Controls.Add(this.masterPersonasComboBox);
            this.Controls.Add(this.comboBoxParentescos);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ComboBox masterPersonasComboBox;
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
        private System.Windows.Forms.ComboBox comboBoxPersonaje1Sociopolitica;
        private System.Windows.Forms.ComboBox comboBoxPersonaje2Sociopolitica;
        private System.Windows.Forms.ComboBox comboBoxTipoRelacionSociopolitica;
        private System.Windows.Forms.TextBox textBoxFechaInicioSociopolitica;
        private System.Windows.Forms.TextBox textBoxFechaFinSociopolitica;
        private System.Windows.Forms.ComboBox comboBoxRelacionesSociopoliticas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxPersonajeInstitucion;
        private System.Windows.Forms.ComboBox comboBoxInstitucion;
        private System.Windows.Forms.ComboBox comboBoxTipoRelacionInstitucion;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Button addInstitucionRelation;
        private System.Windows.Forms.Label label5;
    }
}
