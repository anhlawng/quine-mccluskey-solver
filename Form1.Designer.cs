namespace QmcSolver
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtInput = new TextBox();
            label2 = new Label();
            txtDontCares = new TextBox();
            btnSolve = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabControl2 = new TabControl();
            tabPage3 = new TabPage();
            rtbSteps = new RichTextBox();
            tabPage4 = new TabPage();
            dgvPIChart = new DataGridView();
            tabPage2 = new TabPage();
            dgvKMap = new DataGridView();
            btnClear = new Button();
            groupBox1 = new GroupBox();
            label3 = new Label();
            rbPOS = new RadioButton();
            rbSOP = new RadioButton();
            txtResult = new TextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPIChart).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKMap).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 43);
            label1.Name = "label1";
            label1.Size = new Size(145, 23);
            label1.TabIndex = 0;
            label1.Text = " Nhập Minterms:";
            label1.Click += label1_Click;
            // 
            // txtInput
            // 
            txtInput.Location = new Point(17, 111);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(198, 31);
            txtInput.TabIndex = 1;
            txtInput.TextChanged += txtMinterms_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 214);
            label2.Name = "label2";
            label2.Size = new Size(157, 25);
            label2.TabIndex = 2;
            label2.Text = "Nhập Don't Care:";
            // 
            // txtDontCares
            // 
            txtDontCares.Location = new Point(17, 261);
            txtDontCares.Name = "txtDontCares";
            txtDontCares.Size = new Size(198, 31);
            txtDontCares.TabIndex = 4;
            txtDontCares.TextChanged += txtDontCares_TextChanged;
            // 
            // btnSolve
            // 
            btnSolve.BackColor = Color.DodgerBlue;
            btnSolve.FlatStyle = FlatStyle.Flat;
            btnSolve.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSolve.ForeColor = SystemColors.ButtonHighlight;
            btnSolve.Location = new Point(164, 433);
            btnSolve.Name = "btnSolve";
            btnSolve.Size = new Size(129, 33);
            btnSolve.TabIndex = 5;
            btnSolve.Text = "⚡ Rút gọn";
            btnSolve.UseVisualStyleBackColor = false;
            btnSolve.Click += btnSolve_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(310, 14);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(590, 402);
            tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tabControl2);
            tabPage1.Location = new Point(4, 32);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(582, 366);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Quine-McCluskey";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage3);
            tabControl2.Controls.Add(tabPage4);
            tabControl2.Dock = DockStyle.Fill;
            tabControl2.Location = new Point(3, 3);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(576, 360);
            tabControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(rtbSteps);
            tabPage3.ForeColor = SystemColors.ActiveCaptionText;
            tabPage3.Location = new Point(4, 32);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(568, 324);
            tabPage3.TabIndex = 0;
            tabPage3.Text = "Gom Nhóm";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // rtbSteps
            // 
            rtbSteps.BorderStyle = BorderStyle.None;
            rtbSteps.Dock = DockStyle.Fill;
            rtbSteps.Location = new Point(3, 3);
            rtbSteps.Name = "rtbSteps";
            rtbSteps.Size = new Size(562, 318);
            rtbSteps.TabIndex = 6;
            rtbSteps.Text = "";
            rtbSteps.TextChanged += rtbSteps_TextChanged;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(dgvPIChart);
            tabPage4.ForeColor = SystemColors.ButtonHighlight;
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(568, 327);
            tabPage4.TabIndex = 1;
            tabPage4.Text = "Bảng triệt tiêu";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvPIChart
            // 
            dgvPIChart.BackgroundColor = SystemColors.ButtonHighlight;
            dgvPIChart.BorderStyle = BorderStyle.None;
            dgvPIChart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPIChart.Dock = DockStyle.Fill;
            dgvPIChart.Location = new Point(3, 3);
            dgvPIChart.Name = "dgvPIChart";
            dgvPIChart.RowHeadersWidth = 51;
            dgvPIChart.Size = new Size(562, 321);
            dgvPIChart.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvKMap);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(582, 369);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Bản đồ Karnaugh";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // dgvKMap
            // 
            dgvKMap.AllowUserToAddRows = false;
            dgvKMap.BackgroundColor = SystemColors.ButtonHighlight;
            dgvKMap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKMap.Location = new Point(0, 0);
            dgvKMap.Name = "dgvKMap";
            dgvKMap.ReadOnly = true;
            dgvKMap.RowHeadersVisible = false;
            dgvKMap.RowHeadersWidth = 51;
            dgvKMap.Size = new Size(580, 369);
            dgvKMap.TabIndex = 0;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Red;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = SystemColors.ButtonHighlight;
            btnClear.Location = new Point(12, 434);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(123, 33);
            btnClear.TabIndex = 8;
            btnClear.Text = "🔄 Làm mới";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(rbPOS);
            groupBox1.Controls.Add(rbSOP);
            groupBox1.Controls.Add(txtDontCares);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtInput);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(296, 413);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Giá trị đầu vào";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(24, 144);
            label3.Name = "label3";
            label3.Size = new Size(85, 17);
            label3.TabIndex = 7;
            label3.Text = "Ví dụ : 0,1,2,3";
            // 
            // rbPOS
            // 
            rbPOS.AutoSize = true;
            rbPOS.Location = new Point(161, 69);
            rbPOS.Name = "rbPOS";
            rbPOS.Size = new Size(129, 29);
            rbPOS.TabIndex = 6;
            rbPOS.TabStop = true;
            rbPOS.Text = "POS - Π(m)";
            rbPOS.UseVisualStyleBackColor = true;
            // 
            // rbSOP
            // 
            rbSOP.AutoSize = true;
            rbSOP.Location = new Point(24, 69);
            rbSOP.Name = "rbSOP";
            rbSOP.Size = new Size(125, 29);
            rbSOP.TabIndex = 5;
            rbSOP.TabStop = true;
            rbSOP.Text = "SOP - Σ(m)";
            rbSOP.UseVisualStyleBackColor = true;
            rbSOP.CheckedChanged += rbSOP_CheckedChanged;
            rbSOP.KeyPress += rbSOP_KeyPress;
            // 
            // txtResult
            // 
            txtResult.BorderStyle = BorderStyle.None;
            txtResult.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtResult.Location = new Point(317, 437);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.ScrollBars = ScrollBars.Vertical;
            txtResult.Size = new Size(576, 34);
            txtResult.TabIndex = 10;
            txtResult.TextChanged += txtResult_TextChanged;
            // 
            // Form1
            // 
            AcceptButton = btnSolve;
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(900, 518);
            Controls.Add(txtResult);
            Controls.Add(groupBox1);
            Controls.Add(btnClear);
            Controls.Add(tabControl1);
            Controls.Add(btnSolve);
            Font = new Font("Segoe UI", 10F);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPIChart).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKMap).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtInput;
        private Label label2;
        private TextBox txtDontCares;
        private Button btnSolve;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dgvPIChart;
        private Button btnClear;
        private TabControl tabControl2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private RichTextBox rtbSteps;
        private DataGridView dgvKMap;
        private GroupBox groupBox1;
        private RadioButton rbPOS;
        private RadioButton rbSOP;
        private Label label3;
        private TextBox txtResult;
    }
}
