﻿using System.Collections.Generic;
using Encryption.Framework.Algorithms;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Encryption.Tests.Algorithms
{
    [TestFixture]
    [Category("DES")]
    public class DesTests
    {
        [Test]
        [TestCaseSource(nameof(DesEncryptTestCases))]
        public void AesEncrypt_WithValidData_ShouldReturnEncryptedString(string text, string key, string iv)
        {
            var result = Aes.Encrypt(text, key, iv);
            Assert.IsNotNull(result);
        }

        [Test]
        [TestCaseSource(nameof(DesEncryptTestCases))]
        public void AesDecrypt_WithValidData_ShouldReturnDecryptedString(string text, string key, string iv)
        {
            var encryptString = Aes.Encrypt(text, key, iv);
            Assert.IsNotNull(encryptString);
            var result = Aes.Decrypt(encryptString, key, iv);
            Assert.IsNotNull(result);
            Assert.AreEqual(text, result);
        }

        private static IEnumerable<TestCaseData> DesEncryptTestCases
        {
            get
            {
                var testCaseData = new List<TestCaseData>
                {
                    new TestCaseData("Test", "HNtgQw0wAbZrURKx", "VN53WuL2VkKaVTf5"),
                    new TestCaseData("Polischuk", "iUaHmasVRY6xDIsZ", "NFmYfOnWCLFUZ0qq"),
                    new TestCaseData("Artem", "ghrw8z1mA6kOMQrFnwxq4321", "IGwRDzLAr0BCQ6jv"),
                    new TestCaseData("JULIK", "IGwRDzLAr0BCQ6jvIGwRDzLAr0BCQ6jv", "IGwRDzLAr0BCQ6jv"),
                    new TestCaseData("Тестируем разную КІРїЛЁЦґ", "IGwRDzLAr0BCQ6jvIGwRDzLAr0BCQ6jv", "IGwRDzLAr0BCQ6jv")
                };
                return testCaseData;
            }
        }
    }
}

