﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VogtObserver2
{
    class Stock : IObservable
    {
        private HistoricalDataInfo _hdi = new HistoricalDataInfo();
        private List<HistoricalDataResponse> _hdr;

        private List<IObserver> _observers = new List<IObserver>();

        public void AddObserver(IObserver o)
        {
            _observers.Add(o);
        }

        public void Notify()
        {
            foreach (IObserver observer in _observers)
            {
                observer.Update();
            }
        }

        public void RemoveObserver(IObserver o)
        {
            _observers.Remove(o);
        }

        public double GetPrice(string symbol)
        {
             double temp = 0.0;
            _hdr = _hdi.HistoricalData($"https://sandbox.iexapis.com/stable/stock/{symbol}/quote?token=Tpk_81485eef3d7041e6bd05ba956b85fa4e");

            foreach (var historicaldata in _hdr)
            {
                temp = historicaldata.latestPrice;
            }
            
            return temp;
        }
    }
}
