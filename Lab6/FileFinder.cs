using System;
using System.Collections.Generic;
using System.IO;

namespace Lab6_2
{
    class FileFinder
    {
        PlayerItem[] fileArray;
        public void GetFiles(string dirPath)
        {
            DirectoryInfo directory = new DirectoryInfo(dirPath);
            List<PlayerItem> fileList = new List<PlayerItem>();
            int fileCounter = 0;
            foreach (var file in directory.GetFiles())
            {
                string changedName = "." + file.Name.Split('.')[file.Name.Split('.').Length-1];
                switch (changedName)
                {
                    case ".mkv":
                        {
                            fileList.Add(new PlayerItem {fileName = file.Name, File = new mkv() });
                            fileCounter++;
                            break;
                        }
                    case ".mp3":
                        {
                            fileList.Add(new PlayerItem { fileName = file.Name, File = new mp3() });
                            fileCounter++;
                            break;
                        }
                    case ".wav":
                        {
                            fileList.Add(new PlayerItem { fileName = file.Name, File = new wav() });
                            fileCounter++;
                            break;
                        }
                }
                fileArray = new PlayerItem[fileCounter];
                for (int i = 0; i < fileCounter; i++)
                {
                    fileArray[i] = fileList[i];
                }
            }
        }
        public void ShowFiles()
        {
            for (int i = 0; i < fileArray.Length; i++)
            {
                string methods = "";
                foreach (var method in fileArray[i].File.GetType().GetMethods())
                {
                    methods += method.Name + "()  ";
                }
                foreach (var method in typeof(object).GetMethods())
                {
                    int index = methods.IndexOf(method.Name);
                    if (index >=  0)
                    {
                        methods = methods.Remove(index, method.Name.Length + 4);
                    }                    
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(fileArray[i].fileName + ":   ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(methods);
            }
        }
    }
}
