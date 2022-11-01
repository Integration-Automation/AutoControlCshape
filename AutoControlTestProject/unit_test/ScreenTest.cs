using AutoControlCShapeBind.DriverManager;

namespace AutoControlTestProject.unit_test;

public class ScreenTests
{
    private static Driver? _driver;
    
    [SetUpFixture]
    public class TestsSetupClass
    {
        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            _driver?.Quit();
        }
    }

    [SetUp]
    public void SetUp()
    {
        _driver = new Driver("127.0.0.1", 9938, "", "windows");
        Assert.That(_driver, Is.Not.Null);
    }

    [Test]
    public void TestSize() {
        _driver?.Screen.ScreenSize();
    }

    [Test]
    public void TestScreenshot() {
        _driver?.Screen.Screenshot();
        _driver?.Screen.Screenshot(Directory.GetCurrentDirectory() + "/test.png");
        _driver?.Screen.Screenshot(100, 100, 500, 500);
        _driver?.Screen.Screenshot(
            Directory.GetCurrentDirectory() + "/test1.png",
            100, 100, 500, 500);
    }
    
}