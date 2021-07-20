
namespace WindowsForms.Compromissos
{
    partial class CadastrarCompromissos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastrarCompromissos));
            this.tb_local = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_assunto = new System.Windows.Forms.TextBox();
            this.bt_cadastrar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dtp_data = new System.Windows.Forms.DateTimePicker();
            this.dtp_horaFim = new System.Windows.Forms.DateTimePicker();
            this.lb_contatos = new System.Windows.Forms.ListBox();
            this.dtp_horaInicio = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_local
            // 
            this.tb_local.Location = new System.Drawing.Point(498, 158);
            this.tb_local.Multiline = true;
            this.tb_local.Name = "tb_local";
            this.tb_local.Size = new System.Drawing.Size(204, 28);
            this.tb_local.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label6.Location = new System.Drawing.Point(480, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(577, 58);
            this.label6.TabIndex = 33;
            this.label6.Text = "Cadastro Compromissos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label4.Location = new System.Drawing.Point(621, 325);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 26);
            this.label4.TabIndex = 30;
            this.label4.Text = "Hora Fim:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label3.Location = new System.Drawing.Point(490, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 26);
            this.label3.TabIndex = 29;
            this.label3.Text = "Data:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label2.Location = new System.Drawing.Point(493, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 26);
            this.label2.TabIndex = 27;
            this.label2.Text = "Local:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label1.Location = new System.Drawing.Point(493, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 26);
            this.label1.TabIndex = 26;
            this.label1.Text = "Assunto:";
            // 
            // tb_assunto
            // 
            this.tb_assunto.Location = new System.Drawing.Point(498, 218);
            this.tb_assunto.Multiline = true;
            this.tb_assunto.Name = "tb_assunto";
            this.tb_assunto.Size = new System.Drawing.Size(201, 28);
            this.tb_assunto.TabIndex = 25;
            // 
            // bt_cadastrar
            // 
            this.bt_cadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.bt_cadastrar.Location = new System.Drawing.Point(874, 336);
            this.bt_cadastrar.Name = "bt_cadastrar";
            this.bt_cadastrar.Size = new System.Drawing.Size(137, 40);
            this.bt_cadastrar.TabIndex = 24;
            this.bt_cadastrar.Text = "Cadastrar";
            this.bt_cadastrar.UseVisualStyleBackColor = true;
            this.bt_cadastrar.Click += new System.EventHandler(this.bt_cadastrar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label7.Location = new System.Drawing.Point(814, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 26);
            this.label7.TabIndex = 36;
            this.label7.Text = "Contato:";
            // 
            // dtp_data
            // 
            this.dtp_data.Location = new System.Drawing.Point(498, 285);
            this.dtp_data.Name = "dtp_data";
            this.dtp_data.Size = new System.Drawing.Size(284, 22);
            this.dtp_data.TabIndex = 37;
            // 
            // dtp_horaFim
            // 
            this.dtp_horaFim.CustomFormat = "HH:mm";
            this.dtp_horaFim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_horaFim.Location = new System.Drawing.Point(626, 354);
            this.dtp_horaFim.Name = "dtp_horaFim";
            this.dtp_horaFim.ShowUpDown = true;
            this.dtp_horaFim.Size = new System.Drawing.Size(117, 22);
            this.dtp_horaFim.TabIndex = 38;
            // 
            // lb_contatos
            // 
            this.lb_contatos.FormattingEnabled = true;
            this.lb_contatos.ItemHeight = 16;
            this.lb_contatos.Location = new System.Drawing.Point(819, 162);
            this.lb_contatos.Name = "lb_contatos";
            this.lb_contatos.Size = new System.Drawing.Size(271, 148);
            this.lb_contatos.TabIndex = 39;
            // 
            // dtp_horaInicio
            // 
            this.dtp_horaInicio.CustomFormat = "HH:mm";
            this.dtp_horaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_horaInicio.Location = new System.Drawing.Point(498, 354);
            this.dtp_horaInicio.Name = "dtp_horaInicio";
            this.dtp_horaInicio.ShowUpDown = true;
            this.dtp_horaInicio.Size = new System.Drawing.Size(117, 22);
            this.dtp_horaInicio.TabIndex = 41;
            this.dtp_horaInicio.Value = new System.DateTime(2021, 7, 20, 10, 54, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label5.Location = new System.Drawing.Point(493, 325);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 26);
            this.label5.TabIndex = 40;
            this.label5.Text = "Hora Início:";
            // 
            // CadastrarCompromissos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(113)))), ((int)(((byte)(34)))));
            this.BackgroundImage = global::WindowsForms.Properties.Resources.fundo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1119, 415);
            this.Controls.Add(this.dtp_horaInicio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lb_contatos);
            this.Controls.Add(this.dtp_horaFim);
            this.Controls.Add(this.dtp_data);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_local);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_assunto);
            this.Controls.Add(this.bt_cadastrar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CadastrarCompromissos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CadastroCompromissos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_local;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_assunto;
        private System.Windows.Forms.Button bt_cadastrar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtp_data;
        private System.Windows.Forms.DateTimePicker dtp_horaFim;
        private System.Windows.Forms.ListBox lb_contatos;
        private System.Windows.Forms.DateTimePicker dtp_horaInicio;
        private System.Windows.Forms.Label label5;
    }
}