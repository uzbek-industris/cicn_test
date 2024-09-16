
using ConsoleApp1;
namespace TestProject1
{
    
    [TestFixture]
    public class TaylorSeriesTests
    {
        // Тесты для SinTaylor
        [Test]
        public void TestSinTaylor()
        {
            Assert.AreEqual(0, TaylorSeriesFunctions.SinTaylor(0), 1e-5);
            Assert.AreEqual(1, TaylorSeriesFunctions.SinTaylor(Math.PI / 2), 1e-5);
            Assert.AreEqual(0, TaylorSeriesFunctions.SinTaylor(Math.PI), 1e-5);
        }

        // Тесты для CosTaylor
        [Test]
        public void TestCosTaylor()
        {
            Assert.AreEqual(1, TaylorSeriesFunctions.CosTaylor(0), 1e-5);
            Assert.AreEqual(0, TaylorSeriesFunctions.CosTaylor(Math.PI / 2), 1e-5);
            Assert.AreEqual(-1, TaylorSeriesFunctions.CosTaylor(Math.PI), 1e-5);
        }

        // Тесты для LnTaylor
        [Test]
        public void TestLnTaylor()
        {
            Assert.AreEqual(0, TaylorSeriesFunctions.LnTaylor(1), 1e-5);
            Assert.AreEqual(1, TaylorSeriesFunctions.LnTaylor(Math.E), 1e-5);
            Assert.AreEqual(Math.Log(2), TaylorSeriesFunctions.LnTaylor(2), 1e-5);
        }

        // Тесты для главной функции
        [Test]
        public void TestMainFunction()
        {
            Assert.AreEqual(
                TaylorSeriesFunctions.SinTaylor(-1) * TaylorSeriesFunctions.SinTaylor(-1) +
                TaylorSeriesFunctions.CosTaylor(-1) * TaylorSeriesFunctions.CosTaylor(-1) +
                TaylorSeriesFunctions.LnTaylor(Math.Abs(TaylorSeriesFunctions.SinTaylor(-1))),
                MainFunction.Evaluate(-1), 1e-5);

            Assert.AreEqual(
                Math.Sqrt(TaylorSeriesFunctions.SinTaylor(2 * 2) +
                TaylorSeriesFunctions.CosTaylor(TaylorSeriesFunctions.LnTaylor(2 * 2))),
                MainFunction.Evaluate(2), 1e-5);
        }
    }
}