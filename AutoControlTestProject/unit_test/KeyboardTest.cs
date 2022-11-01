using System.Collections;
using AutoControlCShapeBind.DriverManager;

namespace AutoControlTestProject.unit_test;

public class KeyboardTest
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
    public void TestPressKey(){
        _driver?.Keyboard.PressKey("a", false, false);
    }

    [Test]
    public void TestReleaseKey(){
        _driver?.Keyboard.ReleaseKey("a", false, false);
    }

    [Test]
    public void TestTypeKey(){
        _driver?.Keyboard.TypeKey("a", false, false);
    }

    [Test]
    public void TestCheckKeyIsPress(){
        _driver?.Keyboard.CheckKeyIsPress("a");
    }

    [Test]
    public void TestWrite(){
        _driver?.Keyboard.Write("abcdef", false);
    }

    [Test]
    public void TestHotKey(){
        var list = new ArrayList
        {
            "lcontrol",
            "a",
            "lcontrol",
            "c",
            "lcontrol",
            "v"
        };
        _driver?.Keyboard.Hotkey(list, false);
    }

    [Test]
    public void TestKeysTable(){
        _driver?.Keyboard.KeysTable();
    }
}