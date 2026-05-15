using System;

namespace PR7._2_efanova_lopatina.Models
{
    /// <summary>
    /// Проверка пользовательского ввода в графическом интерфейсе.
    /// </summary>
    public static class InputValidation
    {
        /// <summary>
        /// Проверяет, что строка пригодна для операции шифрования или дешифрования.
        /// </summary>
        /// <param name="text">Текст из поля ввода.</param>
        /// <param name="errorMessage">Сообщение об ошибке при неуспехе.</param>
        /// <returns><c>true</c>, если ввод допустим.</returns>
        public static bool TryValidateForOperation(string text, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                errorMessage = "Введите текст. Поле не должно быть пустым или состоять только из пробелов.";
                return false;
            }

            if (text.Length > Rot13Cipher.MaxInputLength)
            {
                errorMessage =
                    $"Превышена максимальная длина ввода ({Rot13Cipher.MaxInputLength} символов).";
                return false;
            }

            errorMessage = null;
            return true;
        }
    }
}
