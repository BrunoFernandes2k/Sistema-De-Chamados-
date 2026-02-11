namespace Empresa.UI.Windows
{
    partial class AberturaForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AberturaForm));
            this.prioridadeCheckBox = new System.Windows.Forms.CheckBox();
            this.descricaoRichTextBox = new System.Windows.Forms.RichTextBox();
            this.assuntoTextBox = new System.Windows.Forms.TextBox();
            this.setorComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataAberturaLabel = new System.Windows.Forms.Label();
            this.relogioTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.gravarChamadoButton = new System.Windows.Forms.Button();
            this.voltarButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // prioridadeCheckBox
            // 
            this.prioridadeCheckBox.AutoSize = true;
            this.prioridadeCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.prioridadeCheckBox.ForeColor = System.Drawing.Color.White;
            this.prioridadeCheckBox.Location = new System.Drawing.Point(31, 302);
            this.prioridadeCheckBox.Name = "prioridadeCheckBox";
            this.prioridadeCheckBox.Size = new System.Drawing.Size(73, 17);
            this.prioridadeCheckBox.TabIndex = 22;
            this.prioridadeCheckBox.Text = "Prioridade";
            this.prioridadeCheckBox.UseVisualStyleBackColor = false;
            this.prioridadeCheckBox.CheckedChanged += new System.EventHandler(this.prioridadeCheckBox_CheckedChanged);
            // 
            // descricaoRichTextBox
            // 
            this.descricaoRichTextBox.Location = new System.Drawing.Point(31, 179);
            this.descricaoRichTextBox.Name = "descricaoRichTextBox";
            this.descricaoRichTextBox.Size = new System.Drawing.Size(343, 101);
            this.descricaoRichTextBox.TabIndex = 21;
            this.descricaoRichTextBox.Text = "";
            // 
            // assuntoTextBox
            // 
            this.assuntoTextBox.Location = new System.Drawing.Point(31, 128);
            this.assuntoTextBox.Name = "assuntoTextBox";
            this.assuntoTextBox.Size = new System.Drawing.Size(343, 20);
            this.assuntoTextBox.TabIndex = 20;
            // 
            // setorComboBox
            // 
            this.setorComboBox.FormattingEnabled = true;
            this.setorComboBox.Items.AddRange(new object[] {
            "Vendas",
            "RH",
            "Conferencia",
            "Secretaria"});
            this.setorComboBox.Location = new System.Drawing.Point(31, 79);
            this.setorComboBox.Name = "setorComboBox";
            this.setorComboBox.Size = new System.Drawing.Size(191, 21);
            this.setorComboBox.TabIndex = 17;
            this.setorComboBox.SelectedIndexChanged += new System.EventHandler(this.setorComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(28, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Assunto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(28, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Setor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(28, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Descrição";
            // 
            // dataAberturaLabel
            // 
            this.dataAberturaLabel.AutoSize = true;
            this.dataAberturaLabel.ForeColor = System.Drawing.Color.White;
            this.dataAberturaLabel.Location = new System.Drawing.Point(660, 16);
            this.dataAberturaLabel.Name = "dataAberturaLabel";
            this.dataAberturaLabel.Size = new System.Drawing.Size(30, 13);
            this.dataAberturaLabel.TabIndex = 25;
            this.dataAberturaLabel.Text = "Hora";
            this.dataAberturaLabel.Click += new System.EventHandler(this.dataAberturaLabel_Click);
            // 
            // relogioTimer
            // 
            this.relogioTimer.Enabled = true;
            this.relogioTimer.Interval = 1000;
            this.relogioTimer.Tick += new System.EventHandler(this.relogioTimer_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 32);
            this.panel1.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Abrir Chamado";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(774, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 32);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // gravarChamadoButton
            // 
            this.gravarChamadoButton.Location = new System.Drawing.Point(3, 3);
            this.gravarChamadoButton.Name = "gravarChamadoButton";
            this.gravarChamadoButton.Size = new System.Drawing.Size(122, 23);
            this.gravarChamadoButton.TabIndex = 27;
            this.gravarChamadoButton.Text = "Gravar Chamado";
            this.gravarChamadoButton.UseVisualStyleBackColor = true;
            this.gravarChamadoButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // voltarButton
            // 
            this.voltarButton.Location = new System.Drawing.Point(131, 3);
            this.voltarButton.Name = "voltarButton";
            this.voltarButton.Size = new System.Drawing.Size(75, 23);
            this.voltarButton.TabIndex = 28;
            this.voltarButton.Text = "Voltar";
            this.voltarButton.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.dataAberturaLabel);
            this.panel2.Location = new System.Drawing.Point(12, 413);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 36);
            this.panel2.TabIndex = 29;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.gravarChamadoButton);
            this.flowLayoutPanel1.Controls.Add(this.voltarButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(576, 32);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // AberturaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.prioridadeCheckBox);
            this.Controls.Add(this.descricaoRichTextBox);
            this.Controls.Add(this.assuntoTextBox);
            this.Controls.Add(this.setorComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AberturaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AberturaForm";
            this.Load += new System.EventHandler(this.AberturaForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox prioridadeCheckBox;
        private System.Windows.Forms.RichTextBox descricaoRichTextBox;
        private System.Windows.Forms.TextBox assuntoTextBox;
        private System.Windows.Forms.ComboBox setorComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label dataAberturaLabel;
        private System.Windows.Forms.Timer relogioTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button gravarChamadoButton;
        private System.Windows.Forms.Button voltarButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}