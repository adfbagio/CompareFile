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
            this.label2 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.dgwdirconflito = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fonte1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fonte2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPasta2 = new System.Windows.Forms.TextBox();
            this.txtPasta1 = new System.Windows.Forms.TextBox();
            this.btnPasta2 = new System.Windows.Forms.Button();
            this.btnPasta1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgwprojetos = new System.Windows.Forms.DataGridView();
            this.cboprojetos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgwtfs = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.didi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fbd1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dgwtfs2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwtfsreal = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.tvTfs = new System.Windows.Forms.TreeView();
            this.btnpesq = new System.Windows.Forms.Button();
            this.dgwretorno = new System.Windows.Forms.DataGridView();
            this.Proj1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proj2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Retorno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwdirconflito)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwprojetos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwtfs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwtfs2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwtfsreal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwretorno)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(713, 702);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label30);
            this.tabPage1.Controls.Add(this.dgwdirconflito);
            this.tabPage1.Controls.Add(this.txtPasta2);
            this.tabPage1.Controls.Add(this.txtPasta1);
            this.tabPage1.Controls.Add(this.btnPasta2);
            this.tabPage1.Controls.Add(this.btnPasta1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(705, 501);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Brown;
            this.label2.Location = new System.Drawing.Point(257, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 18);
            this.label2.TabIndex = 55;
            this.label2.Text = "Compara fontes em Diretórios";
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
            this.txtPasta2.Location = new System.Drawing.Point(101, 120);
            this.txtPasta2.Name = "txtPasta2";
            this.txtPasta2.Size = new System.Drawing.Size(355, 20);
            this.txtPasta2.TabIndex = 52;
            // 
            // txtPasta1
            // 
            this.txtPasta1.Location = new System.Drawing.Point(101, 57);
            this.txtPasta1.Name = "txtPasta1";
            this.txtPasta1.Size = new System.Drawing.Size(355, 20);
            this.txtPasta1.TabIndex = 51;
            // 
            // btnPasta2
            // 
            this.btnPasta2.BackColor = System.Drawing.Color.White;
            this.btnPasta2.Image = ((System.Drawing.Image)(resources.GetObject("btnPasta2.Image")));
            this.btnPasta2.Location = new System.Drawing.Point(31, 83);
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
            this.btnPasta1.Location = new System.Drawing.Point(31, 20);
            this.btnPasta1.Name = "btnPasta1";
            this.btnPasta1.Size = new System.Drawing.Size(64, 57);
            this.btnPasta1.TabIndex = 49;
            this.btnPasta1.UseVisualStyleBackColor = false;
            this.btnPasta1.Click += new System.EventHandler(this.btnPasta1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgwretorno);
            this.tabPage2.Controls.Add(this.btnpesq);
            this.tabPage2.Controls.Add(this.tvTfs);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.dgwtfsreal);
            this.tabPage2.Controls.Add(this.dgwtfs2);
            this.tabPage2.Controls.Add(this.dgwprojetos);
            this.tabPage2.Controls.Add(this.cboprojetos);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.dgwtfs);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(705, 676);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // dgwprojetos
            // 
            this.dgwprojetos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwprojetos.EnableHeadersVisualStyles = false;
            this.dgwprojetos.Location = new System.Drawing.Point(66, 365);
            this.dgwprojetos.Name = "dgwprojetos";
            this.dgwprojetos.RowHeadersVisible = false;
            this.dgwprojetos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwprojetos.Size = new System.Drawing.Size(445, 78);
            this.dgwprojetos.TabIndex = 57;
            this.dgwprojetos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwprojetos_CellContentClick);
            // 
            // cboprojetos
            // 
            this.cboprojetos.FormattingEnabled = true;
            this.cboprojetos.Location = new System.Drawing.Point(9, 33);
            this.cboprojetos.Name = "cboprojetos";
            this.cboprojetos.Size = new System.Drawing.Size(121, 21);
            this.cboprojetos.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(12, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 15);
            this.label1.TabIndex = 55;
            this.label1.Text = "Fontes Conflitantes Entre Projetos do TFS";
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
            this.dgwtfs.Location = new System.Drawing.Point(9, 218);
            this.dgwtfs.Name = "dgwtfs";
            this.dgwtfs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwtfs.Size = new System.Drawing.Size(680, 162);
            this.dgwtfs.TabIndex = 54;
            this.dgwtfs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwtfs_CellContentClick);
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
            // dgwtfs2
            // 
            this.dgwtfs2.AllowUserToAddRows = false;
            this.dgwtfs2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwtfs2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.dgwtfs2.Location = new System.Drawing.Point(9, 218);
            this.dgwtfs2.Name = "dgwtfs2";
            this.dgwtfs2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwtfs2.Size = new System.Drawing.Size(680, 162);
            this.dgwtfs2.TabIndex = 58;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Fontes";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Fonte1";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Fonte2";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "didi";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dgwtfsreal
            // 
            this.dgwtfsreal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwtfsreal.EnableHeadersVisualStyles = false;
            this.dgwtfsreal.Location = new System.Drawing.Point(9, 60);
            this.dgwtfsreal.Name = "dgwtfsreal";
            this.dgwtfsreal.RowHeadersVisible = false;
            this.dgwtfsreal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwtfsreal.Size = new System.Drawing.Size(445, 78);
            this.dgwtfsreal.TabIndex = 59;
            this.dgwtfsreal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwtfsreal_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(282, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 60;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tvTfs
            // 
            this.tvTfs.Location = new System.Drawing.Point(9, 482);
            this.tvTfs.Name = "tvTfs";
            this.tvTfs.Size = new System.Drawing.Size(227, 188);
            this.tvTfs.TabIndex = 61;
            this.tvTfs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTfs_AfterSelect);
            // 
            // btnpesq
            // 
            this.btnpesq.Location = new System.Drawing.Point(242, 482);
            this.btnpesq.Name = "btnpesq";
            this.btnpesq.Size = new System.Drawing.Size(75, 23);
            this.btnpesq.TabIndex = 62;
            this.btnpesq.Text = "Pesquisar";
            this.btnpesq.UseVisualStyleBackColor = true;
            this.btnpesq.Click += new System.EventHandler(this.btnpesq_Click);
            // 
            // dgwretorno
            // 
            this.dgwretorno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwretorno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Proj1,
            this.Proj2,
            this.Retorno});
            this.dgwretorno.EnableHeadersVisualStyles = false;
            this.dgwretorno.Location = new System.Drawing.Point(465, 60);
            this.dgwretorno.Name = "dgwretorno";
            this.dgwretorno.RowHeadersVisible = false;
            this.dgwretorno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwretorno.Size = new System.Drawing.Size(240, 78);
            this.dgwretorno.TabIndex = 63;
            // 
            // Proj1
            // 
            this.Proj1.HeaderText = "Proj1";
            this.Proj1.Name = "Proj1";
            // 
            // Proj2
            // 
            this.Proj2.HeaderText = "Proj2";
            this.Proj2.Name = "Proj2";
            // 
            // Retorno
            // 
            this.Retorno.HeaderText = "Retorno";
            this.Retorno.Name = "Retorno";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 722);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwdirconflito)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwprojetos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwtfs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwtfs2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwtfsreal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwretorno)).EndInit();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboprojetos;
        private System.Windows.Forms.DataGridView dgwprojetos;
        private System.Windows.Forms.DataGridView dgwtfs2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridView dgwtfsreal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView tvTfs;
        private System.Windows.Forms.Button btnpesq;
        private System.Windows.Forms.DataGridView dgwretorno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proj1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proj2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Retorno;
    }
}

