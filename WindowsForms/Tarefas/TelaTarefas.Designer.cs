
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dg_visualizarConcluidas = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dg_visualizarInconcluidas = new System.Windows.Forms.DataGridView();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_visualizarConcluidas)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_visualizarInconcluidas)).BeginInit();
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
            this.titulo.Location = new System.Drawing.Point(467, 58);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(293, 85);
            this.titulo.TabIndex = 5;
            this.titulo.Text = "Tarefas";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(454, 193);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(893, 516);
            this.tabControl.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dg_visualizarConcluidas);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(885, 487);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Concluídas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dg_visualizarConcluidas
            // 
            this.dg_visualizarConcluidas.AllowUserToAddRows = false;
            this.dg_visualizarConcluidas.AllowUserToDeleteRows = false;
            this.dg_visualizarConcluidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_visualizarConcluidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_visualizarConcluidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_visualizarConcluidas.Location = new System.Drawing.Point(3, 3);
            this.dg_visualizarConcluidas.MultiSelect = false;
            this.dg_visualizarConcluidas.Name = "dg_visualizarConcluidas";
            this.dg_visualizarConcluidas.ReadOnly = true;
            this.dg_visualizarConcluidas.RowHeadersVisible = false;
            this.dg_visualizarConcluidas.RowHeadersWidth = 51;
            this.dg_visualizarConcluidas.RowTemplate.Height = 24;
            this.dg_visualizarConcluidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_visualizarConcluidas.Size = new System.Drawing.Size(879, 481);
            this.dg_visualizarConcluidas.TabIndex = 15;
            this.dg_visualizarConcluidas.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_selecionado_CellDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dg_visualizarInconcluidas);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(885, 487);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Inconcluídas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dg_visualizarInconcluidas
            // 
            this.dg_visualizarInconcluidas.AllowUserToAddRows = false;
            this.dg_visualizarInconcluidas.AllowUserToDeleteRows = false;
            this.dg_visualizarInconcluidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_visualizarInconcluidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_visualizarInconcluidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_visualizarInconcluidas.Location = new System.Drawing.Point(3, 3);
            this.dg_visualizarInconcluidas.MultiSelect = false;
            this.dg_visualizarInconcluidas.Name = "dg_visualizarInconcluidas";
            this.dg_visualizarInconcluidas.ReadOnly = true;
            this.dg_visualizarInconcluidas.RowHeadersVisible = false;
            this.dg_visualizarInconcluidas.RowHeadersWidth = 51;
            this.dg_visualizarInconcluidas.RowTemplate.Height = 24;
            this.dg_visualizarInconcluidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_visualizarInconcluidas.Size = new System.Drawing.Size(879, 481);
            this.dg_visualizarInconcluidas.TabIndex = 16;
            this.dg_visualizarInconcluidas.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_selecionado_CellDoubleClick);
            // 
            // TelaTarefas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(113)))), ((int)(((byte)(34)))));
            this.BackgroundImage = global::WindowsForms.Properties.Resources.fundo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1382, 753);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.bt_excluir);
            this.Controls.Add(this.bt_cadastro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaTarefas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaTarefas";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_visualizarConcluidas)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_visualizarInconcluidas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_cadastro;
        private System.Windows.Forms.Button bt_excluir;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dg_visualizarConcluidas;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dg_visualizarInconcluidas;
    }
}