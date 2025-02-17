namespace Practice
{
    public class Tests
    {
        EvenDecider eventDecider;
        StringReverser stringReverser;

        /// <summary>
        ///  Arrange, Act, Assert
        /// </summary>
        [SetUp]
        public void Setup()
        {
            eventDecider = new EvenDecider();
            stringReverser = new StringReverser();
        }

        [TestCase(4)]
        [TestCase(168)]
        [TestCase(2024)]
        [TestCase(-400)]
        [TestCase(0)]
        public void TestEvenNumbers(int number)
        {
            bool result = eventDecider.IsEven(number);
            Assert.IsTrue(result);
        }

        [TestCase(3)]
        [TestCase(169)]
        [TestCase(1021)]
        [TestCase(421)]
        [TestCase(-19)]
        public void TestOddNumbers(int number)
        {
            bool result = eventDecider.IsEven(number);
            Assert.IsFalse(result);
        }

        [TestCase("alma", "amla")]
        [TestCase("adél", "léda")]
        [TestCase("indulagörögaludni", "indulagörögaludni")]
        [TestCase("körte", "etrök")]
        public void TestReverseString(string text, string reversedText)
        {
            string result = stringReverser.Reverse(text);
            Assert.AreEqual(reversedText, result);
        }
    }
}