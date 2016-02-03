using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace CreateRightBadgeTiles
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Import your path of the {appName}BadgeTile with out .scale-100.png!!!!! e.g.C:\\Assets\\AppNameBadgeTile");
            string fileroute = Console.ReadLine();
            if (fileroute != null)
            {
                Console.WriteLine("Program started...."); 
                int[] resolutions = new int[] { 100, 125, 150, 200, 400 };
                for (int i = 0; i < resolutions.Length; i++)
                {
                    Console.WriteLine("Start process image " + resolutions[i]);

                    Bitmap bitmap = new Bitmap(fileroute + $".scale-{resolutions[i]}.png");
                    con2Badge(bitmap, fileroute, resolutions[i]);
                    Console.WriteLine("End process image " + resolutions[i]);
                }
                Console.WriteLine("Process completed");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("There was an error, try again");
                Console.ReadLine();
            }
        }

        private static void con2Badge(Bitmap img, string filename, int resolution)
        {
            var destImage = new Bitmap(img.Width, img.Height, PixelFormat.Format32bppArgb);
            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    var srcCol = img.GetPixel(x, y);
                    var avgInt = ((((int)srcCol.R + (int)srcCol.G + (int)srcCol.B) / 3) * (int)srcCol.A) / 255;
                    var desCol = Color.FromArgb((byte)avgInt, Color.White);
                    destImage.SetPixel(x, y, desCol);
                }
            }
            destImage.Save(filename + $".new.scale-{resolution}.png", ImageFormat.Png);
        }
    }
}