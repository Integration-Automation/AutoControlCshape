using System.Collections;
using System.Text;
using AutoControlCShapeBind.DriverManager;

namespace AutoControlCShapeBind.Bind.KeyboardBind;

public class Keyboard
{
    private readonly Driver _driver;

    public Keyboard(Driver driver)
    {
        _driver = driver;
    }
    
    private string MakeBoolToText(bool checkBool)
    {
        return checkBool ? "true" : "false";
    }
    
     public string KeysTable() {
        return _driver.SendCommand(("[[\"keys_table\"]]"));
    }

    public string PressKey(string keycode, bool isShift, bool skipRecord) {
        return _driver.SendCommand(
            string.Format("[[\"press_key\", " +
                          "{{" +
                          "\"keycode\": \"{0}\"," +
                          "\"is_shift\": {1}, " +
                          "\"skip_record\": {2} " +
                          "}}]]",
                        keycode, MakeBoolToText(isShift), MakeBoolToText(skipRecord))
        );
    }

    public string ReleaseKey(string keycode, bool isShift, bool skipRecord) {
        return _driver.SendCommand(
            string.Format("[[\"release_key\", " +
                          "{{" +
                          "\"keycode\": \"{0}\"," +
                          "\"is_shift\": {1}, " +
                          "\"skip_record\": {2} " +
                          "}}]]",
                        keycode, MakeBoolToText(isShift), MakeBoolToText(skipRecord))
        );
    }

    public string TypeKey(string keycode, bool isShift, bool skipRecord) {
        return _driver.SendCommand(
            string.Format("[[\"type_key\", " +
                          "{{" +
                          "\"keycode\": \"{0}\"," +
                          "\"is_shift\": {1}, " +
                          "\"skip_record\": {2} " +
                          "}}]]",
                        keycode, MakeBoolToText(isShift), MakeBoolToText(skipRecord))
        );
    }

    public string CheckKeyIsPress(string keycode) {
        return _driver.SendCommand(
            $"[[\"check_key_is_press\", {{\"keycode\": \"{keycode}\"}}]]"
        );
    }

    public string Write(string writeString, bool isShift) {
        return _driver.SendCommand(
            string.Format("[[\"write\", " +
                          "{{" +
                          "\"write_string\": \"{0}\", " +
                          "\"is_shift\": {1} " +
                          "}}]]",
                        writeString, MakeBoolToText(isShift))
        );
    }

    public string Hotkey(ArrayList keyCodeList, bool isShift)
    {
        var hotKeyCommandBuildBuffer = new StringBuilder();
        hotKeyCommandBuildBuffer.Append("[[\"hotkey\", ").Append("{{").Append("\"key_code_list\": ");
        hotKeyCommandBuildBuffer.Append('[');
        for (int index = 0; index < keyCodeList.Count - 1; index++) {
            if(index < keyCodeList.Count - 1)
                hotKeyCommandBuildBuffer.Append('"').Append(keyCodeList[index]).Append('"').Append(", ");
            else
                hotKeyCommandBuildBuffer.Append('"').Append(keyCodeList[index]).Append('"');
        }
        hotKeyCommandBuildBuffer.Append(']');
        hotKeyCommandBuildBuffer.Append(string.Format(", \"is_shift\": {0}}}]]", MakeBoolToText(isShift)));
        return _driver.SendCommand(hotKeyCommandBuildBuffer.ToString());
    }
    
}