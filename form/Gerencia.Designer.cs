namespace Calopsite
{
    partial class Gerencia
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.passarosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoPassaroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retirarPassaroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaiolaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inserirNovaGaiolaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alimentarGaiolaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medicarGaiolaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manejoGaiolaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estoqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adicionarMedicamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 307);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(478, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(28, 17);
            this.toolStripStatusLabel3.Text = "   ||  ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.passarosToolStripMenuItem,
            this.gaiolaToolStripMenuItem,
            this.estoqueToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(478, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // passarosToolStripMenuItem
            // 
            this.passarosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoPassaroToolStripMenuItem,
            this.retirarPassaroToolStripMenuItem});
            this.passarosToolStripMenuItem.Name = "passarosToolStripMenuItem";
            this.passarosToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.passarosToolStripMenuItem.Text = "Passaros";
            // 
            // novoPassaroToolStripMenuItem
            // 
            this.novoPassaroToolStripMenuItem.Name = "novoPassaroToolStripMenuItem";
            this.novoPassaroToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.novoPassaroToolStripMenuItem.Text = "Inserir Passaro";
            this.novoPassaroToolStripMenuItem.Click += new System.EventHandler(this.novoPassaroToolStripMenuItem_Click);
            // 
            // retirarPassaroToolStripMenuItem
            // 
            this.retirarPassaroToolStripMenuItem.Name = "retirarPassaroToolStripMenuItem";
            this.retirarPassaroToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.retirarPassaroToolStripMenuItem.Text = "Gerir Passaros";
            this.retirarPassaroToolStripMenuItem.Click += new System.EventHandler(this.retirarPassaroToolStripMenuItem_Click);
            // 
            // gaiolaToolStripMenuItem
            // 
            this.gaiolaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inserirNovaGaiolaToolStripMenuItem,
            this.alimentarGaiolaToolStripMenuItem,
            this.medicarGaiolaToolStripMenuItem,
            this.manejoGaiolaToolStripMenuItem});
            this.gaiolaToolStripMenuItem.Name = "gaiolaToolStripMenuItem";
            this.gaiolaToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.gaiolaToolStripMenuItem.Text = "Gaiola";
            // 
            // inserirNovaGaiolaToolStripMenuItem
            // 
            this.inserirNovaGaiolaToolStripMenuItem.Name = "inserirNovaGaiolaToolStripMenuItem";
            this.inserirNovaGaiolaToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.inserirNovaGaiolaToolStripMenuItem.Text = "Inserir nova gaiola";
            this.inserirNovaGaiolaToolStripMenuItem.Click += new System.EventHandler(this.inserirNovaGaiolaToolStripMenuItem_Click);
            // 
            // alimentarGaiolaToolStripMenuItem
            // 
            this.alimentarGaiolaToolStripMenuItem.Name = "alimentarGaiolaToolStripMenuItem";
            this.alimentarGaiolaToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.alimentarGaiolaToolStripMenuItem.Text = "Alimentar Gaiola";
            this.alimentarGaiolaToolStripMenuItem.Click += new System.EventHandler(this.alimentarGaiolaToolStripMenuItem_Click);
            // 
            // medicarGaiolaToolStripMenuItem
            // 
            this.medicarGaiolaToolStripMenuItem.Name = "medicarGaiolaToolStripMenuItem";
            this.medicarGaiolaToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.medicarGaiolaToolStripMenuItem.Text = "Medicar Gaiola";
            this.medicarGaiolaToolStripMenuItem.Click += new System.EventHandler(this.medicarGaiolaToolStripMenuItem_Click);
            // 
            // manejoGaiolaToolStripMenuItem
            // 
            this.manejoGaiolaToolStripMenuItem.Name = "manejoGaiolaToolStripMenuItem";
            this.manejoGaiolaToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.manejoGaiolaToolStripMenuItem.Text = "Manejo Gaiola";
            this.manejoGaiolaToolStripMenuItem.Click += new System.EventHandler(this.manejoGaiolaToolStripMenuItem_Click);
            // 
            // estoqueToolStripMenuItem
            // 
            this.estoqueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarMedicamentoToolStripMenuItem});
            this.estoqueToolStripMenuItem.Name = "estoqueToolStripMenuItem";
            this.estoqueToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.estoqueToolStripMenuItem.Text = "Estoque";
            // 
            // adicionarMedicamentoToolStripMenuItem
            // 
            this.adicionarMedicamentoToolStripMenuItem.Name = "adicionarMedicamentoToolStripMenuItem";
            this.adicionarMedicamentoToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.adicionarMedicamentoToolStripMenuItem.Text = "Adicionar Insumo";
            this.adicionarMedicamentoToolStripMenuItem.Click += new System.EventHandler(this.adicionarMedicamentoToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 33);
            this.label1.TabIndex = 4;
            this.label1.Text = "BEM VINDO AO CALOPSITE";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(42, 147);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 18;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Gaiola";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 21;
            // 
            // Gerencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 329);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Gerencia";
            this.Text = "Gerencia";
            this.Load += new System.EventHandler(this.Gerencia_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem passarosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoPassaroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaiolaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inserirNovaGaiolaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estoqueToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem adicionarMedicamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retirarPassaroToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripMenuItem alimentarGaiolaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manejoGaiolaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medicarGaiolaToolStripMenuItem;
        protected System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}