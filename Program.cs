using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Amortization V0.0.2";
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
                Amortisize a = new Amortisize();
                a.Amortisize_linear();
                Design.displayResult();
                return true;
            case "B":
                Amortisize b = new Amortisize();
                b.Amortisize_declining();
                Design.displayResult();
                return true;
            case "C":
                Amortisize c = new Amortisize();
                c.Amortisize_economic();
                Design.displayResult();
                return true;
            default:
                Console.Clear();
                Design.printTag();
                return true;
        }
    }
}
