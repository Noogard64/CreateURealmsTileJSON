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
            string fileContent = File.ReadAllText(jsonFile);
            string updatedFileContent = fileContent.Replace(find, replace);
            File.WriteAllText(jsonFile, updatedFileContent);

        }

        static public string textToFindInJSON(string file)
        {

            string find;
            if (file.Contains("Blind"))
            {
                find = "insert blind url here";
            }
            else if(file.Contains("Burning")){
                find = "insert burning url here";
            }
            else if(file.Contains("Charmed")){
                find = "insert charmed url here";
            }
            else if(file.Contains("Defeated")){
                find = "insert defeated url here";
            }
            else if(file.Contains("Frozen")){
                find = "insert frozen url here";
            }
            else if(file.Contains("Poisoned")){
                find = "insert poisoned url here";
            }
            else if(file.Contains("Silenced")){
                find = "insert silenced url here";
            }
            else if(file.Contains("Stunned")){
                find = "insert stunned url here";
            }
            else{
                find = "insert base url here";
            }
            return find;
        }

        


    }
}
