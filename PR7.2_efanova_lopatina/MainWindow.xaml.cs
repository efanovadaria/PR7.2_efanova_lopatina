using PR7._2_efanova_lopatina.Models;
using System;
using System.Windows;

namespace PR7._2_efanova_lopatina
{
    /// <summary>
    /// Главное окно приложения ROT13 (вариант 12).
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Шифрует открытый текст модулем <see cref="Rot13Encryptor"/>.
        /// </summary>
        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            RunOperation(
                PlainTextBox.Text,
                Rot13Encryptor.Encrypt,
                "шифрования");
        }

        /// <summary>
        /// Дешифрует шифротекст модулем <see cref="Rot13Decryptor"/>.
        /// </summary>
        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            RunOperation(
                CipherInputTextBox.Text,
                Rot13Decryptor.Decrypt,
                "дешифрования");
        }

        /// <summary>
        /// Выполняет операцию с проверкой ввода и обработкой исключений.
        /// </summary>
        private void RunOperation(string input, Func<string, string> transform, string operationName)
        {
            try
            {
                if (!InputValidation.TryValidateForOperation(input, out string validationError))
                {
                    MessageBox.Show(
                        validationError,
                        "Проверка ввода",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }

                string result = transform(input);
                ResultTextBox.Text = result;
                CipherInputTextBox.Text = result;
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    $"Ошибка {operationName}",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    $"Ошибка {operationName}",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    $"Ошибка {operationName}",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Очищает все текстовые поля.
        /// </summary>
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            PlainTextBox.Clear();
            CipherInputTextBox.Clear();
            ResultTextBox.Clear();
        }
    }
}
