using System;

namespace AFM
{
    class Program
    {
        static void Main(string[] args)
        {
            FileManager AFS = new FileManager(@"c:\aaa");
            string cmds = string.Empty;
            do
            {
                Console.Write(AFS.GetCD() + ">");
                cmds = Console.ReadLine().ToLower();

                if (cmds != "quit")
                {
                    AFS.ParseCommands(cmds);
                }
            } while (cmds != "quit");
        }
    }
}
