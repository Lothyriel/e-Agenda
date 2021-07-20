
namespace WindowsForms.Contatos
{
    partial class TelaContatos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaContatos));
            this.dg_visualizar = new System.Windows.Forms.DataGridView();
            this.titulo = new System.Windows.Forms.Label();
            this.bt_excluir = new System.Windows.Forms.Button();
            this.bt_cadastro = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_visualizar)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_visualizar
            // 
            this.dg_visualizar.AllowUserToAddRows = false;
            this.dg_visualizar.AllowUserToDeleteRows = false;
            this.dg_visualizar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dg_visualizar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_visualizar.Location = new System.Drawing.Point(475, 244);
            this.dg_visualizar.MultiSelect = false;
            this.dg_visualizar.Name = "dg_visualizar";
            this.dg_visualizar.ReadOnly = true;
            this.dg_visualizar.RowHeadersVisible = false;
            this.dg_visualizar.RowHeadersWidth = 51;
            this.dg_visualizar.RowTemplate.Height = 24;
            this.dg_visualizar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_visualizar.Size = new System.Drawing.Size(867, 439);
            this.dg_visualizar.TabIndex = 10;
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F);
            this.titulo.Location = new System.Drawing.Point(460, 64);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(339, 85);
            this.titulo.TabIndex = 9;
            this.titulo.Text = "Contatos";
            // 
            // bt_excluir
            // 
            this.bt_excluir.Enabled = false;
            this.bt_excluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bt_excluir.Location = new System.Drawing.Point(162, 437);
            this.bt_excluir.Name = "bt_excluir";
            this.bt_excluir.Size = new System.Drawing.Size(172, 49);
            this.bt_excluir.TabIndex = 8;
            this.bt_excluir.Text = "Excluir";
            this.bt_excluir.UseVisualStyleBackColor = true;
            // 
            // bt_cadastro
            // 
            this.bt_cadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bt_cadastro.Location = new System.Drawing.Point(162, 339);
            this.bt_cadastro.Name = "bt_cadastro";
            this.bt_cadastro.Size = new System.Drawing.Size(172, 49);
            this.bt_cadastro.TabIndex = 7;
            this.bt_cadastro.Text = "Cadastrar";
            this.bt_cadastro.UseVisualStyleBackColor = true;
            // 
            // TelaContatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(113)))), ((int)(((byte)(34)))));
            this.BackgroundImage = global::WindowsForms.Properties.Resources.fundo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1382, 753);
            this.Controls.Add(this.dg_visualizar);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.bt_excluir);
            this.Controls.Add(this.bt_cadastro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaContatos";
            this.Text = "TelaContatos";
            ((System.ComponentModel.ISupportInitialize)(this.dg_visualizar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_visualizar;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.Button bt_excluir;
        private System.Windows.Forms.Button bt_cadastro;
    }
}