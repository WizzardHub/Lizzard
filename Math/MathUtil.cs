namespace Lizzard.Math
{
    class MathUtil
    {

        public static double ConvertDelayToCps(int delay)
        {
            return 1000.0D / delay;
        }

    }
}
