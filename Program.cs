using System;
using System.Collections.Generic;

namespace pppraca
{
    class Program
    {
        static void Main(string[] args)
        {
            List<employee> dane = new List<employee>();
            initialize(dane);
            int choice = -1;
            Console.WriteLine("obsluga zakladu pracy");
            Console.WriteLine();
            do
            {
                Console.WriteLine("1: wyswietl wszystkich pracownikow");
                Console.WriteLine("2: oblicz wynagrodzenie");
                Console.WriteLine("3: koniec");
                Console.WriteLine("wprowadz komende: ");
                choice = Int32.Parse(Console.ReadLine());
                if(choice == 1)
                {
                    showlist(dane);
                }
                else if (choice == 2)
                {
                    calculate(dane);
                }
                else if (choice == 3)
                {
                    ;
                }
                else
                {
                    Console.WriteLine("! blad !");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                }
            } while (choice != 3);
        }

        static void showlist(List<employee> x)
        {
            int i = 0;
            Console.WriteLine("ID ~ imie i nazwisko ~ data urodzenia ~ pozycja ~ stawka");
            for(i = 0; i<x.Count; i++)
            {
                x[i].show();
            }
        }

        static void calculate(List<employee> emplolist)
        {
            int xID = -1;
            do
            {
                Console.WriteLine("podaj ID pracownika: ");
                xID = Int32.Parse(Console.ReadLine());
                if(xID <= 0 || xID > emplolist.Count)
                {
                    Console.WriteLine("blad");
                }
            } while (xID <= 0 || xID > emplolist.Count);
            
            xID -= 1;
            emplolist[xID].show();

            int age = DateTime.Now.Year - emplolist[xID].DOB.Year;
            int days = -1;
            int i = 0;
            decimal net = 0;
            decimal brut = 0;
            decimal tax = 0;
            decimal bonus = 1000;

            while (i == 0)
            {
                Console.WriteLine("podaj ilosc przepracowanych dni (max 20)");
                days = Int32.Parse(Console.ReadLine());
                if (days < 0 || days > 20)
                {
                    Console.WriteLine("blad");
                }
                else
                {
                    i++;
                }
            }

            if (emplolist[xID].position == true)
            {
                if (days < 20)
                {
                    brut = emplolist[xID].rateMonth * 0.8m;
                }
                else
                {
                    brut = emplolist[xID].rateMonth;
                    brut += bonus;
                }
            }
            else
            {
                brut = emplolist[xID].rateHour * days * 8;
                if (days == 20)
                {
                    brut += bonus;
                }
            }

            net = brut;

            if (age > 26)
            {
                tax = 0.18m * brut;
                net -= tax;
            }

            Console.WriteLine("brutto: " + brut + " | tax: " + tax + " | netto:" + net);
        }

        static void initialize(List<employee> toInit)
        {
            toInit.Add(new employee() {ID = 1, name = "Jan Nowak", DOB = new DateTime(2002, 3, 4), position = false, rateHour = 18.5m});
            toInit.Add(new employee() {ID = 2, name = "Agnieszka Kowalska", DOB = new DateTime(1973, 12, 15), position = true, rateMonth =2800});
            toInit.Add(new employee() {ID = 3, name = "Robert Lewandowski", DOB = new DateTime(1980, 5, 23), position = false, rateHour = 29});
            toInit.Add(new employee() {ID = 4, name = "Zofia Plucińska", DOB = new DateTime(1998, 11, 2), position = true, rateMonth = 4750});
            toInit.Add(new employee() {ID = 5, name = "Grzegorz Braun", DOB = new DateTime(1960, 1, 29), position = false, rateHour = 48});
        }
    }
}
