using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Umayadia.Kana.Test
{
    [TestClass]
    public class KanaUtilTest
    {
        [TestMethod]
        public void ShiftJIS()
        {
            var sjis = Umayadia.Kana.KanaUtil.ShiftJIS;

            var b = sjis.GetBytes("楽しい.NET");
            Assert.AreEqual(10, b.Length,"A1000");

            var restored = sjis.GetString(b);
            Assert.AreEqual("楽しい.NET", restored, "A2000");


        }
    }
}
