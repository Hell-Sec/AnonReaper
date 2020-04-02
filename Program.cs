using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;
using System.IO;
using System.Net;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Management;

namespace AnonReaper
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        private static bool MainMenu()
        {
            Console.Title = ("Lucifer's Angel | Anon-Reaper");
            Console.ForegroundColor = Color.MediumPurple;
            Console.Clear();
            Console.WriteLine(@"░█████╗░███╗░░██╗░█████╗░███╗░░██╗  ██████╗░███████╗░█████╗░██████╗░███████╗██████╗░
██╔══██╗████╗░██║██╔══██╗████╗░██║  ██╔══██╗██╔════╝██╔══██╗██╔══██╗██╔════╝██╔══██╗
███████║██╔██╗██║██║░░██║██╔██╗██║  ██████╔╝█████╗░░███████║██████╔╝█████╗░░██████╔╝
██╔══██║██║╚████║██║░░██║██║╚████║  ██╔══██╗██╔══╝░░██╔══██║██╔═══╝░██╔══╝░░██╔══██╗
██║░░██║██║░╚███║╚█████╔╝██║░╚███║  ██║░░██║███████╗██║░░██║██║░░░░░███████╗██║░░██║
╚═╝░░╚═╝╚═╝░░╚══╝░╚════╝░╚═╝░░╚══╝  ╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝╚═╝░░░░░╚══════╝╚═╝░░╚═╝
");

            Console.WriteLine("Created by Lucifer's Angel");
            Console.WriteLine("1 : Scrape Links");
            Console.WriteLine("2 : Exit");
            Console.Write("\r\n> ");

            switch (Console.ReadLine())
            {
                case "1":
                    AnonFiles();
                    return true;
                case "2":
                    return false;
                default:
                    return true;
            }
        }

        private static void AnonFiles()
        {
            Console.Clear();
            Console.WriteLine(@"██╗░░░░░██╗███╗░░██╗██╗░░██╗  ░██████╗░█████╗░██████╗░░█████╗░██████╗░███████╗██████╗░
██║░░░░░██║████╗░██║██║░██╔╝  ██╔════╝██╔══██╗██╔══██╗██╔══██╗██╔══██╗██╔════╝██╔══██╗
██║░░░░░██║██╔██╗██║█████═╝░  ╚█████╗░██║░░╚═╝██████╔╝███████║██████╔╝█████╗░░██████╔╝
██║░░░░░██║██║╚████║██╔═██╗░  ░╚═══██╗██║░░██╗██╔══██╗██╔══██║██╔═══╝░██╔══╝░░██╔══██╗
███████╗██║██║░╚███║██║░╚██╗  ██████╔╝╚█████╔╝██║░░██║██║░░██║██║░░░░░███████╗██║░░██║
╚══════╝╚═╝╚═╝░░╚══╝╚═╝░░╚═╝  ╚═════╝░░╚════╝░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░░░░╚══════╝╚═╝░░╚═╝
");
            Console.WriteLine("Enter Keyword To Search");
            Console.WriteLine("");
            Console.Write("> ");
            string keyword = Console.ReadLine();
            Console.WriteLine("");

            int count = 0;
            List<string> Links = new List<string>();
            using (WebClient wc = new WebClient())
            {
                string s = wc.DownloadString("https://www.google.com/search?q=site:anonfile.com+" + keyword);
                Regex r = new Regex(@"https:\/\/anonfile.com\/\w+\/\w+");
                foreach (Match m in r.Matches(s))
                {
                    count++;
                    Links.Add(m.ToString());
                    Console.WriteLine(m);
                }
            }

            using (TextWriter tw = new StreamWriter($"Output//{keyword}.txt"))
            {
                foreach (string line in Links)
                {
                    tw.WriteLine(line.ToString());
                }
            }

            Console.WriteLine();
            Console.WriteLine("Found " + count.ToString() + " Links.");
            Console.Write("Press Enter To Goto Menu.");
            Console.ReadLine();
        }
    }
}