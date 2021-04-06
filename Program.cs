using System;

namespace Application_amortissement
{
    class Program
    {
        static void Main(string[] args)
        {
            sendMenu();
        }

        private static void sendMenu(){
            bool showMenu = true;
            while (showMenu){
                showMenu = MainMenu();
            }
        }
        public static bool MainMenu()
        {
            Console.Clear();
            Design.printTag();
            Design.getMenu();
            switch (Design.getUserKeys().ToUpper())
            {
                case "A":
                    return true;
                case "B":
                    return true;
                case "C":
                    Design.printTag();
                    return true;
                default:
                    Console.Clear();
                    Design.printTag();
                    return true;
            }
        }
    }
}
