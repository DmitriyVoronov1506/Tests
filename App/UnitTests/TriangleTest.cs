using App;

namespace UnitTests
{
    [TestClass]
    public class TriangleTest
    {
        [TestMethod]
        public void TestIsValid_1()
        {
            Triangle triangle = new() { A = 1, B = 2, C = 3 };
            Assert.IsFalse(triangle.IsValid(), "1-2-3 Triangle should be Invalid");

            triangle.A = 1; triangle.B = 1; triangle.C = 1;
            Assert.IsTrue(triangle.IsValid(), "1-1-1 Triangle should be Invalid");
        }

        [TestMethod]
        public void TestIsValid_2()
        {
            Triangle triangle = new() { A = -1, B = 1, C = 1 };
            Assert.IsFalse(triangle.IsValid(), "-1-1-1 Triangle should be Invalid");

            triangle.A = 0; triangle.B = 1; triangle.C = 1;
            Assert.IsFalse(triangle.IsValid(), "0-1-1 Triangle should be Invalid");

            triangle.A = 5; triangle.B = 3; triangle.C = 7;
            Assert.IsTrue(triangle.IsValid(), "5-3-7 Triangle should be Invalid");

            triangle.A = 10; triangle.B = 10; triangle.C = -5;
            Assert.IsFalse(triangle.IsValid(), "10-10--5 Triangle should be Invalid");
        }

        [TestMethod]
        public void TestIsValid_0()
        {
            Triangle triangle = new() { A = 0, B = 1, C = 1 };
            Assert.IsFalse(triangle.IsValid(), " 0-1-1 Triangle is not VALID");

            triangle.A = 1; triangle.B = 0; triangle.C = 1;
            Assert.IsFalse(triangle.IsValid(), " 1-0-1 Triangle is not VALID");

            triangle.A = 1; triangle.B = 1; triangle.C = 0;
            Assert.IsFalse(triangle.IsValid(), " 1-1-0 Triangle is not VALID");

            triangle.A = 0; triangle.B = 0; triangle.C = 0;
            Assert.IsFalse(triangle.IsValid(), " 0-0-0 Triangle is not VALID");

            triangle.A = 1; triangle.B = 0; triangle.C = 0;
            Assert.IsFalse(triangle.IsValid(), " 1-0-0 Triangle is not VALID");

            triangle.A = 0; triangle.B = 0; triangle.C = 1;
            Assert.IsFalse(triangle.IsValid(), " 0-0-1 Triangle is not VALID");

            triangle.A = 1; triangle.B = 0; triangle.C = 1;
            Assert.IsFalse(triangle.IsValid(), " 0-1-0 Triangle is not VALID");
        }

        [TestMethod]
        public void TestIsRight()
        {
            Triangle triangle = new() { A = 3, B = 4, C = 5 };
            Assert.IsTrue(triangle.IsRight(), "3-4-5 is right");

            triangle = new() { A = 5, B = 4, C = 3 };
            Assert.IsTrue(triangle.IsRight(), "5-4-3 is right");

            triangle = new() { A = 5, B = 4, C = 3 };
            Assert.IsTrue(triangle.IsRight(), "4-5-3 is right");

            triangle = new() { A = 5, B = 4, C = 4 };
            Assert.IsFalse(triangle.IsRight(), "5-4-4 is not right");

            triangle = new() { A = -5, B = 4, C = 3 };
            Assert.IsFalse(triangle.IsRight(), "-5-4-3 is not right");

            triangle = new() { A = 0, B = 0, C = 0 };
            Assert.IsFalse(triangle.IsRight(), "0-0-0 is not right");
            
            triangle = new() { A = 2, B = 2, C = 2 * Math.Sqrt(2) };
            Assert.IsTrue(triangle.IsRight(), $"2-2-2v2 is right {triangle.C * triangle.C}");

            triangle = new() { A = 20, B = 20 * Math.Sqrt(2), C = 20 };
            Assert.IsTrue(triangle.IsRight(), $"20-20-20v2 is right {triangle.B * triangle.B}");

            triangle = new() { A = 20 * Math.Sqrt(2), B = 20, C = 20 };
            Assert.IsTrue(triangle.IsRight(), $"200-200-200v2 is right {triangle.C * triangle.C}");
        }
    }
}