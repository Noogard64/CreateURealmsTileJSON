using System;
using System.IO;
using System.Linq;




namespace CreateURealmsJSONFiles
{
    class Functions
    {
        static public string[] GetImageFilesAsCollection(string folderPath)
        {
            if (folderPath == "")
            {
                folderPath = @"C:\Users\sean-\Desktop\urealms\Tiles\Regirock";
            }

            string[] files = Directory.GetFiles(folderPath);

            return files;

        }

        static public string CreateJSONFileFromTemplate(string folderPath)
        {
            var jsonTemplate = @"C:\Users\sean-\Desktop\Repos\CreateURealmsTileJSON\CreateURealmsJSONFiles\json_Example.json";
            String[] newJsonFile = folderPath.Split('\\');
            var newJsonFileName = folderPath + @"\" + newJsonFile.Last() + ".json";
            File.Copy(jsonTemplate, newJsonFileName, true);
            return newJsonFileName;
        }

        

        static public void UpdateJSONFile(string jsonFile, string find, string replace)
        {
            //string test = File.ReadAllText(newJsonFileName);
            //string replace = test.Replace(textToReplace, url);
        }

        


    }
}
