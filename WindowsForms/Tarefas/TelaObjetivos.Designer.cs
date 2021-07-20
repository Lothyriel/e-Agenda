
namespace WindowsForms.Tarefas
{
    partial class TelaObjetivos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaObjetivos));
            this.clb_objetivos = new System.Windows.Forms.CheckedListBox();
            this.titulo = new System.Windows.Forms.Label();
            this.pb_percentual = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_percentual = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbar_prioridade = new System.Windows.Forms.TrackBar();
            this.tb_titulo = new System.Windows.Forms.TextBox();
            this.bt_salvar = new System.Windows.Forms.Button();
            this.bt_cadastrarObjetivos = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_tituloObjetivo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_prioridade)).BeginInit();
            this.SuspendLayout();
            // 
            // clb_objetivos
            // 
            this.clb_objetivos.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.clb_objetivos.FormattingEnabled = true;
            this.clb_objetivos.Location = new System.Drawing.Point(98, 326);
            this.clb_objetivos.Name = "clb_objetivos";
            this.clb_objetivos.Size = new System.Drawing.Size(618, 242);
            this.clb_objetivos.TabIndex = 0;
            this.clb_objetivos.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clb_objetivos_ItemCheck);
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.titulo.Location = new System.Drawing.Point(476, 25);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(185, 58);
            this.titulo.TabIndex = 6;
            this.titulo.Text = "Tarefa:";
            // 
            // pb_percentual
            // 
            this.pb_percentual.Location = new System.Drawing.Point(98, 297);
            this.pb_percentual.Name = "pb_percentual";
            this.pb_percentual.Size = new System.Drawing.Size(618, 23);
            this.pb_percentual.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label2.Location = new System.Drawing.Point(514, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 26);
            this.label2.TabIndex = 15;
            this.label2.Text = "Prioridade:";
            // 
            // lb_percentual
            // 
            this.lb_percentual.AutoSize = true;
            this.lb_percentual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lb_percentual.Location = new System.Drawing.Point(643, 187);
            this.lb_percentual.Name = "lb_percentual";
            this.lb_percentual.Size = new System.Drawing.Size(18, 20);
            this.lb_percentual.TabIndex = 14;
            this.lb_percentual.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label3.Location = new System.Drawing.Point(514, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 26);
            this.label3.TabIndex = 13;
            this.label3.Text = "Título: ";
            // 
            // tbar_prioridade
            // 
            this.tbar_prioridade.Location = new System.Drawing.Point(519, 211);
            this.tbar_prioridade.Maximum = 100;
            this.tbar_prioridade.Name = "tbar_prioridade";
            this.tbar_prioridade.Size = new System.Drawing.Size(254, 56);
            this.tbar_prioridade.SmallChange = 10;
            this.tbar_prioridade.TabIndex = 12;
            this.tbar_prioridade.TickFrequency = 5;
            this.tbar_prioridade.Value = 1;
            this.tbar_prioridade.Scroll += new System.EventHandler(this.tbar_prioridade_Scroll);
            // 
            // tb_titulo
            // 
            this.tb_titulo.Location = new System.Drawing.Point(519, 136);
            this.tb_titulo.Multiline = true;
            this.tb_titulo.Name = "tb_titulo";
            this.tb_titulo.Size = new System.Drawing.Size(249, 28);
            this.tb_titulo.TabIndex = 11;
            this.tb_titulo.TextChanged += new System.EventHandler(this.tb_titulo_TextChanged);
            // 
            // bt_salvar
            // 
            this.bt_salvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.bt_salvar.Location = new System.Drawing.Point(574, 588);
            this.bt_salvar.Name = "bt_salvar";
            this.bt_salvar.Size = new System.Drawing.Size(132, 48);
            this.bt_salvar.TabIndex = 16;
            this.bt_salvar.Text = "Salvar";
            this.bt_salvar.UseVisualStyleBackColor = true;
            this.bt_salvar.Click += new System.EventHandler(this.bt_salvar_Click);
            // 
            // bt_cadastrarObjetivos
            // 
            this.bt_cadastrarObjetivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bt_cadastrarObjetivos.Location = new System.Drawing.Point(389, 588);
            this.bt_cadastrarObjetivos.Name = "bt_cadastrarObjetivos";
            this.bt_cadastrarObjetivos.Size = new System.Drawing.Size(163, 48);
            this.bt_cadastrarObjetivos.TabIndex = 17;
            this.bt_cadastrarObjetivos.Text = "Inserir Novo";
            this.bt_cadastrarObjetivos.UseVisualStyleBackColor = true;
            this.bt_cadastrarObjetivos.Click += new System.EventHandler(this.bt_cadastrarObjetivos_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label4.Location = new System.Drawing.Point(93, 575);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 26);
            this.label4.TabIndex = 19;
            this.label4.Text = "Descrição";
            // 
            // tb_tituloObjetivo
            // 
            this.tb_tituloObjetivo.Location = new System.Drawing.Point(98, 604);
            this.tb_tituloObjetivo.Multiline = true;
            this.tb_tituloObjetivo.Name = "tb_tituloObjetivo";
            this.tb_tituloObjetivo.Size = new System.Drawing.Size(273, 28);
            this.tb_tituloObjetivo.TabIndex = 18;
            // 
            // TelaObjetivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(113)))), ((int)(((byte)(34)))));
            this.BackgroundImage = global::WindowsForms.Properties.Resources.fundo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(785, 658);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_tituloObjetivo);
            this.Controls.Add(this.bt_cadastrarObjetivos);
            this.Controls.Add(this.bt_salvar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_percentual);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbar_prioridade);
            this.Controls.Add(this.tb_titulo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb_percentual);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.clb_objetivos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaObjetivos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaObjetivos";
            ((System.ComponentModel.ISupportInitialize)(this.tbar_prioridade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clb_objetivos;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.ProgressBar pb_percentual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_percentual;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar tbar_prioridade;
        private System.Windows.Forms.TextBox tb_titulo;
        private System.Windows.Forms.Button bt_salvar;
        private System.Windows.Forms.Button bt_cadastrarObjetivos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_tituloObjetivo;
    }
}