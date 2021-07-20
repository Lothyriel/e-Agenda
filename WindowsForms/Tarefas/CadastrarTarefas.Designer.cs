namespace WindowsForms.Tarefas
{
    partial class CadastrarTarefas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastrarTarefas));
            this.tb_titulo = new System.Windows.Forms.TextBox();
            this.tbar_prioridade = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_percentual = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_cadastrar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_prioridade)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_titulo
            // 
            this.tb_titulo.Location = new System.Drawing.Point(523, 200);
            this.tb_titulo.Multiline = true;
            this.tb_titulo.Name = "tb_titulo";
            this.tb_titulo.Size = new System.Drawing.Size(273, 28);
            this.tb_titulo.TabIndex = 1;
            // 
            // tbar_prioridade
            // 
            this.tbar_prioridade.Location = new System.Drawing.Point(523, 268);
            this.tbar_prioridade.Maximum = 100;
            this.tbar_prioridade.Name = "tbar_prioridade";
            this.tbar_prioridade.Size = new System.Drawing.Size(273, 56);
            this.tbar_prioridade.SmallChange = 10;
            this.tbar_prioridade.TabIndex = 3;
            this.tbar_prioridade.TickFrequency = 5;
            this.tbar_prioridade.Value = 1;
            this.tbar_prioridade.Scroll += new System.EventHandler(this.tbar_percentual_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label1.Location = new System.Drawing.Point(523, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "Título: ";
            // 
            // lb_percentual
            // 
            this.lb_percentual.AutoSize = true;
            this.lb_percentual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lb_percentual.Location = new System.Drawing.Point(488, 268);
            this.lb_percentual.Name = "lb_percentual";
            this.lb_percentual.Size = new System.Drawing.Size(18, 20);
            this.lb_percentual.TabIndex = 7;
            this.lb_percentual.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label2.Location = new System.Drawing.Point(523, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "Prioridade: ";
            // 
            // bt_cadastrar
            // 
            this.bt_cadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.bt_cadastrar.Location = new System.Drawing.Point(573, 330);
            this.bt_cadastrar.Name = "bt_cadastrar";
            this.bt_cadastrar.Size = new System.Drawing.Size(137, 40);
            this.bt_cadastrar.TabIndex = 9;
            this.bt_cadastrar.Text = "Cadastrar";
            this.bt_cadastrar.UseVisualStyleBackColor = true;
            this.bt_cadastrar.Click += new System.EventHandler(this.bt_cadastrar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label3.Location = new System.Drawing.Point(445, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(413, 58);
            this.label3.TabIndex = 10;
            this.label3.Text = "Cadastro Tarefas";
            // 
            // CadastrarTarefas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(113)))), ((int)(((byte)(34)))));
            this.BackgroundImage = global::WindowsForms.Properties.Resources.fundo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(923, 397);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bt_cadastrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_percentual);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbar_prioridade);
            this.Controls.Add(this.tb_titulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CadastrarTarefas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CadastrarTarefas";
            ((System.ComponentModel.ISupportInitialize)(this.tbar_prioridade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.TextBox tb_titulo;
        private System.Windows.Forms.TrackBar tbar_prioridade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_percentual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_cadastrar;
        private System.Windows.Forms.Label label3;
    }
}