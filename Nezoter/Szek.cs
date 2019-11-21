using System;
namespace Nezoter
{
    public class Szek
    {
        public bool Foglalt { get; set; }
        public int ArKategoria { get; set; }

        int[] arak = { 5000, 4000, 3000, 2000, 1500 };

        public Szek(bool foglalt, int arKategoria)
        {
            Foglalt = foglalt;
            ArKategoria = arKategoria;
        }

        public int Ar {
            get
            {
                if(Foglalt)
                    return arak[ArKategoria - 1];
                return 0;
            }
        }

        public override string ToString()
        {
            return Foglalt ? "x" : ArKategoria.ToString();
        }


    }
}
