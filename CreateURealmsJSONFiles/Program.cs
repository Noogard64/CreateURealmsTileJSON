using System;

namespace CreateURealmsJSONFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What's the folder path?");
            //var folderPath = Console.ReadLine();

            var folderPath = @"C:\Users\sean-\Desktop\urealms\Tiles\Regirock";

            string[] files = Functions.GetImageFilesAsCollection(folderPath);
            string newJsonFileName = Functions.CreateJSONFileFromTemplate(folderPath);

            foreach (string file in files)
            {
                UploadImage.UploadImageVersion2(file);


                var find = "";
                var replace = "";
                Functions.UpdateJSONFile(newJsonFileName, find, replace);
            }

            Console.WriteLine("Finished!");



        }
    }
}
