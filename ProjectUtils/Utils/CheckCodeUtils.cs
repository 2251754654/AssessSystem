using System;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectUtils
{
    public class CheckCodeUtils
    {
        //private static Image checkCode = Resources.CheckCode;
        //public static Image GetCheckCode()
        //{

        //    Graphics graphics =  Graphics.FromImage(checkCode);
        //    string check = "";
        //    Random random = new Random();
        //    for (int i=0;i<4;i++)
        //    {
        //        check = check + random.Next() % 10;
        //    }
        //    SolidBrush brush = new SolidBrush(Color.Green);
        //    graphics.DrawString(check,new Font("黑体",2), brush, 0,0);
        //    graphics.DrawLine(new Pen(Color.Red),new Point(0,10), new Point(225, 10));

        //    Bitmap bitmap = new Bitmap(checkCode, new Size(226, 25));
        //    graphics.DrawRectangle(new Pen(Color.Red),new Rectangle(new Point(0,0),new Size(226,25)));
        //    return bitmap;
        //}
    }
}
