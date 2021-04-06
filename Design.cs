using System;
using System.Threading;

namespace Application_amortissement
{
    public class Design
    {
        public static ConsoleColor lineColor = ConsoleColor.Yellow;
        public static ConsoleColor underTagColor = ConsoleColor.Red;
        public static ConsoleColor tagColor = ConsoleColor.Cyan;
        public static ConsoleColor baseColor = ConsoleColor.Yellow;
        public static ConsoleColor keyValidateColor = ConsoleColor.Green;
        public static ConsoleColor errorColor = ConsoleColor.Red;

        public static void printTag(){
        string line ="______________________________________________________________________________________________________________";
        string tag =@"
           _____                              __    __                   __    __                 
          /  _  \    _____    ____  _______ _/  |_ |__|_____________   _/  |_ |__|  ____    ____  
         /  /_\  \  /     \  /  _ \ \_  __ \\   __\|  |\___   /\__  \  \   __\|  | /  _ \  /    \ 
        /    |    \|  Y Y  \(  <_> ) |  | \/ |  |  |  | /    /  / __ \_ |  |  |  |(  <_> )|   |  \
        \____|__  /|__|_|  / \____/  |__|    |__|  |__|/_____ \(____  / |__|  |__| \____/ |___|  /
                \/       \/                                  \/     \/                         \/ ";
        string me =@"                                                                ConsoleTable Amortization by Vvuylsteker ";

            Console.ForegroundColor = lineColor;
            Console.WriteLine(line);
            Console.ForegroundColor = tagColor;
            Console.WriteLine(tag);
            Console.ForegroundColor = underTagColor;
            Console.WriteLine(me);
            Console.ForegroundColor = lineColor;
            Console.WriteLine(line+"\n");
            Console.ForegroundColor = baseColor;
        }


        public static void Writer(string message)
        {
            Console.WriteLine($"\r[{getTime()}] {message}");
        }

        public static void WriterColor(string message, ConsoleColor myColor){
            Console.ForegroundColor = myColor;
            Console.WriteLine($"\r[{getTime()}] {message}");
            Console.ForegroundColor = baseColor;
        }
        public static void WriterColorNoTime(string message, ConsoleColor myColor){
            Console.ForegroundColor = myColor;
            Console.WriteLine($"\r {message}");
            Console.ForegroundColor = baseColor;
        }
        public static string getTime(){
            DateTime localDate = DateTime.Now;
            return localDate.TimeOfDay.ToString().Substring(0,11);
        }

        public static string getUserKeys(){
            Console.WriteLine("\r\nSelect an option: ");
            Console.ForegroundColor = lineColor;
            string line ="______________________________________________________________________________________________________________";
            Console.WriteLine(line);
            Console.ForegroundColor = baseColor;
            return Console.ReadLine();
        }
        public static void getLine(){
            Console.ForegroundColor = lineColor;
            string line ="______________________________________________________________________________________________________________";
            Console.WriteLine(line);
            Console.ForegroundColor = baseColor;
        }

        public static void Wait(int ms){
            Thread.Sleep(ms);
        }

        public static void getMenu(){
            colorK("[A]");
            Console.Write("    Generate the linear depreciation table\n");
            colorK("[B]");
            Console.Write("    Generate the declining balance table\n");
            colorK("[C]");
            Console.Write("    Generate the depreciation table according to the economic benefits produced\n");
        }

        public static void colorK(string key){
            Console.ForegroundColor = keyValidateColor;
            Console.Write(key);
            Console.ForegroundColor = baseColor;
        }

        public static void colorChooseColor(string key, ConsoleColor a){
            Console.ForegroundColor = a;
            Console.Write(key);
            Console.ForegroundColor = baseColor;
        }

        public static void displayResult(){
            Console.Write("\r\nPress Enter to return to Main Menu");
            Console.ReadLine();
        }

    }
}
