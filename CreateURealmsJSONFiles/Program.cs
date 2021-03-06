﻿using System;

namespace CreateURealmsJSONFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What's the folder path?");
            var folderPath = Console.ReadLine();

            //var folderPath = @"C:\Users\sean-\Desktop\urealms\Tiles\Regirock";

            string[] files = Functions.GetImageFilesAsCollection(folderPath);
            string newJsonFileName = Functions.CreateJSONFileFromTemplate(folderPath);

            foreach (string file in files)
            {

                var replace = UploadImage.UploadImageToImgur(file);

                var find = Functions.textToFindInJSON(file);
                Console.WriteLine(find);

                Functions.UpdateJSONFile(newJsonFileName, find, replace);
            }

            
            Console.WriteLine("Finished!");
            Console.ReadKey();


        }
    }
}
