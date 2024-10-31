using Robbochinni.Driver.Mag.ValueObjects;
using System.Text;

namespace Robbochinni.Driver.Mag.Statics
{
    public class RandomGenerator
    {
        public static string Code => GetVarification();
        private static string GetVarification()
        {
            string _numbers = "0123456789";
            Random random = new Random();

            StringBuilder builder = new StringBuilder(6);
            string numberAsString = "";

            for (var i = 0; i < 6; i++)
            {
                builder.Append(_numbers[random.Next(0, _numbers.Length)]);
            }

            numberAsString = builder.ToString();

            return new Secret(numberAsString).EncryptSHA256();
        }
    }
}
