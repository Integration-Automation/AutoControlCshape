using AutoControlCShapeBind.DriverManager;

namespace AutoControlCShapeBind.Bind.ScreenBind;

public class Screen
{
    private readonly Driver _driver;

    public Screen(Driver driver)
    {
        _driver = driver;
    }
    
    public string ScreenSize() {
        return _driver.SendCommand("[[\"size\"]]");
    }

    public string Screenshot() {
        return _driver.SendCommand(("[[\"screenshot\"]]"));
    }

    public string Screenshot(string filePath) {
        filePath = filePath.Replace("\\", "/");
        return _driver.SendCommand(
            string.Format("[[\"screenshot\", {{\"file_path\": \"{0}\"}}]]", filePath)
        );
    }

    public string Screenshot(int leftX, int leftY, int rightX, int rightY) {
        return _driver.SendCommand(
            string.Format("[[\"screenshot\", {{\"region\": [{0}, {1}, {2}, {3}]}}]]", leftX, leftY, rightX, rightY)
        );
    }

    public string Screenshot(String filePath, int leftX, int leftY, int rightX, int rightY) {
        filePath = filePath.Replace("\\", "/");
        return _driver.SendCommand(
            string.Format("[[\"screenshot\", {{\"file_path\": \"{0}\", \"region\": [{1}, {2}, {3}, {4}]}}]]",
                filePath, leftX, leftY, rightX, rightY)
        );
    }
}