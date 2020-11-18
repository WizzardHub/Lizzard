using System;

namespace Lizzard.Math
{
    class Pattern
    {

        Random random;

        public Pattern()
        {
            this.random = new Random();
        }

        public int Evaluate()
        {
            double chance = random.NextDouble() * 100.0D;
            return chance <= 10 ?
                random.Next(40, 50) : chance <= 30 ?
                random.Next(50, 70) : chance <= 60 ?
                random.Next(70, 80) : chance <= 90 ?
                random.Next(80, 100) : chance <= 91.7D ?
                random.Next(100, 120) : random.Next(150, 200);
        }
    }
}
