
namespace WindowsForms.Tarefas
{
    partial class TelaTarefas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaTarefas));
            this.bt_cadastro = new System.Windows.Forms.Button();
            this.bt_excluir = new System.Windows.Forms.Button();
            this.titulo = new System.Windows.Forms.Label();
            this.dg_visualizar = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dg_visualizar)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_cadastro
            // 
            this.bt_cadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bt_cadastro.Location = new System.Drawing.Point(163, 341);
            this.bt_cadastro.Name = "bt_cadastro";
            this.bt_cadastro.Size = new System.Drawing.Size(172, 49);
            this.bt_cadastro.TabIndex = 2;
            this.bt_cadastro.Text = "Cadastrar";
            this.bt_cadastro.UseVisualStyleBackColor = true;
            this.bt_cadastro.Click += new System.EventHandler(this.bt_cadastro_Click);
            // 
            // bt_excluir
            // 
            this.bt_excluir.Enabled = false;
            this.bt_excluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bt_excluir.Location = new System.Drawing.Point(163, 439);
            this.bt_excluir.Name = "bt_excluir";
            this.bt_excluir.Size = new System.Drawing.Size(172, 49);
            this.bt_excluir.TabIndex = 4;
            this.bt_excluir.Text = "Excluir";
            this.bt_excluir.UseVisualStyleBackColor = true;
            this.bt_excluir.Click += new System.EventHandler(this.bt_excluir_Click);
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F);
            this.titulo.Location = new System.Drawing.Point(461, 66);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(293, 85);
            this.titulo.TabIndex = 5;
            this.titulo.Text = "Tarefas";
            // 
            // dg_visualizar
            // 
            this.dg_visualizar.AllowUserToAddRows = false;
            this.dg_visualizar.AllowUserToDeleteRows = false;
            this.dg_visualizar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dg_visualizar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_visualizar.Location = new System.Drawing.Point(476, 246);
            this.dg_visualizar.MultiSelect = false;
            this.dg_visualizar.Name = "dg_visualizar";
            this.dg_visualizar.ReadOnly = true;
            this.dg_visualizar.RowHeadersVisible = false;
            this.dg_visualizar.RowHeadersWidth = 51;
            this.dg_visualizar.RowTemplate.Height = 24;
            this.dg_visualizar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_visualizar.Size = new System.Drawing.Size(867, 439);
            this.dg_visualizar.TabIndex = 6;
            this.dg_visualizar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_visualizar_CellDoubleClick);
            this.dg_visualizar.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_visualizar_RowEnter);
            // 
            // TelaTarefas
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
            this.Name = "TelaTarefas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaTarefas";
            ((System.ComponentModel.ISupportInitialize)(this.dg_visualizar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_cadastro;
        private System.Windows.Forms.Button bt_excluir;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.DataGridView dg_visualizar;
    }
}