using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreSystem.Helpers;

namespace CoreSystem.Tests
{
    [TestClass]
    public class TripleDESHelperTests
    {
        [TestMethod]
        public void TestEncryptDecrypt()
        {
            const string cleartext = "helloworld";
            var encrypted = TripleDESHelper.Encrypt(cleartext);
            var decrypted = TripleDESHelper.Decrypt(encrypted);

            Assert.AreEqual(cleartext, decrypted);
        }
    }
}
