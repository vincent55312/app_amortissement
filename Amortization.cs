using System;
using ConsoleTables;
namespace Application_amortissement
{
    public class Amortisize
    {
        private decimal base_amortisize {get; set;}
        private decimal residual_value {get; set;}
        private decimal tx_linear {get; set;}
        private decimal annuities {get; set;}
        private decimal volume_annuities {get; set;}
        private decimal book_value {get; set;}
        private DateTime start_date{get; set;}
        private int years_duration {get; set;}
        private decimal total_days {get; set;}
        private decimal days_first_year {get; set;}
        private int days_in_year = 365;
        private int precision = 3;


        public DateTime getInputDate(){
            try{
                Console.Write("Input year : (format type int) ");
                int y = int.Parse(Console.ReadLine());
                Console.Write("Input month : (format type [0-12])");
                int m = int.Parse(Console.ReadLine());
                Console.Write("Input day : (format [0-31]");
                int d = int.Parse(Console.ReadLine());
                return new DateTime(y,m,d);
            }catch(Exception e){
                Design.WriterColor(e.ToString(), ConsoleColor.Red);
                return new DateTime(0,0,0);
            }
        }

        public decimal rounding(decimal d){
            return Math.Round(d,precision,MidpointRounding.ToEven);
        }


        public void Amortisize_linear(){
            Console.Clear();
            Design.printTag();
            try{
                Design.WriterColor("Input starting date :", ConsoleColor.White);
                start_date = getInputDate();
                Design.WriterColor("Input the Amortization time in years (format type int) :", ConsoleColor.Green);
                years_duration = int.Parse(Console.ReadLine());
                Design.WriterColor("Input the base Amortization (format type decimal) :", ConsoleColor.Blue);
                base_amortisize = decimal.Parse(Console.ReadLine());
                Design.WriterColor("Input the residual value (format type decimal) :", ConsoleColor.Red);
                residual_value = decimal.Parse(Console.ReadLine());
                
                var table = new ConsoleTable("Years", "Base Amortization", "Annuities", "Cumulative Annuities", "Book value");

                DateTime end_year = new DateTime(start_date.Year, 12, 31);
                days_first_year = (end_year - start_date).Days;
                total_days = days_first_year + (years_duration-1) * days_in_year;
                tx_linear = 1/(decimal)(total_days/days_in_year);

                int i = 0;
                Design.WriterColor("Start :" + start_date.ToString() +" Duration :"+ years_duration+" years  Base amortisize :" + base_amortisize +" Residual value :"+ residual_value +" Tx linear :"+ tx_linear, ConsoleColor.DarkGreen);
                while(total_days/days_in_year - i >0){
                    int year = start_date.Year + i;
                    annuities = (base_amortisize-residual_value) * tx_linear;
                    if(i==0) annuities = annuities*(days_first_year/days_in_year);
                    volume_annuities += annuities;
                    book_value = base_amortisize - volume_annuities;
                    table.AddRow(year, base_amortisize - residual_value, rounding(annuities), rounding(volume_annuities), rounding(book_value));
                    i++;
                }
                table.Write(Format.Alternative);
            }
            catch (Exception e){
                Design.WriterColor(e.ToString(), ConsoleColor.Red);
            }
            Design.WriterColor("End of the Amortisize linear", ConsoleColor.Red);
        }

        public void Amortisize_declining(){

        }
    }
}