using System;
using System.IO;
using System.Threading;

namespace Batch_Loader
{
    class Program
    {
        public static string fileSourcePath = @"C:\Users\sprouse\Desktop\ADMPL3\ADMPL3\";
        public static string targetDestination = @"E:\ECJData\LIVE\Data\PCS_inbound_LIVE\";
        public static string[] fileList = Directory.GetFiles(fileSourcePath);
        static void Main(string[] args)
        {
            int pauseInterval = 60;
            int counter = 0;
            string[] fileList = Directory.GetFiles(fileSourcePath);

            while (fileList.Length >= counter)
            {
                counter++;
                BatchMoveFiles(20);
                Console.WriteLine("Pausing for " + pauseInterval + " seconds --- {0} Files remaining.", + fileList.Length - counter * 20);
                Thread.Sleep(TimeSpan.FromSeconds(pauseInterval)); 
            }
        }

        static void BatchMoveFiles(int batchVolume)
        {
            fileList = Directory.GetFiles(fileSourcePath);
            for (int i = 1; i < batchVolume; i++)
            {
                File.Move(fileList[i], targetDestination + fileList[i].Replace(fileSourcePath, ""));
                Console.WriteLine(DateTime.Now.TimeOfDay.ToString() + "...Moving file " + fileList[i].Replace(fileSourcePath, ""));
            }
        }
    }
}
