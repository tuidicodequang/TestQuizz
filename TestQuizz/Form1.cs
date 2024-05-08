using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GemBox.Document;
using TestQuizz.Model;




namespace TestQuizz
{
    public partial class Form1 : Form
    {
        private string currentFilePath;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word Files|*.doc;*.docx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = openFileDialog.FileName;
                DisplayWordDocument(currentFilePath);

            }
        }
        private void DisplayWordDocument(string filePath)
        {
            richTextBox1.Clear(); // Xóa nội dung hiện tại của RichTextBox

            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            DocumentModel document = DocumentModel.Load(filePath);

            foreach (Paragraph paragraph in document.GetChildElements(true, ElementType.Paragraph))
            {
                foreach (Run run in paragraph.GetChildElements(true, ElementType.Run))
                {
                    string text = run.Text;
                    var font = run.CharacterFormat.FontName;
                    var fontSize = run.CharacterFormat.Size;
                    var color = run.CharacterFormat.FontColor;
                    var isBold = run.CharacterFormat.Bold;

                    // Tạo một font mới dựa trên thông tin từ GemBox.Document
                    Font richTextBoxFont = new Font(font, (float)fontSize);
                    System.Drawing.FontStyle fontStyle = isBold ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular;

                    richTextBox1.SelectionFont = new Font(richTextBoxFont, fontStyle);
                    richTextBox1.SelectionColor = System.Drawing.Color.FromArgb(color.R, color.G, color.B);

                    richTextBox1.AppendText(text);
                }

                richTextBox1.AppendText(Environment.NewLine);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentFilePath != null)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn lưu câu hỏi không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SaveQuestionToDatabase();
                    MessageBox.Show("Câu hỏi đã được lưu vào cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng mở tập tin trước khi lưu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveQuestionToDatabase()
        {
            try
            {
                // Tạo một danh sách các câu hỏi để lưu vào cơ sở dữ liệu
                List<CauHoi> danhSachCauHoi = new List<CauHoi>();

                // Phân tách nội dung của richTextBox thành các dòng
                string[] lines = richTextBox1.Lines;

                // Lặp qua từng dòng và tạo câu hỏi
                for (int i = 0; i + 4 < lines.Length; i += 5)
                {
                    // Kiểm tra từng dòng của câu trả lời để xác định đáp án đúng
                    string dapAnDung = "";
                    int dapAnDungIndex = -1;
                    for (int j = 1; j <= 4; j++)
                    {
                        // Kiểm tra xem dòng nào là đáp án đúng
                        bool isRed = IsRedColor(richTextBox1, i + j);
                        if (isRed)
                        {
                            dapAnDung = lines[i + j].Trim();
                            dapAnDungIndex = j;
                            break;
                        }
                    }

                    // Nếu không tìm thấy đáp án đúng, thông báo lỗi và bỏ qua câu hỏi này
                    if (dapAnDungIndex == -1)
                    {
                        MessageBox.Show("Không tìm thấy đáp án đúng cho câu hỏi: " + lines[i].Trim(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    // Tạo câu hỏi và gán các thuộc tính
                    CauHoi cauHoi = new CauHoi
                    {
                        ID = RandomQuestionId(), // Sử dụng hàm tạo mã câu hỏi ngẫu nhiên
                        Mon = "Toán", // Thiết lập môn cho câu hỏi (bạn có thể sửa lại nếu cần)
                        NoiDung = lines[i].Trim(),
                        DapAnDung = dapAnDung,
                        DapAn1 = dapAnDungIndex == 1 ? lines[i + 2].Trim() : dapAnDungIndex == 2 ? lines[i + 1].Trim() : dapAnDungIndex == 3 ? lines[i + 1].Trim() : dapAnDungIndex == 4 ? lines[i + 1].Trim() : "",
                        DapAn2 = dapAnDungIndex == 1 ? lines[i + 3].Trim() : dapAnDungIndex == 2 ? lines[i + 3].Trim() : dapAnDungIndex == 3 ? lines[i + 2].Trim() : dapAnDungIndex == 4 ? lines[i + 2].Trim() : "",
                        DapAn3 = dapAnDungIndex == 1 ? lines[i + 4].Trim() : dapAnDungIndex == 2 ? lines[i + 4].Trim() : dapAnDungIndex == 3 ? lines[i + 4].Trim() : dapAnDungIndex == 4 ? lines[i + 3].Trim() : "",
                    };

                    MessageBox.Show(cauHoi.ID + " " + cauHoi.DapAnDung+ dapAnDungIndex.ToString());
                    danhSachCauHoi.Add(cauHoi);
                }

                // Lưu danh sách câu hỏi vào cơ sở dữ liệu
                foreach (CauHoi cauHoi in danhSachCauHoi)
                {
                    DBUtils dbUtils = new DBUtils();
                    dbUtils.InsertCauHoiVaoThuVienCauHoi(cauHoi);
                }

                // Hiển thị thông báo khi hoàn thành lưu câu hỏi
                MessageBox.Show("Các câu hỏi đã được lưu vào cơ sở dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo nếu có lỗi xảy ra
                MessageBox.Show("Đã xảy ra lỗi khi lưu câu hỏi vào cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsRedColor(RichTextBox richTextBox, int lineIndex)
        {
            int startIndex = richTextBox.GetFirstCharIndexFromLine(lineIndex);
            int length = richTextBox.Lines[lineIndex].Length;

            // Di chuyển con trỏ đến vị trí bắt đầu của dòng
            richTextBox.Select(startIndex, length);

            // Kiểm tra màu của dòng
            System.Drawing.Color color = richTextBox.SelectionColor;
            return color == System.Drawing.Color.Red;
        }


        private string RandomQuestionId()
        {
            const string chars = "0123456789";
            Random random = new Random();
            char[] randomArray = new char[4]; 

            for (int i = 0; i < 4; i++)
            {
                randomArray[i] = chars[random.Next(chars.Length)];
            }
            string IdcauHoi = "CH" + new string(randomArray);
            return IdcauHoi;
        }

    }
}
    
    

