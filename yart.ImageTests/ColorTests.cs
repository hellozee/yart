using NUnit.Framework;

namespace yart.ImageTests
{
    [TestFixture]
    public class ColorTests
    {
        [Test]
        public void CreateColor()
        {
            var clr = new Color(20, 50, 60);
            Assert.IsNotNull(clr);
        }
    }
}