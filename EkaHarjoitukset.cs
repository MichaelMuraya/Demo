using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DemoToimintoja
{
    class EkaHarjoitukset
    {
        public DateTime SeuraavaPerjantaiKolmastoista()
        {
            DateTime pvm = DateTime.Today;
            //do
            //{
            //    if (pvm.Day == 13 && pvm.DayOfWeek == DayOfWeek.Friday)
            //    {
            //        return pvm;
            //    }
            //    pvm = pvm.AddDays(1);

            //}
            //while (true);
            do
            {
                pvm = pvm.AddDays(1);

            } while (!(pvm.Day == 13 && pvm.DayOfWeek == DayOfWeek.Friday));
            return pvm;
        }
        public void PäiväTilasto(TextWriter output)
        {
            int[] päivätilasto = new int[7];
            DateTime pvm = new DateTime(1900, 1, 1);
            DateTime LoppuPvm = new DateTime(2050, 12, 31);
            while (pvm <= LoppuPvm)
            {
                if (pvm.Day == 13)
                {
                    päivätilasto[(int)pvm.DayOfWeek]++;
                }
                pvm = pvm.AddDays(1);
            }
            string s = "";
            for (int i = 0; i < päivätilasto.Length; i++)
            {
                s += ((ViikonPäivä)i).ToString() + ":" + päivätilasto[i] + Environment.NewLine;
            }
            output.WriteLine(s);
        }
        public void PäiväTilasto2(TextWriter output)
        {
            int[] päiväTilasto = new int[7];
            DateTime pvm = new DateTime(1900, 1, 1);
            DateTime LoppuPvm = new DateTime(2050, 12, 31);
            while (pvm < LoppuPvm)
            {
                if (pvm.Day == 13)
                {
                    switch (pvm.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            päiväTilasto[0]++;
                            break;
                        case DayOfWeek.Tuesday:
                            päiväTilasto[1]++;
                            break;
                        case DayOfWeek.Wednesday:
                            päiväTilasto[2]++;
                            break;
                        case DayOfWeek.Thursday:
                            päiväTilasto[3]++;
                            break;
                        case DayOfWeek.Friday:
                            päiväTilasto[4]++;
                            break;
                        case DayOfWeek.Saturday:
                            päiväTilasto[5]++;
                            break;
                        case DayOfWeek.Sunday:
                            päiväTilasto[6]++;
                            break;
                        default:
                            break;
                    }
                }
                pvm = pvm.AddDays(1);
            }
            string s = "";
            for (int i = 0; i < päiväTilasto.Length; i++)
            {
                s += ((ViikonPäivä2)i).ToString() + ":" + päiväTilasto[i] + Environment.NewLine;
            }
            output.WriteLine(s);
        }

        public string CreatePassword(int kirjainLkm, int numeroLkm,int erikkoismerkki)
        {
            string k = "abcdefghijklmnopqrstuvwxyzåäöABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string n = "0123456789";
            string e = "!#¤%&/()=\\@£$€?{}";
            Random random = new Random();


            string generated = "!";
            for (int i = 1; i <= kirjainLkm; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    k[random.Next(k.Length - 1)].ToString()
                );

            for (int i = 1; i <= numeroLkm; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    n[random.Next(n.Length - 1)].ToString()
                );

            for (int i = 1; i <= erikkoismerkki; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    e[random.Next(e.Length - 1)].ToString()
                );

            return generated.Replace("!", string.Empty);

        }
        public string CreatePasswordSB(int kirjainLkm, int numeroLkm, int erikoismerkkiLkm)
        {

            string k = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string n = "0123456789";
            string e = @"!#¤%&/()=?\@£$_-*+{[]}";
            StringBuilder s = new StringBuilder(kirjainLkm + numeroLkm + erikoismerkkiLkm);
            Random r = new Random();
            for (int i = 0; i < kirjainLkm; i++)
            {
                s.Append(k[r.Next(k.Length)]);
            }
            for (int i = 0; i < erikoismerkkiLkm; i++)
            {
                s.Append(e[r.Next(e.Length)]);
            }
            for (int i = 0; i < numeroLkm; i++)
            {
                s.Append(n[r.Next(n.Length)]);
            }
            int kierrosLkm = 47 * (kirjainLkm + numeroLkm + erikoismerkkiLkm); // ihan keksitty luku
            for (int i = 0; i < kierrosLkm; i++)
            {
                int i1 = r.Next(s.Length);
                int i2 = r.Next(s.Length);
                char c = s[i1];
                s[i1] = s[i2];
                s[i2] = c;
            }
            return s.ToString();
        }

        public int[,] Transponoi(int[,] matriisi)
        {
            //int w = matriisi.GetUpperBound(0);
            //int h = matriisi.GetUpperBound(1);
            int w = matriisi.GetLength(0);
            int h = matriisi.GetLength(1);

            int[,] result = new int[h, w];

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    result[j, i] = matriisi[i, j];
                    
                }
            }

            return result;
        }
        public void TulostaMatriisi(int[,] matriisi, TaulukonTulostusTapa tulostustapa, TextWriter output)
        {
            int offset = tulostustapa == TaulukonTulostusTapa.CS ? 0 : 1;
            if (tulostustapa == TaulukonTulostusTapa.EiIndeksejä)
            {
                for (int i = 0; i <= matriisi.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= matriisi.GetUpperBound(1); j++)
                    {
                        output.Write(matriisi[i, j]);
                        output.Write('\t');
                    }
                    output.WriteLine();
                }
            }
            else
            {
                output.Write('\t');
                for (int i = 0; i <= matriisi.GetUpperBound(1); i++)
                {
                    output.Write(i + offset);
                    output.Write('\t');
                }
                output.WriteLine();
                for (int i = 0; i <= matriisi.GetUpperBound(0); i++)
                {
                    output.Write(i + offset);
                    output.Write('\t');
                    for (int j = 0; j <= matriisi.GetUpperBound(1); j++)
                    {
                        output.Write(matriisi[i, j]);
                        output.Write('\t');
                    }
                    output.WriteLine();
                }
            }
        }





    }

    public enum TaulukonTulostusTapa
    {
         EiIndeksejä, CS, Normi
    }


    public enum ViikonPäivä
    {
        Sunnuntai = 0,
        Maanantai,
        Tiistai,
        Keskiviikko,
        Torstai,
        Perjantai,
        Lauantai
    }
    public enum ViikonPäivä2
    {
        
        Maanantai=0,
        Tiistai,
        Keskiviikko,
        Torstai,
        Perjantai,
        Lauantai,
        Sunnuntai
    }
}
