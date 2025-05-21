/************************************************************
 * Autor: Gaina Alexandru
 * Data crearii: 2025-05-20
 * Ultima modificare: 2025-05-20
 * Fisier: PasswordHasher.cs
 * Functionalitate: Conține metoda statica de convertire prin algoritm sha a unui sir de caractere catre un hash
 ************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InstantScoreNewsLib
{
    public class PasswordHasher
    {/// <summary>
    /// Algoritm unidirectional de hashing a datelor
    /// </summary>
    /// <param name="str">Sirul ce urmeaza a fi hash</param>
    /// <returns>Sirul hash</returns>
        public static string HashString(string str)
        {
            HashAlgorithm sha = new SHA1CryptoServiceProvider();
            byte[] buf = new byte[str.Length];
            for (int i = 0; i < str.Length; i++)
                buf[i] = (byte)str[i];
            byte[] result = sha.ComputeHash(buf);
            return Convert.ToBase64String(result);
        }
    }
}
