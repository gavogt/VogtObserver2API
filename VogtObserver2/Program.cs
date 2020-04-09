﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace VogtObserver2
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Run();
        }

        public static void Run()
        {
            StockGrabber stockGrabber = new StockGrabber();

            Trader t1 = new Trader("Julie");
            Trader t2 = new Trader("Amy");
            Trader t3 = new Trader("Mark");

            stockGrabber.AddObserver(t1);
            stockGrabber.AddObserver(t2);
            stockGrabber.AddObserver(t3);


            for (int i = 0; i <= 5; i++)
            {

                stockGrabber.Notify();

                Thread.Sleep(2000);

            }
        }

        public static string GetRandomStockSymbol()
        {

            string[] tempSymbols = new string[3] { "GOOG", "MSFT", "AAPL" };
            string symbol = " ";

            Random random = new Random();

            int temp;

            for (int i = 0; i < 200; i++)
            {
                temp = random.Next(0, 3);
                symbol = tempSymbols[temp];
            }

            return symbol;
        }
    }
}
