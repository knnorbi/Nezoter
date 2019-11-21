using System;
using System.IO;

namespace Nezoter
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1. feladat
            Szek[,] szekek = new Szek[15, 20];

            string[] foglaltsag = File.ReadAllLines("foglaltsag.txt");
            string[] kategoria = File.ReadAllLines("kategoria.txt");

            for (int i = 0; i < szekek.GetLength(0); i++)
            {
                for (int j = 0; j < szekek.GetLength(1); j++)
                {
                    szekek[i, j] = new Szek(foglaltsag[i][j] == 'x', int.Parse(kategoria[i][j].ToString()));
                }
            }
            #endregion

            #region 2. feladat
            Console.Write("Sor? ");
            int sor = int.Parse(Console.ReadLine()) - 1;
            Console.Write("Oszlop? ");
            int oszlop = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Ez a szék " + (szekek[sor, oszlop].Foglalt ? "nem " : "") + "szabad.");
            #endregion

            #region 3. feladat
            int eladott = 0;
            foreach (var szek in szekek)
            {
                if (szek.Foglalt)
                {
                    eladott++;
                }
            }
            int szazalek = (int)((double)eladott / (15 * 20) * 100);
            Console.WriteLine($"Az előadásra eddig {eladott} jegyet adtak el, ez a nézőtér {szazalek}%-a.");
            #endregion

            #region 4. feladat
            int[] dbArkategoriankent = new int[5];
            foreach (var szek in szekek)
            {
                if (szek.Foglalt) { dbArkategoriankent[szek.ArKategoria - 1]++; }
            }

            int legtobb = 0;
            for (int i = 1; i < dbArkategoriankent.Length; i++)
            {
                if(dbArkategoriankent[i] > dbArkategoriankent[legtobb]) { legtobb = i; }
            }

            Console.WriteLine($"A legtöbb jegyet a(z) {legtobb + 1}. árkategóriában értékesítették.");
            #endregion

            #region 5. feladat
            int bevetel = 0;
            foreach (var szek in szekek)
            {
                bevetel += szek.Ar;
            }
            Console.WriteLine($"A színház bevétele {bevetel} Ft lenne.");
            #endregion

            #region 6. feladat
            int egyedulallo = 0;
            for (int i = 0; i < szekek.GetLength(0); i++)
            {
                for (int j = 0; j < szekek.GetLength(1); j++)
                {
                    if(!szekek[i,j].Foglalt)
                    {
                        if(!(j > 0 && !szekek[i,j-1].Foglalt || j < szekek.GetLength(1) - 1 && !szekek[i,j+1].Foglalt))
                        {
                            egyedulallo++;
                        }
                    }
                }
            }
            Console.WriteLine($"Összesen {egyedulallo} darab egyedülálló szék van.");
            #endregion

            #region 7. feladat
            using (StreamWriter streamWriter = new StreamWriter("szabad.txt"))
            {
                for (int i = 0; i < szekek.GetLength(0); i++)
                {
                    for (int j = 0; j < szekek.GetLength(1); j++)
                    {
                        streamWriter.Write(szekek[i, j]);
                    }
                    if(i < szekek.GetLength(0) - 1)
                    {
                        streamWriter.WriteLine();
                    }
                }
            }
            #endregion
        }
    }
}
