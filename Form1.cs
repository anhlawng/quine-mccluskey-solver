using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuineMcCluskeySolver.Core; 

namespace QmcSolver
{
    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        public Form1()
        {
            InitializeComponent();
            rbSOP.Checked = true;
            this.BackColor = Color.White;

            btnSolve.FlatStyle = FlatStyle.Flat;
            btnSolve.FlatAppearance.BorderSize = 0;
            btnSolve.BackColor = ColorTranslator.FromHtml("#2563EB");
            btnSolve.ForeColor = Color.White;
            btnSolve.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.BackColor = ColorTranslator.FromHtml("#F5F7FA");
            btnClear.ForeColor = ColorTranslator.FromHtml("#2563EB");
            btnClear.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            btnSolve.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSolve.Width, btnSolve.Height, 10, 10));
            btnClear.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnClear.Width, btnClear.Height, 10, 10));
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }
        private List<int> ParseInput(string input)
        {
            List<int> result = new List<int>();
            if (string.IsNullOrWhiteSpace(input)) return result;

            string[] parts = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string part in parts)
            {
                if (int.TryParse(part, out int number))
                {
                    if (number < 0)
                    {
                        throw new FormatException($"Giá trị '{number}' không hợp lệ. Minterm/Maxterm không được là số âm!");
                    }
                    result.Add(number);
                }
                else
                {
                    throw new FormatException($"Phát hiện ký tự lạ '{part}'. Vui lòng chỉ nhập số và dấu phẩy!");
                }
            }
            return result.Distinct().OrderBy(n => n).ToList();
        }
        private string GetBooleanExpression(Implicant imp, int numVars)
        {
            string result = "";
            for (int i = 0; i < numVars; i++)
            {
                int bitPos = numVars - 1 - i;
                int bitMask = 1 << bitPos;

                if ((imp.Mask & bitMask) == 0)
                {
                    string varName = (i < 26) ? ((char)('A' + i)).ToString() : "v" + i;

                    if ((imp.Value & bitMask) == 0)
                        result += varName + "\u0305"; 
                    else
                        result += varName;
                }
            }
            return string.IsNullOrEmpty(result) ? "1" : result;
        }

        private string GetPosExpression(Implicant imp, int numVars)
        {
            List<string> terms = new List<string>();
            for (int i = 0; i < numVars; i++)
            {
                int bitPos = numVars - 1 - i;
                int bitMask = 1 << bitPos;

                if ((imp.Mask & bitMask) == 0)
                {
                    string varName = (i < 26) ? ((char)('A' + i)).ToString() : "v" + i;

                    if ((imp.Value & bitMask) != 0)
                        terms.Add(varName + "\u0305");
                    else
                        terms.Add(varName);
                }
            }
            if (terms.Count == 0) return "0";
            return "(" + string.Join(" + ", terms) + ")";
        }
        private void DrawKMap4Vars(List<int> minterms, List<int> dontCares)
        {
            dgvKMap.Columns.Clear();
            dgvKMap.Rows.Clear();
            dgvKMap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;           
            dgvKMap.RowHeadersVisible = false;
            dgvKMap.ScrollBars = ScrollBars.None;         
            dgvKMap.AllowUserToResizeColumns = false;
            dgvKMap.AllowUserToResizeRows = false;
            dgvKMap.Columns.Add("header", "AB \\ CD");
            dgvKMap.Columns.Add("col00", "00");
            dgvKMap.Columns.Add("col01", "01");
            dgvKMap.Columns.Add("col11", "11");
            dgvKMap.Columns.Add("col10", "10");

            int[,] kmapMinterms = new int[4, 4] {
    { 0, 1, 3, 2 },   
        { 4, 5, 7, 6 },   
        { 12, 13, 15, 14 },  
        { 8, 9, 11, 10 }   
    };
           string[] rowHeaders = { "00", "01", "11", "10" };        
            for (int i = 0; i < 4; i++)
            {
                int rowIndex = dgvKMap.Rows.Add();
                dgvKMap.Rows[rowIndex].Cells[0].Value = rowHeaders[i];
                dgvKMap.Rows[rowIndex].Cells[0].Style.BackColor = Color.LightGray;
                dgvKMap.Rows[rowIndex].Cells[0].Style.Font = new Font("Arial", 10, FontStyle.Bold);

                for (int j = 0; j < 4; j++)
                {
                    int m = kmapMinterms[i, j];
                    string cellValue = "0";
                    if (minterms.Contains(m)) cellValue = "1";
                    else if (dontCares.Contains(m)) cellValue = "X";                  
                    dgvKMap.Rows[rowIndex].Cells[j + 1].Value = cellValue;
                    dgvKMap.Rows[rowIndex].Cells[j + 1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvKMap.Rows[rowIndex].Cells[j + 1].Style.Font = new Font("Arial", 12, FontStyle.Bold);
                }
            }
        }
        private Point GetKMapCell(int minterm)
        {
            int[,] kmapMinterms = new int[4, 4] {
    { 0, 1, 3, 2 },
    { 4, 5, 7, 6 },
    { 12, 13, 15, 14 },
    { 8, 9, 11, 10 }
  };

            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < 4; c++)
                {
                    if (kmapMinterms[r, c] == minterm)
                    {                  
                        return new Point(c + 1, r);
                    }
                }
            }
            return new Point(-1, -1);
        }
        private void ColorKMap(List<Implicant> finalImplicants)
        {
            Color[] palette = {
    Color.LightPink, Color.LightSkyBlue, Color.LightGreen,
    Color.Khaki, Color.Plum, Color.PeachPuff, Color.Aquamarine
  };
            int colorIndex = 0;

            foreach (var imp in finalImplicants)
            {
                Color currentColor = palette[colorIndex % palette.Length];
                foreach (int m in imp.MinTerms)
                {
                    Point cell = GetKMapCell(m);
                    if (cell.X != -1)
                    {                    
                        dgvKMap.Rows[cell.Y].Cells[cell.X].Style.BackColor = currentColor;
                    }
                }
                colorIndex++;
            }
        }
        private void btnSolve_Click(object sender, EventArgs e)
        {
            try
            {
                rtbSteps.Clear(); 
                txtResult.Text = "Kết quả: Đang tính toán...";
                List<int> inputData = ParseInput(txtInput.Text);
                List<int> dontCares = ParseInput(txtDontCares.Text);

                if (inputData.Count == 0)
                {
                    MessageBox.Show("Vui lòng nhập ít nhất 1 số liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }          
                int maxVal = inputData.Concat(dontCares).DefaultIfEmpty(0).Max();
                int numVars = Math.Max(1, (int)Math.Ceiling(Math.Log(maxVal + 1, 2)));
                
                List<int> minterms = new List<int>();

                if (rbSOP.Checked)
                {
                    minterms = new List<int>(inputData);
                }
                else if (rbPOS.Checked)
                {
                    int totalCases = 1 << numVars; 
                    for (int i = 0; i < totalCases; i++)
                    {
                        if (!inputData.Contains(i) && !dontCares.Contains(i))
                        {
                            minterms.Add(i);
                        }
                    }
                }               
                
                rtbSteps.AppendText($"--- BƯỚC 1: KHỞI TẠO (Số biến: {numVars}) ---\n");
             
                HashSet<Implicant> currentImplicants = new HashSet<Implicant>();
                foreach (int m in minterms) currentImplicants.Add(new Implicant(m, numVars));
                foreach (int d in dontCares) currentImplicants.Add(new Implicant(d, numVars));

                HashSet<Implicant> primeImplicants = new HashSet<Implicant>();
                int step = 1;
             
                while (currentImplicants.Count > 0)
                {
                    rtbSteps.AppendText($"\n--- BƯỚC {step + 1}: GHÉP CẶP BẬC {step} ---\n");
                    HashSet<Implicant> nextImplicants = new HashSet<Implicant>();                  
                    var groups = currentImplicants.GroupBy(i => i.CountOnes()).OrderBy(g => g.Key).ToList();
                    for (int i = 0; i < groups.Count - 1; i++)
                    {
                        var groupA = groups[i].ToList();
                        var groupB = groups[i + 1].ToList();

                        foreach (var a in groupA)
                        {
                            foreach (var b in groupB)
                            {
                                if (a.CanCombineWith(b))
                                {
                                    Implicant combined = Implicant.Combine(a, b);
                                    nextImplicants.Add(combined);                                
                                    string mintermList = string.Join(", ", combined.MinTerms.OrderBy(m => m));                                  
                                    rtbSteps.AppendText($"({mintermList}) ghép {a} và {b} => {combined}\n");
                                }
                            }
                        }
                    }                   
                    foreach (var imp in currentImplicants)
                    {
                        if (!imp.WasCombined) primeImplicants.Add(imp);
                    }
                    currentImplicants = nextImplicants; 
                    step++;
                }             
                rtbSteps.AppendText("\n--- DANH SÁCH PRIME IMPLICANTS (PI) TÌM ĐƯỢC ---\n");
                foreach (var pi in primeImplicants)
                {                   
                    var realMinterms = pi.MinTerms.Where(m => minterms.Contains(m));
                    rtbSteps.AppendText($"- {pi} (Bao phủ: {string.Join(", ", realMinterms)})\n");
                }             
                List<Implicant> finalImplicants = new List<Implicant>();
                List<int> uncoveredMinterms = new List<int>(minterms);       
                foreach (int m in minterms)
                {
                    var coveringPIs = primeImplicants.Where(pi => pi.MinTerms.Contains(m)).ToList();
                    if (coveringPIs.Count == 1) 
                    {
                        var epi = coveringPIs[0];
                        if (!finalImplicants.Contains(epi))
                        {
                            finalImplicants.Add(epi);                         
                            uncoveredMinterms.RemoveAll(x => epi.MinTerms.Contains(x));
                        }
                    }
                }            
                while (uncoveredMinterms.Count > 0)
                {                
                    var bestPI = primeImplicants
            .OrderByDescending(pi => pi.MinTerms.Count(m => uncoveredMinterms.Contains(m)))
            .First();

                    finalImplicants.Add(bestPI);
                    uncoveredMinterms.RemoveAll(x => bestPI.MinTerms.Contains(x));
                }               
                List<string> termStrings = new List<string>();
                string finalExpression = "";

                if (rbSOP.Checked)
                {                
                    foreach (var imp in finalImplicants) termStrings.Add(GetBooleanExpression(imp, numVars));
                    finalExpression = "Y = " + string.Join(" + ", termStrings);
                }
                else
                {                
                    foreach (var imp in finalImplicants) termStrings.Add(GetPosExpression(imp, numVars));
                    finalExpression = "Y = " + string.Join(" . ", termStrings);
                }            
                txtResult.Text = finalExpression;          
                dgvPIChart.Columns.Clear();
                dgvPIChart.Rows.Clear();
                dgvPIChart.DefaultCellStyle.ForeColor = Color.Black;
                dgvPIChart.DefaultCellStyle.BackColor = Color.White;             
                dgvPIChart.Columns.Add("colPI", "Prime Implicant");
                dgvPIChart.Columns["colPI"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvPIChart.Columns["colPI"].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);             
                foreach (int m in minterms)
                {
                    string colName = $"col_{m}";
                    dgvPIChart.Columns.Add(colName, m.ToString());
                    dgvPIChart.Columns[colName].Width = 50;
                    dgvPIChart.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }             
                foreach (var pi in primeImplicants)
                {
                    int rowIndex = dgvPIChart.Rows.Add();               
                    string piName = $"{GetBooleanExpression(pi, numVars)} ({pi})";
                    dgvPIChart.Rows[rowIndex].Cells[0].Value = piName;                 
                    if (finalImplicants.Contains(pi))
                    {
                        dgvPIChart.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                    }                 
                    int colIndex = 1;
                    foreach (int m in minterms)
                    {
                        if (pi.MinTerms.Contains(m))
                        {
                            dgvPIChart.Rows[rowIndex].Cells[colIndex].Value = "X";
                            dgvPIChart.Rows[rowIndex].Cells[colIndex].Style.ForeColor = Color.Red;
                            dgvPIChart.Rows[rowIndex].Cells[colIndex].Style.Font = new Font("Arial", 10, FontStyle.Bold);
                        }
                        colIndex++;
                    }
                }
                if (numVars <= 4)
                {
                    DrawKMap4Vars(minterms, dontCares);
                    ColorKMap(finalImplicants);
                }
                else
                {                  
                    dgvKMap.Columns.Clear();
                    dgvKMap.Rows.Clear();
                    dgvKMap.Columns.Add("msg", "Thông báo");
                    dgvKMap.Columns["msg"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvKMap.Rows.Add($"Bản đồ Karnaugh trên phần mềm tạm thời hỗ trợ tốt nhất cho 4 biến. Mạch của bạn đang có {numVars} biến, vui lòng xem kết quả ở tab Quine-McCluskey.");
                }             
                dgvPIChart.AllowUserToAddRows = false;
                dgvPIChart.ReadOnly = true;
                rtbSteps.AppendText("\n--- BƯỚC 4: LẬP BẢNG TRIỆT TIÊU ---\n");
                rtbSteps.AppendText("Các số hạng được chọn để tối ưu nhất:\n");
                foreach (var imp in finalImplicants)
                {
                    rtbSteps.AppendText($"- {imp} -> {GetBooleanExpression(imp, numVars)}\n");
                }
                rtbSteps.AppendText($"\n=> KẾT QUẢ CUỐI CÙNG:\n{finalExpression}\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void rtbSteps_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
            txtDontCares.Clear();
            rtbSteps.Clear();
            txtResult.Text = "Kết quả:";          
            if (dgvPIChart.Columns.Count > 0)
            {
                dgvPIChart.Columns.Clear();
                dgvPIChart.Rows.Clear();
            }

            if (dgvKMap.Columns.Count > 0)
            {
                dgvKMap.Columns.Clear();
                dgvKMap.Rows.Clear();
            }

            txtInput.Focus(); 
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txtMinterms_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbSOP_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbSOP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtDontCares_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtResult_TextChanged(object sender, EventArgs e)
        {

        }
    }
}