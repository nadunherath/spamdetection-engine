using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nadun.ML.SpamDetectEngine;

namespace Nadun.ML.SpamDetectEngineTesting
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //    NaiveBayes naiveBayes = new NaiveBayes();
        //    var result = naiveBayes.CheckEmail("Buy Cheap cialis Online");
        //    Assert.AreEqual(true, result);
        //    result = naiveBayes.CheckEmail("Enlarge Your Penis");
        //    Assert.AreEqual(true, result);
        //    result = naiveBayes.CheckEmail("accept VISA, MasterCard");
        //    Assert.AreEqual(true, result);
        //}


        [TestMethod]
        public void NaiveBayersNotSpamFalseTest()
        {
            NaiveBayes naiveBayes = new NaiveBayes();
            var result = naiveBayes.CheckSMS("Sincerely Mathias");
            Assert.AreEqual(false, result);
            result = naiveBayes.CheckSMS("Dear Graduates");
            Assert.AreEqual(false, result);
            result = naiveBayes.CheckSMS("Thanks in advance for your support");
            Assert.AreEqual(false, result);
            result = naiveBayes.CheckSMS("for it with my Mastercard");
            Assert.AreEqual(false, result);
        }



    }
}
