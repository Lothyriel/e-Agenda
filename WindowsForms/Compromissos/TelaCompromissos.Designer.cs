
namespace WindowsForms.Compromissos
{
    partial class TelaCompromissos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaCompromissos));
            this.bt_editar = new System.Windows.Forms.Button();
            this.dg_visualizarFuturos = new System.Windows.Forms.DataGridView();
            this.titulo = new System.Windows.Forms.Label();
            this.bt_excluir = new System.Windows.Forms.Button();
            this.bt_cadastro = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dg_visualizarPassados = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dg_visualizarFuturos)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_visualizarPassados)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_editar
            // 
            this.bt_editar.Enabled = false;
            this.bt_editar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bt_editar.Location = new System.Drawing.Point(164, 403);
            this.bt_editar.Name = "bt_editar";
            this.bt_editar.Size = new System.Drawing.Size(172, 49);
            this.bt_editar.TabIndex = 16;
            this.bt_editar.Text = "Editar";
            this.bt_editar.UseVisualStyleBackColor = true;
            this.bt_editar.Click += new System.EventHandler(this.bt_editar_Click);
            // 
            // dg_visualizarFuturos
            // 
            this.dg_visualizarFuturos.AllowUserToAddRows = false;
            this.dg_visualizarFuturos.AllowUserToDeleteRows = false;
            this.dg_visualizarFuturos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_visualizarFuturos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_visualizarFuturos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_visualizarFuturos.Location = new System.Drawing.Point(3, 3);
            this.dg_visualizarFuturos.MultiSelect = false;
            this.dg_visualizarFuturos.Name = "dg_visualizarFuturos";
            this.dg_visualizarFuturos.ReadOnly = true;
            this.dg_visualizarFuturos.RowHeadersVisible = false;
            this.dg_visualizarFuturos.RowHeadersWidth = 51;
            this.dg_visualizarFuturos.RowTemplate.Height = 24;
            this.dg_visualizarFuturos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_visualizarFuturos.Size = new System.Drawing.Size(879, 481);
            this.dg_visualizarFuturos.TabIndex = 15;
            this.dg_visualizarFuturos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_visualizar_RowEnter);
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F);
            this.titulo.Location = new System.Drawing.Point(462, 62);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(539, 85);
            this.titulo.TabIndex = 14;
            this.titulo.Text = "Compromissos";
            // 
            // bt_excluir
            // 
            this.bt_excluir.Enabled = false;
            this.bt_excluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bt_excluir.Location = new System.Drawing.Point(164, 467);
            this.bt_excluir.Name = "bt_excluir";
            this.bt_excluir.Size = new System.Drawing.Size(172, 49);
            this.bt_excluir.TabIndex = 13;
            this.bt_excluir.Text = "Excluir";
            this.bt_excluir.UseVisualStyleBackColor = true;
            this.bt_excluir.Click += new System.EventHandler(this.bt_excluir_Click);
            // 
            // bt_cadastro
            // 
            this.bt_cadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bt_cadastro.Location = new System.Drawing.Point(164, 337);
            this.bt_cadastro.Name = "bt_cadastro";
            this.bt_cadastro.Size = new System.Drawing.Size(172, 49);
            this.bt_cadastro.TabIndex = 12;
            this.bt_cadastro.Text = "Cadastrar";
            this.bt_cadastro.UseVisualStyleBackColor = true;
            this.bt_cadastro.Click += new System.EventHandler(this.bt_cadastro_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(464, 203);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(893, 516);
            this.tabControl.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dg_visualizarFuturos);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(885, 487);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Futuros";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dg_visualizarPassados);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(885, 487);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Passados";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dg_visualizarPassados
            // 
            this.dg_visualizarPassados.AllowUserToAddRows = false;
            this.dg_visualizarPassados.AllowUserToDeleteRows = false;
            this.dg_visualizarPassados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_visualizarPassados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_visualizarPassados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_visualizarPassados.Location = new System.Drawing.Point(3, 3);
            this.dg_visualizarPassados.MultiSelect = false;
            this.dg_visualizarPassados.Name = "dg_visualizarPassados";
            this.dg_visualizarPassados.ReadOnly = true;
            this.dg_visualizarPassados.RowHeadersVisible = false;
            this.dg_visualizarPassados.RowHeadersWidth = 51;
            this.dg_visualizarPassados.RowTemplate.Height = 24;
            this.dg_visualizarPassados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_visualizarPassados.Size = new System.Drawing.Size(879, 481);
            this.dg_visualizarPassados.TabIndex = 16;
            // 
            // TelaCompromissos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(113)))), ((int)(((byte)(34)))));
            this.BackgroundImage = global::WindowsForms.Properties.Resources.fundo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1382, 753);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.bt_editar);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.bt_excluir);
            this.Controls.Add(this.bt_cadastro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaCompromissos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaCompromissos";
            ((System.ComponentModel.ISupportInitialize)(this.dg_visualizarFuturos)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_visualizarPassados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_editar;
        private System.Windows.Forms.DataGridView dg_visualizarFuturos;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.Button bt_excluir;
        private System.Windows.Forms.Button bt_cadastro;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dg_visualizarPassados;
    }
}