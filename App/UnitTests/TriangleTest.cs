using App;

namespace UnitTests
{
    [TestClass]
    public class TriangleTest
    {
        [TestMethod]
        public void TestDefCtor()
        {
            Triangle triangle = new();
            Assert.IsNotNull(triangle, "Ctor returns Null");

            Triangle triangle2 = new();
            Assert.AreNotSame(triangle2, triangle, "Ctor returns reference");
            Assert.AreEqual(triangle2, triangle, "Empty triangles equals");
        }

        [TestMethod]
        public void TestParamCtor()
        {
            Triangle triangle = new(2, 3, 4);
            Assert.IsNotNull(triangle, "2-3-4 Ctor is not null");
            Assert.AreEqual(2, triangle.A, "2-3-4 Ctor -> A = 2");
            Assert.AreEqual(3, triangle.B, "2-3-4 Ctor -> B = 3");
            Assert.AreEqual(4, triangle.C, "2-3-4 Ctor -> C = 4");

            Assert.ThrowsException<ArgumentException>(() => triangle = new(1, 2, 3), "new(1, 2, 3) --> Exception");

            var ex = Assert.ThrowsException<ArgumentException>(() => triangle = new(-2, 2, 3), "new(-2, 2, 3) --> Exception");

            Assert.AreEqual("(-2, 2, 3) is not valid triangle", ex.Message, "Exception message invalid");

            Assert.AreEqual(
                "(3, -2, 3) is not valid triangle",
                Assert.ThrowsException<ArgumentException>(
                    () => triangle = new(3, -2, 3),
                    "new(3, -2, 3) --> Exception").Message,
                "Exception ,essage invalid");

            Random rand = new();

            for(int i = 0; i < 10; i++)
            {
                double c = rand.Next(-100, 0) / 10.0;

                Assert.ThrowsException<ArgumentException>(() => triangle = new(3, 2, c), $"3,2,{c} should be invalid");
            }
        }

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

        [TestMethod]
        public void TestPerimeter()
        {
            Triangle triangle = new() { A = 2, B = 2, C = 3 };
            Assert.AreEqual(7, triangle.Perimeter(), "2-2-3 --> 7");

            triangle = new() { A = 2 * Math.Sqrt(2), B = 2 * Math.Sqrt(2), C = 3 * Math.Sqrt(2) };
            Assert.AreEqual(7 * Math.Sqrt(2), triangle.Perimeter(), 1e-15 * triangle.Perimeter(), "2-2-3v2 --> 7v2");
        }

        [TestMethod]
        public void TestEqual()
        {
            Triangle triangle1 = new() { A = 2, B = 3, C = 4 };
            Triangle triangle2 = new() { A = 4, B = 2, C = 3 };

            Assert.AreEqual(triangle1, triangle2, "Triangles 2-3-4 equals 4-2-3");

            triangle1 = new() { A = 2, B = 3, C = 4 };
            triangle2 = new() { A = 2, B = 3, C = 4 };

            Assert.AreEqual(triangle1, triangle2, "Triangles 2-3-4 equals 2-3-4");

            triangle1 = new() { A = 4, B = 3, C = 2 };
            triangle2 = new() { A = 2, B = 3, C = 4 };

            Assert.AreEqual(triangle1, triangle2, "Triangles 4-3-2 equals 2-3-4");

            triangle1 = new() { A = 5, B = 3, C = 2 };
            triangle2 = new() { A = 2, B = 3, C = 4 };

            Assert.AreNotEqual(triangle1, triangle2, "Triangles 5-3-2 equals 2-3-4");
        }
    }
}