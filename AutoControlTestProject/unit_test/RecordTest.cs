using AutoControlCShapeBind.DriverManager;

namespace AutoControlTestProject.unit_test;

public class RecordTests
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
    public void TestRecord(){
        _driver?.Record.StartRecord();
        _driver?.Record.StopRecord();
    }
    
}