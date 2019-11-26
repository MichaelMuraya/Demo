using System;
using System.Diagnostics;
using System.IO;

namespace DemoToimintoja
{
    class Program
    {
        static void Main(string[] args)
        {

            EkaHarjoitukset ek = new EkaHarjoitukset();
            DateTime pvm = ek.SeuraavaPerjantaiKolmastoista();
            Console.WriteLine("Seur pe 13. on "+ pvm.ToString("d"));
            Console.WriteLine();
            ek.PäiväTilasto(Console.Out);
            ek.PäiväTilasto2(Console.Out);

            Stopwatch kello = Stopwatch.StartNew();            
            String randomPassword = ek.CreatePassword(8, 3, 3);
            kello.Stop();
            Console.WriteLine("Password: "+randomPassword);
            Console.WriteLine("Aikaa kului: " + kello.ElapsedTicks);
            String rPassword = ek.CreatePasswordSB(8, 3, 3);
            Console.WriteLine("Password: " + rPassword);

            //kello = Stopwatch.StartNew();
            //randomPassword = ek.CreatePassword(8, 2, 5);
            //kello.Stop();
            //Console.WriteLine("Aikaa kului: " + kello.ElapsedTicks);
            //kello = Stopwatch.StartNew();
            //randomPassword = ek.CreatePassword(8, 2, 5);
            //kello.Stop();
            //Console.WriteLine("Aikaa kului: " + kello.ElapsedTicks);
            //kello = Stopwatch.StartNew();
            //randomPassword = ek.CreatePassword(8, 3, 3);
            //kello.Stop();
            //Console.WriteLine("Aikaa kului: " + kello.ElapsedTicks);


            int[,] matriisi = new int[2, 3]
            {
                 { 10,20,30 },
                { 40,50,60 } 

            };
           
            Console.WriteLine("   Values of array elements:");
            for (int outer = matriisi.GetLowerBound(0); outer <= matriisi.GetUpperBound(0);
                 outer++)
                for (int inner = matriisi.GetLowerBound(1); inner <= matriisi.GetUpperBound(1);
                     inner++)
                    Console.WriteLine($"      {'\u007b'}{outer}, {inner}{'\u007d'} = " +
                                      $"{matriisi.GetValue(outer, inner)}");
            //int rank = matriisi.Rank;
            //Console.WriteLine($"Number of dimensions: {rank}");
            //for (int ctr = 0; ctr < rank; ctr++)
            //    Console.WriteLine($"   Dimension {ctr}: " +
            //                      $"from {matriisi.GetLowerBound(ctr)} to {matriisi.GetUpperBound(ctr)}");

            //var tMatrix = ek.Transponoi(matriisi);
            //Console.WriteLine(tMatrix);
            //Console.WriteLine(tMatrix);
            //int rank = ai.Rank;
            //Console.WriteLine($"Number of dimensions: {rank}");
            //for (int ctr = 0; ctr < rank; ctr++)
            //    Console.WriteLine($"   Dimension {ctr}: " +
            //                      $"from {ai.GetLowerBound(ctr)} to {ai.GetUpperBound(ctr)}");
            //var tMatrix = ek.Transponoi(ai);

            int[,] ai = new int[2, 3] { { 10, 20, 30, }, { 40,50,60 } };
            ek.TulostaMatriisi(ai, DemoToimintoja.TaulukonTulostusTapa.Normi, Console.Out);
            ai = ek.Transponoi(ai);
            ek.TulostaMatriisi(ai, DemoToimintoja.TaulukonTulostusTapa.Normi, Console.Out);
            Console.WriteLine();



            Console.WriteLine("LLharjoitus");
            //LLHarjoitukset o = new LLHarjoitukset();
            var o = new DemoToimintoja.LLHarjoitukset();
            long tulos = o.LaskeTulo(2,3);
            Console.WriteLine(tulos);

            Func<int, int, long> mp;
            mp = o.LaskeTulo;
            tulos = mp(3, 4);
            Console.WriteLine(tulos);

            mp = (a, b) => (long)a * b;
            //mp = delegate (int a, int b) { return (long)a * b; };
            tulos = mp(2, 3);
            Console.WriteLine(tulos);

            DataC c = new DataC();
            DataS s = new DataS();
            c.Indeksi=1;
            s.Indeksi = 2;

           

        }
    }
    class DataC
    {
        public int Indeksi;
        public int Selite;
        private string _nimi;
        public void TeeJotain() => Indeksi++;
        //public void TeeJotain()
        //{
        //    Indeksi++;
        //}
        public DataC()
        {
            Indeksi = 1;  
        }

        public DataC(string nimi)
        {
            _nimi = nimi;
        }
    }
    struct DataS
    {
        public int Indeksi;
        public int Selite;
        public DataS(int i)
        {
            Indeksi = -2;
            Selite = 1;
        }
    }

}
