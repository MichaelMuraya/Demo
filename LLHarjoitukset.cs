using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;

namespace DemoToimintoja
{
    public class LLHarjoitukset
    {
        // public long LaskeTulo(int op1,int op2)
        //{
        //    return (long)op1 * op2;
        //}
        public long LaskeTulo(int a, int b) => (long)a * b;

        //public int ProsessiLkm(string pnimi)
        //{
        //    var prosessit = Process.GetProcesses();
        //    pnimi = pnimi.ToLower();
        //    var q = from p in prosessit
        //            where p.ProcessName.ToLower() == pnimi
        //            select p;
        //    return q.Count();
        //    //return prosessit.Count(p=>p.ProcessName.ToLower() == pnimi);
        //    //int lkm = 0;
        //    //foreach (var p in prosessit)
        //    //{
        //    //    if (p.ProcessName.ToLower() == pnimi)
        //    //    {
        //    //        lkm++;
        //    //    }
        //    //}
        //    //return lkm;
        //}
        public List<string> Prioriteettliluokat()
        {
            var prosessit = Process.GetProcesses();
            return prosessit.Where(p => p.SessionId == 0).Select(p => p.BasePriority.ToString()).Distinct().ToList();
        }

        public string MuistiSyöpöinProsessi()
        {
            return Process.GetProcesses().Where(p => p.SessionId == 1)
                .OrderByDescending(p => p.WorkingSet64).First().ProcessName;
        }

        public void SysteemiHakemistonTiedostoista()
        {
            //Tee metodi/ kysely, joka hakee c:\windows –hakemistosta vanhimman ja uusimman 
            //tiedoston, 

            DirectoryInfo diWindows = new DirectoryInfo("c:\\windows");
            var t1 = diWindows.GetFiles();
            Console.WriteLine("Windows-hakemisto: ");
            Console.WriteLine(t1.OrderBy(f => f.Length).Select(f => new { f.Name, f.Length }).First());
            Console.WriteLine(t1.OrderBy(f => f.Length).Select(f => new { f.Name, f.Length }).Last());
            Console.WriteLine(t1.OrderBy(f => f.CreationTime).Select(f => new { f.Name, f.Length }).First());
            Console.WriteLine(t1.OrderBy(f => f.CreationTime).Select(f => new { f.Name, f.Length }).Last());

            //sitten isoin ja pienin ja lopuksi vanhin exe tai dll –tiedosto jonka 
            //koko on yli 5 kilotavua(selvitä paljonko on yksi kilotavu) ja alle 1 megatavu.
            var vanhinExeTaiDll = from f in t1
                                  where f.Extension == ".dll" || f.Extension == ".exe"
                                  where f.Length > 5 * 1024 && f.Length < 1024 * 1024
                                  orderby f.CreationTime
                                  select f;

            // ja sama methods-syntaksilla:
            vanhinExeTaiDll = t1.Where(f => f.Extension == ".dll" || f.Extension == ".exe")
                                .Where(f => f.Length > 5 * 1024 && f.Length < 1024 * 1024)
                                .OrderBy(f => f.CreationTime);

            Console.WriteLine(vanhinExeTaiDll.First().Name);

        }


        List<string> nimilista = new List<string>()
            { "Aku", "Pelle", "Iines", "Tupu", "Milla Magia" };

        public void LINQToimintaDemo()
        {
            List<string> lyhyetNimet = KovaKoodattuVersio();
            lyhyetNimet = nimilista.KovaKoodattuLyhyetNimetLaajennosMetodi();
            lyhyetNimet = nimilista.EiNiinkovaKoodattu(NimiAlleViisiMerkkiä);
            lyhyetNimet = nimilista.EiNiinkovaKoodattu(Nimessä_A_Kirjain);
            var tulos = nimilista.Where(Nimessä_A_Kirjain).ToList();
            tulos = nimilista.Where(n => n.ToLower().Contains("a")).ToList();
            tulos = (from n in nimilista
                     where n.ToLower().Contains("a")
                     select n).ToList();
        }

        bool NimiAlleViisiMerkkiä(string nimi)
        {
            return nimi.Length < 5;
        }

        bool Nimessä_A_Kirjain(string nimi)
        {
            return nimi.ToLower().Contains("a");
        }

        private List<string> KovaKoodattuVersio()
        {
            List<string> nl = new List<string>();
            foreach (var n in nimilista)
            {
                if (n.Length < 5)
                {
                    nl.Add(n);
                }
            }
            return nl;
        }



    }

    public static class LinqSimulointiLuokka
    {

        public static List<string> EiNiinkovaKoodattu(this List<string> lista,
            Func<string, bool> valintaMetodi)
        {
            List<string> nl = new List<string>();
            foreach (var n in lista)
            {
                if (valintaMetodi(n))
                {
                    nl.Add(n);
                }
            }
            return nl;
        }

        public static List<string> KovaKoodattuLyhyetNimetLaajennosMetodi(this List<string> lista)
        {
            List<string> nl = new List<string>();
            foreach (var n in lista)
            {
                if (n.Length < 5)
                {
                    nl.Add(n);
                }
            }
            return nl;
        }
    }
}




