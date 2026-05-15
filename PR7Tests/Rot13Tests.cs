using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR7._2_efanova_lopatina.Models;
using System;

namespace PR7Tests
{
    /// <summary>
    /// Автоматизированные тесты по сценариям из Documents/03_Testovye_scenarii.md.
    /// </summary>
    [TestClass]
    public class Rot13Tests
    {
        [TestMethod]
        public void Rot13Cipher_SelfInverse_Uppercase()
        {
            const string original = "HELLO";
            Assert.AreEqual(original, Rot13Cipher.Rot13(Rot13Cipher.Rot13(original)));
        }

        [TestMethod]
        public void Rot13Cipher_SelfInverse_Lowercase()
        {
            const string original = "abc";
            Assert.AreEqual(original, Rot13Cipher.Rot13(Rot13Cipher.Rot13(original)));
        }

        [TestMethod]
        public void Rot13Cipher_KnownPair_N_to_A()
        {
            Assert.AreEqual("A", Rot13Cipher.Rot13("N"));
        }

        [TestMethod]
        public void Rot13Cipher_MixedCaseAndNonLetters()
        {
            Assert.AreEqual("No1!", Rot13Cipher.Rot13("Ab1!"));
        }

        [TestMethod]
        public void Rot13Cipher_IgnoresDigits()
        {
            Assert.AreEqual("nop123", Rot13Cipher.Rot13("abc123"));
        }

        [TestMethod]
        public void Rot13Cipher_PunctuationUnchangedStructure()
        {
            Assert.AreEqual("n,o", Rot13Cipher.Rot13("a,b"));
        }

        [TestMethod]
        public void Rot13Cipher_CyrillicUnchanged()
        {
            Assert.AreEqual("Привет", Rot13Cipher.Rot13("Привет"));
        }

        [TestMethod]
        public void Rot13Cipher_NewlineAndSpaces()
        {
            Assert.AreEqual("n o\np", Rot13Cipher.Rot13("a b\nc"));
        }

        [TestMethod]
        public void Rot13Cipher_EmptyString_ReturnsEmpty()
        {
            Assert.AreEqual(string.Empty, Rot13Cipher.Rot13(""));
        }

        [TestMethod]
        public void Rot13Cipher_WhitespaceOnly_ReturnsEmpty()
        {
            Assert.AreEqual(string.Empty, Rot13Cipher.Rot13("   "));
        }

        [TestMethod]
        public void Rot13Cipher_Null_Throws()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Rot13Cipher.Rot13(null));
        }

        [TestMethod]
        public void Rot13Encryptor_MatchesCore()
        {
            const string input = "Hello";
            Assert.AreEqual(Rot13Cipher.Rot13(input), Rot13Encryptor.Encrypt(input));
        }

        [TestMethod]
        public void Rot13Decryptor_MatchesCore()
        {
            const string input = "Uryyb";
            Assert.AreEqual(Rot13Cipher.Rot13(input), Rot13Decryptor.Decrypt(input));
        }

        [TestMethod]
        public void Rot13Encrypt_And_Decrypt_AreSameOperation()
        {
            const string input = "Test ROT13!";
            Assert.AreEqual(
                Rot13Encryptor.Encrypt(input),
                Rot13Decryptor.Decrypt(input));
        }

        [TestMethod]
        public void Rot13Encryptor_Null_Throws()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Rot13Encryptor.Encrypt(null));
        }

        [TestMethod]
        public void Rot13Decryptor_Null_Throws()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Rot13Decryptor.Decrypt(null));
        }

        [TestMethod]
        public void Rot13Encryptor_TooLong_Throws()
        {
            string longText = new string('a', Rot13Cipher.MaxInputLength + 1);
            Assert.ThrowsException<ArgumentException>(() => Rot13Encryptor.Encrypt(longText));
        }
    }
}
