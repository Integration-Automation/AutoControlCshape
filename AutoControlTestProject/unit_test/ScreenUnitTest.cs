using AutoControlCShapeBind.DriverManager;

namespace AutoControlTestProject.unit_test;

public class Tests
{
    private static Driver _driver;
    
    [SetUp]
    public static void Setup()
    {
        _driver = new Driver("127.0.0.1", 9938, "", "windows");
    }

    [Test]
    public void TestSize()
    {

    }

    [TearDown]
    public void QuitTest()
    {
        _driver.Quit();
    }
}