using NUnit.Framework;
using System;

namespace MyRegExApp
{
    public class RegExClassTest
    {
        [SetUp]
        public void Setup()
        {
        }

        private void HandleException()
        {
            Console.WriteLine("Parameter cannot be Null or Empty string");
        }

        [Test]
        public void Test_Empty_string()
        {
            Assert.Throws<ArgumentNullException>(()=> "".BuildNewSentance());
        }

        [Test]
        public void Test_Null()
        {
            Assert.Throws<ArgumentNullException>(() => RegExClassExtn.BuildNewSentance(null));

        }

        [Test]
        public void Test_A_Word()
        {
            var newText = "Test".BuildNewSentance();
            Assert.AreEqual("T2t", newText);
        }

        [Test]
        public void Test_A_Special_Word()
        {
            var newText = "_T_".BuildNewSentance();
            Assert.AreEqual("_T_", newText);
        }

        [Test]
        public void Test_A_Special_Char_()
        {
            var newText = "_".BuildNewSentance();
            Assert.AreEqual("_", newText);
        }

        [Test]
        public void Test_A_Special_Char__()
        {
            var newText = "__".BuildNewSentance();
            Assert.AreEqual("__", newText);
        }

        [Test]
        public void Test_A_Special_Char___()
        {
            var newText = "___".BuildNewSentance();
            Assert.AreEqual("___", newText);
        }

        [Test]
        public void Test_A_Special_Char()
        {
            var newText = "$".BuildNewSentance();
            Assert.AreEqual("$", newText);
        }

        [Test]
        public void Test_Two_Special_Char()
        {
            var newText = "$&".BuildNewSentance();
            Assert.AreEqual("$&", newText);
        }

        [Test]
        public void Test_A_Special_2CharWord()
        {
            var newText = "_Tt_".BuildNewSentance();
            Assert.AreEqual("_Tt_", newText);
        }


        [Test]
        public void Test_A_Special_3CharWord()
        {
            var newText = "_TTt_".BuildNewSentance();
            Assert.AreEqual("_T1t_", newText);
        }

        [Test]
        public void Test_Two_Words()
        {
            var newText = "Hi there".BuildNewSentance();
            Assert.AreEqual("Hi t3e", newText);
        }

        [Test]
        public void Test_Two_Words_With_SpecialChar()
        {
            var newText = "Hi$Hello".BuildNewSentance();
            Assert.AreEqual("Hi$H2o", newText);
        }

        [Test]
        public void Test_CapsChar()
        {
            var newText = "hhhhhHHHHH".BuildNewSentance();
            Assert.AreEqual("h2H", newText);
        }

        [Test]
        public void Test_SpecialChars()
        {
            var newText = "under_score".BuildNewSentance();
            Assert.AreEqual("u3r_s3e", newText);
        }

        [Test]
        public void Test_Starts_With_Under_Score()
        {
            var newText = "_under*score&".BuildNewSentance();
            Assert.AreEqual("_u3r*s3e&", newText);
        }

        [Test]
        public void Test_StartsWith_SpecialChar()
        {
            var newText = "$under*score_".BuildNewSentance();
            Assert.AreEqual("$u3r*s3e_", newText);
        }

        [Test]
        public void Test_A_Sentance()
        {
            var newText = "Hey tihhis is*a& complex10text".BuildNewSentance();
            Assert.AreEqual("H1y t2s is*a& c5x10t2t", newText);
        }
    }
}