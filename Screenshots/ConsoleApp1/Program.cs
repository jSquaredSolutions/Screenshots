using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO; 




namespace ConsoleApp1

{

    class Program

    {

        static public void Main()
        {
            Application.Run(Main);
        }
    
        public static void MainProgram()
        {
            Timer t = new Timer(); // set the time (5 min in this case)
            t.Interval = 3000;
            t.Tick += new EventHandler(FullScreenshot);
            t.Start();
            ImageFormat.Jpeg
        }

        private static void FullScreenshot(Object myObject, EventArgs myEventArgs)
        {

            Rectangle bounds = Screen.GetBounds(Point.Empty);

            // If you want to look at a specific part of the screen us the below
            //bounds.Width = 70;
            //bounds.Height = 50;

            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))

            {
                using (Graphics g = Graphics.FromImage(bitmap))

                {
                    // If you want to look at a specific part of the screen us the below
                    // g.CopyFromScreen(new Point(339), new Point(33), bounds.Size);
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }                
                string fullpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "screenshot_" + DateTime.Now + ".jpg";
                bitmap.Save(fullpath, ImageFormat.Jpeg);
            }

        }

    }

}













