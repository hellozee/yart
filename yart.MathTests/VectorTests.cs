using NUnit.Framework;
using yart;

namespace yart.MathTests
{
    [TestFixture]
    public class VectorTests
    {
        [Test]
        public void CreateVector()
        {
            var v1 = new Vec3();
            var v2 = new Vec3(0.0);
            var v3 = new Vec3(1.0, 0.0, 0.0);

            Assert.IsTrue(v1 == v2);
            Assert.IsFalse(v2 == v3);
        }
    }
}