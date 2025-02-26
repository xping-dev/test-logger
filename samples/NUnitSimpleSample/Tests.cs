/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

namespace NUnitSimpleSample;

[TestFixture]
public class Tests
{
    [SetUp]
    public void Setup()
    { }

    [Test]
    public void Test()
    {
        Assert.Pass();
    }

    [TestCase(1)]
    [Test]
    public void TestWithTestCase(int i)
    {
        Assert.Pass();
    }

    [Test]
    public void TestWithException()
    {
        //throw new ArgumentException("This is an exception");
    }
}
