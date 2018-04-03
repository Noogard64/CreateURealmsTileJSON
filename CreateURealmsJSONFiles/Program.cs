using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CreateURealmsJSONFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What's the folder path?");
            var folderPath = Console.ReadLine();

            if (Directory.Exists(folderPath))
            {

                var varBase = "";
                var varBlind = "";
                var varBurning = "";
                var varCharmed = "";
                var varDefeated = "";
                var varFrozen = "";
                var varPoisoned = "";
                var varSilenced = "";
                var varStunned = "";



                string [] files = Directory.GetFiles(folderPath);
                foreach (string file in files)
                {
                    Console.WriteLine("Processing " + file.ToString());

                    var fileName = file.ToString();

                    var logFile = @"C:\Users\Sean\AppData\Roaming\EasyImgur\easyimgur.log";
                    File.Delete(logFile);

                    Bat.ExecuteCommand(@"C:\Users\Sean\Downloads\EasyImgur_v0-3-6\EasyImgur.exe " + fileName);

                    do
                    {
                        System.Threading.Thread.Sleep(1000);
                    } while (File.Exists(logFile) == false);

                    var lastLine = "";
                    do
                    {
                        try
                        {
                            lastLine = File.ReadLines(@"C:\Users\Sean\AppData\Roaming\EasyImgur\easyimgur.log").Last();
                        }
                        catch (Exception e)
                        {
                            //Console.WriteLine(e);
                        }
                    } while (lastLine.Contains("Showed tooltip with title \"Success!\" and text \"Upload placed in history:") == false);

                    var url = lastLine.Remove(0, 107);
                    url = lastLine.Replace("\".","");

                    Console.WriteLine(url);
 
                    Console.ReadKey();


                    /*
                    if (fileName.Contains("saved_BaseTile"))
                    {
                        varBase = lastLine.Replace(,"")
                    }

                     = "";
                    varBlind = "";
                    varBurning = "";
                    varCharmed = "";
                    varDefeated = "";
                    varFrozen = "";
                    varPoisoned = "";
                    varSilenced = "";
                    varStunned = "";
                    */
                }

            }

            Console.ReadKey();



        }
    }
}
