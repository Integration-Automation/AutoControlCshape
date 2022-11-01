using AutoControlCShapeBind.DriverManager;

namespace AutoControlTestProject.unit_test;

public class ImageTests
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
    public void TestLocateAllImage(){
        _driver?.Image.LocateAllImage(
            Directory.GetCurrentDirectory() + "/test_resource/test_image.png",
            0.9,
            false
        );
    }

    [Test]
    public void TestLocateImageCenter(){
        _driver?.Image.LocateImageCenter(
            Directory.GetCurrentDirectory() + "/test_resource/test_image.png",
            0.9,
            false
        );

    }

    [Test]
    public void TestLocateAndClick(){
        _driver?.Image.LocateAndClick(
            Directory.GetCurrentDirectory() + "/test_resource/test_image.png",
            "mouse_left",
            0.9,
            false
        );

    }
}