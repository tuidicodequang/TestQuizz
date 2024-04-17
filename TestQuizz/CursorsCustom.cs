using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestQuizz
{
    internal class CursorsCustom
    {

        public string ball = "C:\\Users\\manno\\OneDrive\\Desktop\\hoc c#\\TestQuizz\\TestQuizz\\Resources\\CursorsBall.png";
        public string bua = "C:\\Users\\manno\\OneDrive\\Desktop\\hoc c#\\TestQuizz\\TestQuizz\\Resources\\caybua.png";


    public void ChangeCursors(string path)
        {
            Bitmap cursorBitmap = new Bitmap(new Bitmap(path), 50, 50);
            if (path == "C:\\Users\\manno\\OneDrive\\Desktop\\hoc c#\\TestQuizz\\TestQuizz\\Resources\\caybua.png")
            {
                 cursorBitmap = new Bitmap(new Bitmap(path), 250, 250);
            }
         
            // Tạo một IntPtr từ hình ảnh Bitmap
            IntPtr ptr = cursorBitmap.GetHicon();

            // Tạo một Cursor từ IntPtr
            Cursor cursor = new Cursor(ptr);

            // Thay đổi con trỏ của ứng dụng thành con trỏ mới
            Cursor.Current = cursor;

            //     // Giải phóng tài nguyên
            cursorBitmap.Dispose();
        }
      
    }
}
