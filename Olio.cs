using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;


namespace DemoToimintoja
{
   public class Olio
    {
        public static void KopioiOlio(object lähde, object kohde)
        {
            foreach (var lo in lähde.GetType().GetProperties())
            {
                //var ko = kohde.GetType().GetProperty(lo.Name);
                var ko = kohde.GetType().GetProperty(SelvitäNimi(lo));
                if (ko != null)
                {
                    ko.SetValue(kohde, lo.GetValue(lähde));
                }
                //kohde.GetType().GetProperty(lo.Name)?.SetValue(kohde, lo.GetValue(lähde));
            }
        }
        private static string SelvitäNimi(PropertyInfo lo)
        {
            KopiointiKohdeAttribute[] ka = lo.GetCustomAttributes(typeof(KopiointiKohdeAttribute), false) as KopiointiKohdeAttribute[];
            return ka.Length == 0 ? lo.Name : ka[0].Nimi;
        }

        public static void TulostaOlio(object olio, TextWriter output)
        {
            foreach (var f in olio.GetType().GetFields())
            {
                output.WriteLine($"{f.Name}: {f.GetValue(olio)}");
            }
            foreach (var f in olio.GetType().GetProperties())
            {
                output.WriteLine($"{f.Name}: {f.GetValue(olio)}");
            }
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class KopiointiKohdeAttribute : Attribute
    {
        public string Nimi { get; set; }
        public KopiointiKohdeAttribute()
        {
        }
        public KopiointiKohdeAttribute(string nimi)
        {
            Nimi = nimi;
        }
    }
}

    

