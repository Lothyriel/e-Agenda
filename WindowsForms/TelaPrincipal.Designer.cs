
namespace WindowsForms
{
    partial class TelaPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPrincipal));
            this.tarefas = new System.Windows.Forms.PictureBox();
            this.compromissos = new System.Windows.Forms.PictureBox();
            this.contatos = new System.Windows.Forms.PictureBox();
            this.titulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tarefas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compromissos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contatos)).BeginInit();
            this.SuspendLayout();
            // 
            // tarefas
            // 
            this.tarefas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tarefas.Image = global::WindowsForms.Properties.Resources.tarefas;
            this.tarefas.Location = new System.Drawing.Point(293, 373);
            this.tarefas.Name = "tarefas";
            this.tarefas.Size = new System.Drawing.Size(167, 147);
            this.tarefas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tarefas.TabIndex = 5;
            this.tarefas.TabStop = false;
            this.tarefas.Click += new System.EventHandler(this.tarefas_Click);
            // 
            // compromissos
            // 
            this.compromissos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.compromissos.Image = global::WindowsForms.Properties.Resources.compromissos;
            this.compromissos.Location = new System.Drawing.Point(960, 373);
            this.compromissos.Name = "compromissos";
            this.compromissos.Size = new System.Drawing.Size(155, 147);
            this.compromissos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.compromissos.TabIndex = 4;
            this.compromissos.TabStop = false;
            this.compromissos.Click += new System.EventHandler(this.compromissos_Click);
            // 
            // contatos
            // 
            this.contatos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.contatos.Image = global::WindowsForms.Properties.Resources.contatos;
            this.contatos.Location = new System.Drawing.Point(645, 373);
            this.contatos.Name = "contatos";
            this.contatos.Size = new System.Drawing.Size(150, 147);
            this.contatos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.contatos.TabIndex = 3;
            this.contatos.TabStop = false;
            this.contatos.Click += new System.EventHandler(this.contatos_Click);
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 65F);
            this.titulo.Location = new System.Drawing.Point(501, 64);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(527, 124);
            this.titulo.TabIndex = 6;
            this.titulo.Text = "e-Agenda";
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(113)))), ((int)(((byte)(34)))));
            this.BackgroundImage = global::WindowsForms.Properties.Resources.fundo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1382, 753);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.tarefas);
            this.Controls.Add(this.compromissos);
            this.Controls.Add(this.contatos);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaPrincipal";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "telaPrincipal";
            ((System.ComponentModel.ISupportInitialize)(this.tarefas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compromissos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox contatos;
        private System.Windows.Forms.PictureBox compromissos;
        private System.Windows.Forms.PictureBox tarefas;
        private System.Windows.Forms.Label titulo;
    }
}

