using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Helpers
{
    public class DayOfWeek
    {
        public class Cashback
        {
            public string Genre { get; set; }
            public System.DayOfWeek DayOfWeek { get; set; }
            public int Discont { get; set; }
        }

        public static List<Cashback> CashBackList()
        {
            List<Cashback> cashbackList = new List<Cashback>();
            cashbackList.Add(new Cashback { Genre = "pop", DayOfWeek = System.DayOfWeek.Sunday, Discont = 25 });
            cashbackList.Add(new Cashback { Genre = "pop", DayOfWeek = System.DayOfWeek.Monday, Discont = 7 });
            cashbackList.Add(new Cashback { Genre = "pop", DayOfWeek = System.DayOfWeek.Tuesday, Discont = 6 });
            cashbackList.Add(new Cashback { Genre = "pop", DayOfWeek = System.DayOfWeek.Wednesday, Discont = 2 });
            cashbackList.Add(new Cashback { Genre = "pop", DayOfWeek = System.DayOfWeek.Thursday, Discont = 10 });
            cashbackList.Add(new Cashback { Genre = "pop", DayOfWeek = System.DayOfWeek.Friday, Discont = 15 });
            cashbackList.Add(new Cashback { Genre = "pop", DayOfWeek = System.DayOfWeek.Saturday, Discont = 20 });

            cashbackList.Add(new Cashback { Genre = "mpb", DayOfWeek = System.DayOfWeek.Sunday, Discont = 30 });
            cashbackList.Add(new Cashback { Genre = "mpb", DayOfWeek = System.DayOfWeek.Monday, Discont = 5 });
            cashbackList.Add(new Cashback { Genre = "mpb", DayOfWeek = System.DayOfWeek.Tuesday, Discont = 10 });
            cashbackList.Add(new Cashback { Genre = "mpb", DayOfWeek = System.DayOfWeek.Wednesday, Discont = 15 });
            cashbackList.Add(new Cashback { Genre = "mpb", DayOfWeek = System.DayOfWeek.Thursday, Discont = 20 });
            cashbackList.Add(new Cashback { Genre = "mpb", DayOfWeek = System.DayOfWeek.Friday, Discont = 25 });
            cashbackList.Add(new Cashback { Genre = "mpb", DayOfWeek = System.DayOfWeek.Saturday, Discont = 30 });

            cashbackList.Add(new Cashback { Genre = "classical", DayOfWeek = System.DayOfWeek.Sunday, Discont = 35 });
            cashbackList.Add(new Cashback { Genre = "classical", DayOfWeek = System.DayOfWeek.Monday, Discont = 3 });
            cashbackList.Add(new Cashback { Genre = "classical", DayOfWeek = System.DayOfWeek.Tuesday, Discont = 5 });
            cashbackList.Add(new Cashback { Genre = "classical", DayOfWeek = System.DayOfWeek.Wednesday, Discont = 8 });
            cashbackList.Add(new Cashback { Genre = "classical", DayOfWeek = System.DayOfWeek.Thursday, Discont = 13 });
            cashbackList.Add(new Cashback { Genre = "classical", DayOfWeek = System.DayOfWeek.Friday, Discont = 18 });
            cashbackList.Add(new Cashback { Genre = "classical", DayOfWeek = System.DayOfWeek.Saturday, Discont = 25 });

            cashbackList.Add(new Cashback { Genre = "rock", DayOfWeek = System.DayOfWeek.Sunday, Discont = 40 });
            cashbackList.Add(new Cashback { Genre = "rock", DayOfWeek = System.DayOfWeek.Monday, Discont = 10 });
            cashbackList.Add(new Cashback { Genre = "rock", DayOfWeek = System.DayOfWeek.Tuesday, Discont = 15 });
            cashbackList.Add(new Cashback { Genre = "rock", DayOfWeek = System.DayOfWeek.Wednesday, Discont = 15 });
            cashbackList.Add(new Cashback { Genre = "rock", DayOfWeek = System.DayOfWeek.Thursday, Discont = 15 });
            cashbackList.Add(new Cashback { Genre = "rock", DayOfWeek = System.DayOfWeek.Friday, Discont = 20 });
            cashbackList.Add(new Cashback { Genre = "rock", DayOfWeek = System.DayOfWeek.Saturday, Discont = 40 });

            return cashbackList;
        }
      

        public static int CheckCashbackByDayAndGenre(string genre)
        {
            return CashBackList().Where(p => p.DayOfWeek == DateTime.Today.DayOfWeek && p.Genre == genre).Single().Discont;
        }
    }
}