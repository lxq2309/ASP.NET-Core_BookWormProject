namespace BookWormProject.Utils.Helper
{
    public static class NumberHelper
    {
        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public static bool IsPrime(int number)
        {
            if (number <= 1)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}