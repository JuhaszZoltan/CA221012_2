using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CA221012_2
{
    internal class Fish
    {
        private float weight;
        private bool isWeightSet = false;
        private int swimTop;
        private int swimDepth;
        private string species;

        public float Weight
        {
            get => weight;
            set
            {
                if (value < .5f || value > 40f)
                    throw new Exception("Egy hal súlya csak [0.5, 40] között valid");
                if (isWeightSet)
                {
                    if (weight * 1.1f < value)
                        throw new Exception("Egy hal súlya egyszerre ennyit nem nőhet");
                    if (weight * .9f > value)
                        throw new Exception("Egy hal súlya egyszerre ennyit nem csökkenhet");
                }
                weight = value;
            }
        }
        public bool Predator { get; private set; }
        public int SwimTop
        {
            get => swimTop;
            set
            {
                if (value < 0 || value > 400)
                    throw new Exception("Egy hal minimális úszási mélysége csak [0, 400] között valid");
                swimTop = value;
            }
        }
        public int SwimDepth
        {
            get => swimDepth;
            set
            {
                if (value < 10 || value > 400)
                    throw new Exception("Egy hal merülési sávjának szélessége csak [10, 400] között valid");
                swimDepth = value;
            }
        }
        public int SwimBtm => SwimTop + SwimDepth;
        public string Species
        {
            get => species;
            set
            {
                if (value is null)
                    throw new Exception("Egy halnak a fajtája nem lehet null");
                if (value.Length < 3 || value.Length > 30)
                    throw new Exception("Egy halvajta minimum 3, maximum 30 karakter hosszó lehet");

                species = value;
            }
        }

        public void GetFishInfo()
        {
            Console.Write($"{Species, -8} ");
            Console.ForegroundColor = Predator ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write(Predator ? "(R) " : "(N) ");
            Console.ResetColor();
            Console.WriteLine($"{Weight,5:0.00}Kg " +
                $"[{SwimTop,3}-{SwimBtm,3}]cm");
        }

        public Fish(float weight, bool predator, int swimTop, int swimDepth, string species)
        {
            Weight = weight;
            isWeightSet = true;
            Predator = predator;
            SwimTop = swimTop;
            SwimDepth = swimDepth;
            Species = species;
        }
    }
}
