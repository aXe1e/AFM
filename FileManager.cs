using System;
using System.IO;

namespace AFM
{
    class FileManager
    {
        private string CurrentDirectory { get; set; }

        public FileManager(string CurrDir)
        {
            cd(CurrDir);
            if (GetCD() == String.Empty)
            {
                cd(@"c:");
            }
        }

        public string GetCD()
        {
            return CurrentDirectory;
        }
        public void ParseCommands(string cmds)
        {
            string[] Args = cmds.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (Args[0])
            {
                case "cd":
                    cd(Args[1]);
                    break;
                case "ls":
                    ls(GetCD());
                    break;
                case "cp":
                    cp(Args[1], Args[2]);
                    break;
                case "mk":
                    mk(Args[1]);
                    break;
                case "del":
                    del(Args[1]);
                    break;
                default:
                    Console.WriteLine($"Неизвестная команда: {Args[0]}");
                    break;
            }
        }

        private void cd(string dir)
        {
            if (Directory.Exists(CurrentDirectory + @"\" + dir))
            {
                CurrentDirectory = CurrentDirectory + @"\" + dir;
            }
            else
            if (Directory.Exists(dir))
            {
                CurrentDirectory = dir;
            }
            else
            {
                Console.WriteLine("Не удается найти указанный путь.");
            }
        }

        private void ls(string path)
        {
            string s = FileTreeRecurse(path, 0);
            Console.WriteLine(s);
        }

        private void cp(string From, string To)
        {
            Console.WriteLine("Копируем");
        }

        private void mk(string DirName)
        {
            Console.WriteLine("Создаем каталог");
        }

        private void del(string Path)
        {
            Console.WriteLine("Удаляем");
        }

        private string FileTreeRecurse(string path, int level)
        {
            if (Directory.Exists(path))
            {
                string[] arrDir = Directory.GetDirectories(path);
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                string s = dirInfo.Name;
                string shiftT = string.Empty;
                for (int i = 0; i < level + 1; i++)
                {
                    shiftT += "   ";
                }
                if (arrDir.Length != 0)
                {
                    foreach (var Dir in dirInfo.GetDirectories())
                    {
                        s += $"\n" + shiftT + FileTreeRecurse(Dir.FullName, level + 1);
                    }
                }
                foreach (var File in dirInfo.GetFiles())
                {
                    s += $"\n" + shiftT + File.Name;
                }
                return s;
            }
            else
            {
                return $"Каталог '{path}' не доступен!";
            }

        }
    }
}
