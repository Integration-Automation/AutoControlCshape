using AutoControlCShapeBind.DriverManager;

namespace AutoControlCShapeBind.Bind.MouseBind;

public class Mouse
{
    private readonly Driver _driver;

    public Mouse(Driver driver)
    {
        _driver = driver;
    }
    
     public string SpecialTable() {
        return _driver.SendCommand(("[[\"special_table\"]]"));
    }

    public string Position(){
        return _driver.SendCommand("[[\"position\"]]");
    }

    public string SetPosition(int x, int y){
        return _driver.SendCommand(
            string.Format("[[\"set_position\", {{\"x\": {0}, \"y\": {1}}}]]", x, y)
        );
    }

    public string PressMouse(string mouseKeycode){
        return _driver.SendCommand(
            string.Format("[[\"press_mouse\", {{\"mouse_keycode\": \"{0}\"}}]]", mouseKeycode)
        );
    }

    public string PressMouse(string mouseKeycode, int x, int y){
        return _driver.SendCommand(
            string.Format("[[\"press_mouse\", {{\"mouse_keycode\": \"{0}\", \"x\": {1}, \"y\": {2}}}]]", mouseKeycode, x, y)
        );
    }


    public string ReleaseMouse(string mouseKeycode){
        return this._driver.SendCommand(
            string.Format("[[\"release_mouse\", {{\"mouse_keycode\": \"{0}\"}}]]", mouseKeycode)
        );
    }

    public string ReleaseMouse(string mouseKeycode, int x, int y){
        return _driver.SendCommand(
            string.Format("[[\"release_mouse\", {{\"mouse_keycode\": \"{0}\", \"x\": {1}, \"y\": {2}}}]]", mouseKeycode, x, y)
        );
    }


    public string ClickMouse(String mouseKeycode){
        return _driver.SendCommand(
            string.Format("[[\"click_mouse\", {{\"mouse_keycode\": \"{0}\"}}]]", mouseKeycode)
        );
    }

    public string ClickMouse(string mouseKeycode, int x, int y){
        return _driver.SendCommand(
            string.Format("[[\"click_mouse\", {{\"mouse_keycode\": \"{0}\", \"x\": {1}, \"y\": {2}}}]]", mouseKeycode, x, y)
        );
    }

    public string Scroll(int scrollValue){
        return _driver.SendCommand(
            string.Format("[[\"scroll\", {{\"scroll_value\": {0}}}]]", scrollValue)
        );
    }

    public string Scroll(int scrollValue, int x, int y){
        return _driver.SendCommand(
            string.Format("[[\"scroll\", {{\"scroll_value\": {0}, \"x\": {1}, \"y\": {2}}}]]",
                        scrollValue, x, y)
        );
    }

    public string Scroll(int scrollValue, int x, int y, string scrollDirection){
        return _driver.SendCommand(
            string.Format("[[\"scroll\", {{\"scroll_value\": {0}, \"x\": {1}, \"y\": {2}, \"scroll_direction\": \"{3}\"}}]]",
                        scrollValue, x, y, scrollDirection)
        );
    }
    
}