using System;

namespace BCEngine
{
    public class Util
    {
        static Random RandomGen = new Random();

        public static void setRandomSeed(int pSeed)
        {
            RandomGen = new Random(pSeed);
        }

        public static int GetInt(int pMin, int pMax)
        {
            return RandomGen.Next(pMin, pMax + 1);
        }

        public static bool CollideByBox(IActor p1, IActor p2)
        {
            return p1.BoundingBox.Intersects(p2.BoundingBox);
        }

    }
}