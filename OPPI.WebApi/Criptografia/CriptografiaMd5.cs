using System;
using System.Security.Cryptography;
using System.Text;

namespace OPPI.WebApi.Criptografia
{
    public static class CriptografiaMd5
    {
        public static string Criptografar(string senha)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }

        public static bool Comparar(string senhaCriptografada, string senha)
        {
            StringComparer compara = StringComparer.OrdinalIgnoreCase;
            return 0 == compara.Compare(senhaCriptografada, Criptografar(senha));
        }
    }
}
