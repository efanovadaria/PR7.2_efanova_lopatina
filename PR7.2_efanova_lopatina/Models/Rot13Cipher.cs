using System;

namespace PR7._2_efanova_lopatina.Models
{
    /// <summary>
    /// Ядро преобразования ROT13: сдвиг латинских букв на 13 позиций.
    /// </summary>
    public static class Rot13Cipher
    {
        /// <summary>
        /// Максимально допустимая длина обрабатываемой строки (защита от чрезмерного ввода).
        /// </summary>
        public const int MaxInputLength = 100_000;

        /// <summary>
        /// Выполняет преобразование ROT13.
        /// </summary>
        /// <param name="text">Исходный текст.</param>
        /// <returns>Строка после ROT13; для пустой или состоящей только из пробелов — пустая строка.</returns>
        /// <exception cref="ArgumentNullException">Если <paramref name="text"/> равен <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Если длина <paramref name="text"/> превышает <see cref="MaxInputLength"/>.</exception>
        public static string Rot13(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            if (text.Length > MaxInputLength)
                throw new ArgumentException(
                    $"Длина текста не должна превышать {MaxInputLength} символов.",
                    nameof(text));

            if (text.Length == 0 || string.IsNullOrWhiteSpace(text))
                return string.Empty;

            char[] chars = text.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];

                if (c >= 'a' && c <= 'z')
                {
                    chars[i] = (char)((c - 'a' + 13) % 26 + 'a');
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    chars[i] = (char)((c - 'A' + 13) % 26 + 'A');
                }
            }

            return new string(chars);
        }
    }
}
