namespace RandomGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RandomGeneratorController
    {
        private static Random random = new Random();
        private const string Capitals = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string SmallLetters = "abcdefghijklmnopqrstuvwxyz";

        public int GetRandomInt(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue + 1);
        }

        public string GetRandomString(int minLength, int maxLength, bool CapitalizeFirstLetter = false)
        {
            var length = random.Next(minLength, maxLength + 1);
            var output = new StringBuilder();
            var numberOfSmallLetters = SmallLetters.Length;

            for (int i = 0; i < length; i++)
            {
                output.Append(SmallLetters[random.Next(0, numberOfSmallLetters)]);
            }

            if (CapitalizeFirstLetter)
            {
                output[0] = char.ToUpper(output[0]);
            }

            return output.ToString();
        }

        public DateTime GetRandomDateTime(int? fromYear = null, int? toYear = null)
        {
            fromYear = fromYear ?? 1920;
            toYear = toYear ?? 2050;
            var year = random.Next((int)fromYear, (int)toYear + 1);
            var month = random.Next(1, 13);
            var day = random.Next(1, 29);
            var hour = random.Next(1, 24);
            var minute = random.Next(1, 60);
            var seconds = random.Next(1, 60);
            var milliseconds = random.Next(1, 100);

            return new DateTime(year, month, day, hour, minute, seconds, milliseconds);
        }
    }
}
