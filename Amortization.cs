using System;
using ConsoleTables;

namespace Application_amortissement
{
    public class Amortisize
    {
        private int years {get; set;}
        private decimal base_amortisize {get; set;}
        private decimal residual_value {get; set;}
        private decimal tx_linear {get; set;}
        private decimal annuities {get; set;}
        private decimal volume_annuities {get; set;}
        private decimal compatable_value {get; set;}

        public void Amortisize_linear(){
            Console.Clear();
            Design.printTag();
            try{
                Design.WriterColor("Saisir le nombre d'années de durée d'amortissements (input type int) :", ConsoleColor.White);
                years = int.Parse(Console.ReadLine());
                Design.WriterColor("Saisir la base d'amortissement (input type decimal) :", ConsoleColor.Green);
                base_amortisize = decimal.Parse(Console.ReadLine());
                Design.WriterColor("Renseigner la valeur résiduelle (input type decimal) :", ConsoleColor.Red);
                residual_value = decimal.Parse(Console.ReadLine());
                
                var table = new ConsoleTable("Années", "Base d’amortissement ", "Annuités","Cumul des annuités", "Valeur comptable");
                
                tx_linear = 1/(decimal)years;
                annuities = (base_amortisize-residual_value) * tx_linear;
                int i = 0;
                Design.WriterColor("Base amortisize :" + base_amortisize +" Residual value : "+ residual_value +" Tx linear :"+ tx_linear, ConsoleColor.DarkGreen);

                while(years - i >0){
                    volume_annuities += annuities;
                    compatable_value = base_amortisize - volume_annuities;
                    table.AddRow(i+1, base_amortisize, annuities, volume_annuities, compatable_value);
                    i++;
                }
                table.Write(Format.Alternative);
            }
            catch (Exception e){
                Console.WriteLine(e.ToString());
            }
            Design.WriterColor("End of the Amortisize linear", ConsoleColor.Red);

        }
    }
}