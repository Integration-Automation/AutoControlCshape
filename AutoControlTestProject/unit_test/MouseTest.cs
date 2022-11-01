using AutoControlCShapeBind.DriverManager;

namespace AutoControlTestProject.unit_test;

public class KeyboardTests
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
    public void PositionTest() {
        _driver?.Mouse.Position();
    }

    [Test]
    public void SetPositionTest() {
        for (var i = 0; i < 11; i++) {
            _driver?.Mouse.SetPosition(100, 100);
            _driver?.Mouse.SetPosition(500, 500);
        }
    }

    [Test]
    public void UseMouseTest() {
        _driver?.Mouse.PressMouse("mouse_left");
        _driver?.Mouse.ReleaseMouse("mouse_left");
        _driver?.Mouse.PressMouse("mouse_left", 100, 100);
        _driver?.Mouse.ReleaseMouse("mouse_left", 100, 100);
        _driver?.Mouse.ClickMouse("mouse_left");
        _driver?.Mouse.ClickMouse("mouse_left", 100, 100);
        _driver?.Mouse.Scroll(-100);
        _driver?.Mouse.Scroll(-100, 100, 100);
        _driver?.Mouse.Scroll(100, 100, 100, "scroll_down");
    }

    [Test]
    public void TestSpecialTable(){
        _driver?.Mouse.SpecialTable();
    }
    
}