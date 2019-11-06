namespace calculadora_VLSM
{
    partial class calculadora_VLSM
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtIpEntrada = new System.Windows.Forms.TextBox();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.hostsUtilizaveis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalHosts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tamanhoRede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.nudQtdhosts = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtdhosts)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Informe o IP para cálculo :";
            // 
            // txtIpEntrada
            // 
            this.txtIpEntrada.Location = new System.Drawing.Point(181, 41);
            this.txtIpEntrada.Name = "txtIpEntrada";
            this.txtIpEntrada.Size = new System.Drawing.Size(223, 20);
            this.txtIpEntrada.TabIndex = 1;
            // 
            // btnContinuar
            // 
            this.btnContinuar.Location = new System.Drawing.Point(453, 36);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(75, 29);
            this.btnContinuar.TabIndex = 2;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Location = new System.Drawing.Point(583, 36);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(75, 29);
            this.btnReiniciar.TabIndex = 3;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.UseVisualStyleBackColor = true;
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hostsUtilizaveis,
            this.totalHosts,
            this.tamanhoRede});
            this.dgv.Location = new System.Drawing.Point(15, 190);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(543, 176);
            this.dgv.TabIndex = 4;
            this.dgv.Visible = false;
            // 
            // hostsUtilizaveis
            // 
            this.hostsUtilizaveis.HeaderText = "Hosts Uti.";
            this.hostsUtilizaveis.Name = "hostsUtilizaveis";
            this.hostsUtilizaveis.ReadOnly = true;
            this.hostsUtilizaveis.Width = 200;
            // 
            // totalHosts
            // 
            this.totalHosts.HeaderText = "Total de Hosts";
            this.totalHosts.Name = "totalHosts";
            this.totalHosts.ReadOnly = true;
            this.totalHosts.Width = 150;
            // 
            // tamanhoRede
            // 
            this.tamanhoRede.HeaderText = "Tamanho da Rede";
            this.tamanhoRede.Name = "tamanhoRede";
            this.tamanhoRede.ReadOnly = true;
            this.tamanhoRede.Width = 150;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Quantidade de Hosts: ";
            this.label2.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(453, 120);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 31);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(583, 120);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 31);
            this.btnCalcular.TabIndex = 8;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Visible = false;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(-1, 404);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBox1.Size = new System.Drawing.Size(729, 216);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // nudQtdhosts
            // 
            this.nudQtdhosts.Location = new System.Drawing.Point(196, 118);
            this.nudQtdhosts.Name = "nudQtdhosts";
            this.nudQtdhosts.Size = new System.Drawing.Size(189, 20);
            this.nudQtdhosts.TabIndex = 10;
            this.nudQtdhosts.Visible = false;
            // 
            // calculadora_VLSM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 632);
            this.Controls.Add(this.nudQtdhosts);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.txtIpEntrada);
            this.Controls.Add(this.label1);
            this.Name = "calculadora_VLSM";
            this.Text = "Calculadora VLSM";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtdhosts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIpEntrada;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.NumericUpDown nudQtdhosts;
        private System.Windows.Forms.DataGridViewTextBoxColumn hostsUtilizaveis;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalHosts;
        private System.Windows.Forms.DataGridViewTextBoxColumn tamanhoRede;
    }
}

