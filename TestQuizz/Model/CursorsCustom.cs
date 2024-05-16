using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestQuizz
{
    internal class CursorsCustom
    {

        public string ball = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "TestQuizz", "Resources", "CursorsBall.png");
       
        public string bua = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "TestQuizz", "Resources", "caybua.png");


        public void ChangeCursors(string path)
        {
            Bitmap cursorBitmap = new Bitmap(new Bitmap(path), 50, 50);
            if (path == bua)
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
