using System;

namespace PR7._2_efanova_lopatina.Models
{
    /// <summary>
    /// Модуль дешифрования методом ROT13.
    /// </summary>
    public static class Rot13Decryptor
    {
        /// <summary>
        /// Дешифрует текст ROT13 (алгоритм идентичен шифрованию).
        /// </summary>
        /// <param name="cipherText">Шифротекст.</param>
        /// <returns>Расшифрованная строка.</returns>
        public static string Decrypt(string cipherText)
        {
            return Rot13Cipher.Rot13(cipherText);
        }
    }
}
