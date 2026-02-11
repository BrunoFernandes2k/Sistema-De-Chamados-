namespace Empresa.UI.Windows
{
    partial class AcompanharForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AcompanharForm));
            this.listaDataGridView = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.atualizarButton = new System.Windows.Forms.Button();
            this.visualizarButton = new System.Windows.Forms.Button();
            this.voltarButton = new System.Windows.Forms.Button();
            this.deletarButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.detalhesPanel = new System.Windows.Forms.Panel();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.descricaoRichTextBox = new System.Windows.Forms.RichTextBox();
            this.descricaoLabel = new System.Windows.Forms.Label();
            this.assuntoTextBox = new System.Windows.Forms.TextBox();
            this.assuntoLabel = new System.Windows.Forms.Label();
            this.setorTextBox = new System.Windows.Forms.TextBox();
            this.setorLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.nomeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.listaDataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.detalhesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // listaDataGridView
            // 
            this.listaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaDataGridView.Location = new System.Drawing.Point(605, 3);
            this.listaDataGridView.Name = "listaDataGridView";
            this.listaDataGridView.Size = new System.Drawing.Size(166, 361);
            this.listaDataGridView.TabIndex = 5;
            this.listaDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listaDataGridView_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Location = new System.Drawing.Point(12, 410);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 39);
            this.panel2.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.atualizarButton);
            this.flowLayoutPanel1.Controls.Add(this.visualizarButton);
            this.flowLayoutPanel1.Controls.Add(this.voltarButton);
            this.flowLayoutPanel1.Controls.Add(this.deletarButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(770, 33);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // atualizarButton
            // 
            this.atualizarButton.Location = new System.Drawing.Point(3, 3);
            this.atualizarButton.Name = "atualizarButton";
            this.atualizarButton.Size = new System.Drawing.Size(113, 23);
            this.atualizarButton.TabIndex = 0;
            this.atualizarButton.Text = "Atualizar Status";
            this.atualizarButton.UseVisualStyleBackColor = true;
            this.atualizarButton.Click += new System.EventHandler(this.atualizarButton_Click);
            // 
            // visualizarButton
            // 
            this.visualizarButton.Location = new System.Drawing.Point(122, 3);
            this.visualizarButton.Name = "visualizarButton";
            this.visualizarButton.Size = new System.Drawing.Size(125, 23);
            this.visualizarButton.TabIndex = 1;
            this.visualizarButton.Text = "Visualizar Detalhes";
            this.visualizarButton.UseVisualStyleBackColor = true;
            this.visualizarButton.Click += new System.EventHandler(this.visualizarButton_Click);
            // 
            // voltarButton
            // 
            this.voltarButton.Location = new System.Drawing.Point(253, 3);
            this.voltarButton.Name = "voltarButton";
            this.voltarButton.Size = new System.Drawing.Size(82, 23);
            this.voltarButton.TabIndex = 2;
            this.voltarButton.Text = "Voltar";
            this.voltarButton.UseVisualStyleBackColor = true;
            this.voltarButton.Click += new System.EventHandler(this.voltarButton_Click);
            // 
            // deletarButton
            // 
            this.deletarButton.Location = new System.Drawing.Point(341, 3);
            this.deletarButton.Name = "deletarButton";
            this.deletarButton.Size = new System.Drawing.Size(82, 23);
            this.deletarButton.TabIndex = 3;
            this.deletarButton.Text = "Deletar";
            this.deletarButton.UseVisualStyleBackColor = true;
            this.deletarButton.Click += new System.EventHandler(this.deletarButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 32);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Acompanhar Chamados";
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
            // panel3
            // 
            this.panel3.Controls.Add(this.detalhesPanel);
            this.panel3.Controls.Add(this.listaDataGridView);
            this.panel3.Location = new System.Drawing.Point(12, 37);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(774, 367);
            this.panel3.TabIndex = 8;
            // 
            // detalhesPanel
            // 
            this.detalhesPanel.Controls.Add(this.statusTextBox);
            this.detalhesPanel.Controls.Add(this.statusLabel);
            this.detalhesPanel.Controls.Add(this.descricaoRichTextBox);
            this.detalhesPanel.Controls.Add(this.descricaoLabel);
            this.detalhesPanel.Controls.Add(this.assuntoTextBox);
            this.detalhesPanel.Controls.Add(this.assuntoLabel);
            this.detalhesPanel.Controls.Add(this.setorTextBox);
            this.detalhesPanel.Controls.Add(this.setorLabel);
            this.detalhesPanel.Controls.Add(this.emailTextBox);
            this.detalhesPanel.Controls.Add(this.emailLabel);
            this.detalhesPanel.Controls.Add(this.nomeTextBox);
            this.detalhesPanel.Controls.Add(this.nomeLabel);
            this.detalhesPanel.Location = new System.Drawing.Point(4, 3);
            this.detalhesPanel.Name = "detalhesPanel";
            this.detalhesPanel.Size = new System.Drawing.Size(595, 361);
            this.detalhesPanel.TabIndex = 16;
            // 
            // statusTextBox
            // 
            this.statusTextBox.Location = new System.Drawing.Point(419, 76);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(167, 20);
            this.statusTextBox.TabIndex = 17;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(417, 60);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(37, 13);
            this.statusLabel.TabIndex = 16;
            this.statusLabel.Text = "Status";
            // 
            // descricaoRichTextBox
            // 
            this.descricaoRichTextBox.Location = new System.Drawing.Point(10, 132);
            this.descricaoRichTextBox.Name = "descricaoRichTextBox";
            this.descricaoRichTextBox.Size = new System.Drawing.Size(576, 208);
            this.descricaoRichTextBox.TabIndex = 15;
            this.descricaoRichTextBox.Text = "";
            // 
            // descricaoLabel
            // 
            this.descricaoLabel.AutoSize = true;
            this.descricaoLabel.Location = new System.Drawing.Point(8, 116);
            this.descricaoLabel.Name = "descricaoLabel";
            this.descricaoLabel.Size = new System.Drawing.Size(55, 13);
            this.descricaoLabel.TabIndex = 14;
            this.descricaoLabel.Text = "Descrição";
            // 
            // assuntoTextBox
            // 
            this.assuntoTextBox.Location = new System.Drawing.Point(10, 76);
            this.assuntoTextBox.Name = "assuntoTextBox";
            this.assuntoTextBox.Size = new System.Drawing.Size(373, 20);
            this.assuntoTextBox.TabIndex = 13;
            // 
            // assuntoLabel
            // 
            this.assuntoLabel.AutoSize = true;
            this.assuntoLabel.Location = new System.Drawing.Point(8, 60);
            this.assuntoLabel.Name = "assuntoLabel";
            this.assuntoLabel.Size = new System.Drawing.Size(45, 13);
            this.assuntoLabel.TabIndex = 12;
            this.assuntoLabel.Text = "Assunto";
            // 
            // setorTextBox
            // 
            this.setorTextBox.Location = new System.Drawing.Point(419, 22);
            this.setorTextBox.Name = "setorTextBox";
            this.setorTextBox.Size = new System.Drawing.Size(167, 20);
            this.setorTextBox.TabIndex = 11;
            // 
            // setorLabel
            // 
            this.setorLabel.AutoSize = true;
            this.setorLabel.Location = new System.Drawing.Point(417, 6);
            this.setorLabel.Name = "setorLabel";
            this.setorLabel.Size = new System.Drawing.Size(32, 13);
            this.setorLabel.TabIndex = 10;
            this.setorLabel.Text = "Setor";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(185, 22);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(198, 20);
            this.emailTextBox.TabIndex = 9;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(183, 6);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(32, 13);
            this.emailLabel.TabIndex = 8;
            this.emailLabel.Text = "Email";
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.Location = new System.Drawing.Point(9, 22);
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(150, 20);
            this.nomeTextBox.TabIndex = 7;
            this.nomeTextBox.TextChanged += new System.EventHandler(this.nomeTextBox_TextChanged);
            // 
            // nomeLabel
            // 
            this.nomeLabel.AutoSize = true;
            this.nomeLabel.Location = new System.Drawing.Point(7, 6);
            this.nomeLabel.Name = "nomeLabel";
            this.nomeLabel.Size = new System.Drawing.Size(35, 13);
            this.nomeLabel.TabIndex = 6;
            this.nomeLabel.Text = "Nome";
            // 
            // AcompanharForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AcompanharForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AcompanharForm";
            this.Load += new System.EventHandler(this.AcompanharForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listaDataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.detalhesPanel.ResumeLayout(false);
            this.detalhesPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView listaDataGridView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button atualizarButton;
        private System.Windows.Forms.Button visualizarButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button voltarButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label nomeLabel;
        private System.Windows.Forms.Label descricaoLabel;
        private System.Windows.Forms.TextBox assuntoTextBox;
        private System.Windows.Forms.Label assuntoLabel;
        private System.Windows.Forms.TextBox setorTextBox;
        private System.Windows.Forms.Label setorLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.Panel detalhesPanel;
        private System.Windows.Forms.RichTextBox descricaoRichTextBox;
        private System.Windows.Forms.Button deletarButton;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.Label statusLabel;
    }
}