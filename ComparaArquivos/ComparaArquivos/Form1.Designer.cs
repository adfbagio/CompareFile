namespace ComparaArquivos
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label30 = new System.Windows.Forms.Label();
            this.dgwdirconflito = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fonte1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fonte2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPasta2 = new System.Windows.Forms.TextBox();
            this.txtPasta1 = new System.Windows.Forms.TextBox();
            this.btnPasta2 = new System.Windows.Forms.Button();
            this.btnPasta1 = new System.Windows.Forms.Button();
            this.fbd1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dgwtfs = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.didi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwdirconflito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwtfs)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(713, 438);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label30);
            this.tabPage1.Controls.Add(this.dgwdirconflito);
            this.tabPage1.Controls.Add(this.txtPasta2);
            this.tabPage1.Controls.Add(this.txtPasta1);
            this.tabPage1.Controls.Add(this.btnPasta2);
            this.tabPage1.Controls.Add(this.btnPasta1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(705, 412);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.dgwtfs);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(705, 412);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Brown;
            this.label30.Location = new System.Drawing.Point(152, 143);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(130, 15);
            this.label30.TabIndex = 54;
            this.label30.Text = "Fontes Conflitantes";
            // 
            // dgwdirconflito
            // 
            this.dgwdirconflito.AllowUserToAddRows = false;
            this.dgwdirconflito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwdirconflito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.Fonte1,
            this.Fonte2});
            this.dgwdirconflito.Location = new System.Drawing.Point(155, 161);
            this.dgwdirconflito.Name = "dgwdirconflito";
            this.dgwdirconflito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwdirconflito.Size = new System.Drawing.Size(404, 245);
            this.dgwdirconflito.TabIndex = 53;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Fontes";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // Fonte1
            // 
            this.Fonte1.HeaderText = "Fonte1";
            this.Fonte1.Name = "Fonte1";
            // 
            // Fonte2
            // 
            this.Fonte2.HeaderText = "Fonte2";
            this.Fonte2.Name = "Fonte2";
            // 
            // txtPasta2
            // 
            this.txtPasta2.Location = new System.Drawing.Point(101, 109);
            this.txtPasta2.Name = "txtPasta2";
            this.txtPasta2.Size = new System.Drawing.Size(355, 20);
            this.txtPasta2.TabIndex = 52;
            // 
            // txtPasta1
            // 
            this.txtPasta1.Location = new System.Drawing.Point(101, 46);
            this.txtPasta1.Name = "txtPasta1";
            this.txtPasta1.Size = new System.Drawing.Size(355, 20);
            this.txtPasta1.TabIndex = 51;
            // 
            // btnPasta2
            // 
            this.btnPasta2.BackColor = System.Drawing.Color.White;
            this.btnPasta2.Image = ((System.Drawing.Image)(resources.GetObject("btnPasta2.Image")));
            this.btnPasta2.Location = new System.Drawing.Point(31, 72);
            this.btnPasta2.Name = "btnPasta2";
            this.btnPasta2.Size = new System.Drawing.Size(64, 57);
            this.btnPasta2.TabIndex = 50;
            this.btnPasta2.UseVisualStyleBackColor = false;
            this.btnPasta2.Click += new System.EventHandler(this.btnPasta2_Click);
            // 
            // btnPasta1
            // 
            this.btnPasta1.BackColor = System.Drawing.Color.White;
            this.btnPasta1.Image = ((System.Drawing.Image)(resources.GetObject("btnPasta1.Image")));
            this.btnPasta1.Location = new System.Drawing.Point(31, 9);
            this.btnPasta1.Name = "btnPasta1";
            this.btnPasta1.Size = new System.Drawing.Size(64, 57);
            this.btnPasta1.TabIndex = 49;
            this.btnPasta1.UseVisualStyleBackColor = false;
            this.btnPasta1.Click += new System.EventHandler(this.btnPasta1_Click);
            // 
            // dgwtfs
            // 
            this.dgwtfs.AllowUserToAddRows = false;
            this.dgwtfs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwtfs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.didi});
            this.dgwtfs.Location = new System.Drawing.Point(6, 69);
            this.dgwtfs.Name = "dgwtfs";
            this.dgwtfs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwtfs.Size = new System.Drawing.Size(680, 233);
            this.dgwtfs.TabIndex = 54;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Fontes";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Fonte1";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Fonte2";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // didi
            // 
            this.didi.HeaderText = "didi";
            this.didi.Name = "didi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(6, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 15);
            this.label1.TabIndex = 55;
            this.label1.Text = "Fontes Conflitantes Entre Projetos do TFS";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwdirconflito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwtfs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.DataGridView dgwdirconflito;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fonte1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fonte2;
        private System.Windows.Forms.TextBox txtPasta2;
        private System.Windows.Forms.TextBox txtPasta1;
        private System.Windows.Forms.Button btnPasta2;
        private System.Windows.Forms.Button btnPasta1;
        private System.Windows.Forms.FolderBrowserDialog fbd1;
        private System.Windows.Forms.DataGridView dgwtfs;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn didi;
        private System.Windows.Forms.Label label1;
    }
}

