using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoToimintoja
{
    public class NumeroApuja
    {
        public int Maksimi(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
        public int Maksimi(int a, int b, int c)
        {
            return (a > b && a > c) ? a : b > c ? b : c;
            //if (a>b && a>c)
            //{
            //    return a;
            //}
            //if (b>c)
            //{
            //    return b;
            //}
            //return c;
        }
        public int Maksimi(params int [] luvut)
        {
            return luvut.Max();
            //int suurin = int.MinValue;
            //foreach (var item in luvut)
            //{
            //    if (suurin > item)
            //    {
            //        suurin = item;
            //    }

            //}
            //return suurin;
        }
    }
}
