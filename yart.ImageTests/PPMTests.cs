using NUnit.Framework;

namespace yart.ImageTests
{
    [TestFixture]
    public class PPMTests
    {
        [Test]
        public void WritePPM()
        {
            var img = new yart.Image(new Size(5, 5));

            for (var i = 0; i < 5; i++)
            {
                for(var j = 0; j < 5; j++)
                {
                    img.SetColor(i, j, new Color(255,255,255));
                }
            }
            
            img.Save("ding");
            
            Assert.IsNotNull(img);
        }
    }
}