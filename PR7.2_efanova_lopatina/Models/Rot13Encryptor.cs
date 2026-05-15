using System;

namespace PR7._2_efanova_lopatina.Models
{
    /// <summary>
    /// Модуль шифрования методом ROT13.
    /// </summary>
    public static class Rot13Encryptor
    {
        /// <summary>
        /// Шифрует текст ROT13 (для ROT13 операция совпадает с дешифрованием).
        /// </summary>
        /// <param name="plainText">Открытый текст.</param>
        /// <returns>Зашифрованная строка.</returns>
        public static string Encrypt(string plainText)
        {
            return Rot13Cipher.Rot13(plainText);
        }
    }
}
