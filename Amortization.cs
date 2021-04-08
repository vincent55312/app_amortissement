using System;
using ConsoleTables;
using System.Collections.Generic;
public class Amortisize
{
    private decimal base_amortisize {get; set;}
    private decimal residual_value {get; set;}
    private decimal tx_linear {get; set;}
    private decimal tx_decline{get; set;}
    private decimal annuities {get; set;}
    private decimal volume_annuities {get; set;}
    private decimal book_value {get; set;}
    private DateTime start_date{get; set;}
    private int years_duration {get; set;}
    private decimal total_days {get; set;}
    private decimal days_first_year {get; set;}

    private int days_in_year = 365;
    private int precision = 3;

    private decimal getCoefficient(decimal year){
        if (year<5) return 1.25M;
        else if (year <7) return 1.75M;
        else return 2.25M;
    }

    private List<decimal> inputEconomicValues(int years){
        int i = 0;
        List<decimal> values = new List<decimal>();
        while(years > i){
            Design.WriterColor("Input your economic advantage of the year "+i+" :", ConsoleColor.Green);
            values.Add(decimal.Parse(Console.ReadLine()));
            i++;
        }
        return values;
    }

    private DateTime getInputDate(){
        try{
            Console.Write("Input year (format type int) :");
            int y = int.Parse(Console.ReadLine());
            Console.Write("Input month (format type [1-12]) :");
            int m = int.Parse(Console.ReadLine());
            Console.Write("Input day (format [1-31]) :");
            int d = int.Parse(Console.ReadLine());
            return new DateTime(y,m,d);
        }catch(Exception e){
            Design.WriterColor(e.Message.ToString(), ConsoleColor.Red);
            return new DateTime(0,0,0);
        }
    }

    private decimal rounding(decimal d){
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

            base_amortisize -= residual_value;
            DateTime end_year = new DateTime(start_date.Year, 12, 31);
            days_first_year = (end_year - start_date).Days;
            total_days = days_first_year + (years_duration-1) * days_in_year;
            tx_linear = 1/(decimal)(total_days/days_in_year);

            Design.WriterColor("Start :" + start_date.ToString() +" Duration :"+ years_duration+" years  Base amortisize :" + base_amortisize, ConsoleColor.DarkGreen);
            Design.WriterColor("Residual value :"+ residual_value +" Tx linear :"+ rounding(tx_linear)+"\n", ConsoleColor.DarkGreen);
            int i = 0;
            while(total_days/days_in_year - i >0){
                int year = start_date.Year + i;
                annuities = base_amortisize * tx_linear;
                if(i==0) annuities = annuities*(days_first_year/days_in_year);
                volume_annuities += annuities;
                book_value = base_amortisize + residual_value - volume_annuities;
                table.AddRow(year, base_amortisize, rounding(annuities), rounding(volume_annuities), rounding(book_value));
                i++;
            }
            table.Write(Format.Alternative);
        }
        catch (Exception e){
            Design.WriterColor(e.Message.ToString(), ConsoleColor.Red);
        }
        Design.WriterColor("End of the Amortisize linear", ConsoleColor.Red);
    }


    public void Amortisize_declining(){
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
            
            var table = new ConsoleTable("Years", "Base Amortization","Tx linear", "Tx decline", "Annuities", "Book value");

            DateTime end_year = new DateTime(start_date.Year, 12, 31);
            days_first_year = (end_year - start_date).Days;
            total_days = days_first_year + (years_duration-1) * days_in_year;

            tx_decline = 1/ (decimal)years_duration * getCoefficient(years_duration);
            base_amortisize -= residual_value;

            Design.WriterColor("Start :" + start_date.ToString() +" Duration :"+ years_duration+" years  Base amortisize :" + base_amortisize +" Residual value :"+ residual_value +" Tx decline selected :"+ tx_decline, ConsoleColor.DarkGreen);
            int i = 0;
            while(total_days/days_in_year - i >0){
                int year = start_date.Year + i;
                tx_linear = 1/(decimal)(years_duration - i);
                decimal tx_to_use = (tx_decline> tx_linear) ? tx_decline : tx_linear;

                annuities = (base_amortisize-residual_value) * tx_to_use;
                if(i==0) annuities = annuities*(days_first_year/days_in_year);

                book_value = base_amortisize - annuities;
                table.AddRow(year, rounding(base_amortisize), rounding(tx_linear), rounding(tx_decline), rounding(annuities) , rounding(book_value));
                base_amortisize = book_value;
                i++;
            }
            table.Write(Format.Alternative);
        }
        catch (Exception e){
            Design.WriterColor(e.Message.ToString(), ConsoleColor.Red);
        }
        Design.WriterColor("End of the Amortisize declining", ConsoleColor.Red);
    }


    public void Amortisize_economic(){
        Console.Clear();
        Design.printTag();
        try{
            Design.WriterColor("Input starting date :", ConsoleColor.White);
            start_date = getInputDate();
            Design.WriterColor("Input the Amortization time in years (format type int) :", ConsoleColor.Green);
            years_duration = int.Parse(Console.ReadLine());
            Design.WriterColor("Input the base Amortization (format type decimal) :", ConsoleColor.Blue);
            base_amortisize = decimal.Parse(Console.ReadLine());
            List<decimal> economic = inputEconomicValues(years_duration);

            var table = new ConsoleTable("Years", "Base Amortization", "Annuities", "Book value");

            DateTime end_year = new DateTime(start_date.Year, 12, 31);
            days_first_year = (end_year - start_date).Days;
            total_days = days_first_year + (years_duration-1) * days_in_year;
            book_value = base_amortisize;
            decimal rest = 0;
            int year;
            
            Design.WriterColor("Start :" + start_date.ToString() +" Duration :"+ years_duration+" years  Base amortisize :" + base_amortisize, ConsoleColor.DarkGreen);
            int i = 0;
            while(total_days/days_in_year - i >0){
                year = start_date.Year + i;
                annuities = economic[i];
                if(i==0){
                    rest = annuities - annuities*(days_first_year/days_in_year);
                    annuities = annuities*(days_first_year/days_in_year);
                }
                book_value -= annuities;

                table.AddRow(year, base_amortisize, rounding(annuities), rounding(book_value));
                i++;
            }
            if(rest>0){
                year = start_date.Year + i;
                book_value -= rest;
                table.AddRow("[+]"+ year, base_amortisize, rounding(rest), rounding(book_value));
            }
            table.Write(Format.Alternative);
        }
        catch (Exception e){
            Design.WriterColor(e.Message.ToString(), ConsoleColor.Red);
        }
        Design.WriterColor("End of the Amortisize economic", ConsoleColor.Red);
    }
}
