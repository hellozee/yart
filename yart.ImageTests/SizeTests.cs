using NUnit.Framework;

namespace yart.ImageTests
{
    [TestFixture]
    public class SizeTests
    {
        [Test]
        public void CreateSize()
        {
            var sz = new Size(50, 240);
            Assert.IsNotNull(sz);
        }
    }
}