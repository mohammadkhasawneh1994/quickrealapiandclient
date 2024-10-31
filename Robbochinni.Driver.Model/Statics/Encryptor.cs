using System.Text;
using System.Security.Cryptography;
using Robbochinni.Driver.Mag.ValueObjects;

namespace Robbochinni.Driver.Mag.Statics
{
    public static class Encryptor
    {
        public static string EncryptSHA256(this Secret data)
        {
            if (data == null) return null!;

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data.Data!));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
