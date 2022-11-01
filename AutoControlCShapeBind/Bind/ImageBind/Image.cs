using AutoControlCShapeBind.DriverManager;

namespace AutoControlCShapeBind.Bind.ImageBind;

public class Image
{
    private readonly Driver _driver;

    public Image(Driver driver)
    {
        _driver = driver;
    }

    private string MakeBoolToText(bool checkBool)
    {
        return checkBool ? "true" : "false";
    }
    
    public string LocateAllImage(string imagePath, double detectThreshold, bool drawImage) {
        imagePath = imagePath.Replace("\\", "/");
        return _driver.SendCommand(string.Format("[[\"locate_all_image\", {{\"image\": \"{0}\"," +
                                          "\"detect_threshold\": {1:0.0}," +
                                          "\"draw_image\": {2}}}]]",
            imagePath, detectThreshold, MakeBoolToText(drawImage))
        );
    }
    
    public string LocateImageCenter(string imagePath, double detectThreshold, bool drawImage) {
        imagePath = imagePath.Replace("\\", "/");
        return _driver.SendCommand(
            string.Format(
                "[[\"locate_image_center\", {{\"image\": \"{0}\"," +
                "\"detect_threshold\": {1:0.0}," +
                "\"draw_image\": {2}}}]]",
                imagePath, detectThreshold, MakeBoolToText(drawImage))
        );
    }

    public string LocateAndClick(string imagePath, string mouseKeycode,double detectThreshold, bool drawImage) {
        imagePath = imagePath.Replace("\\", "/");
        return _driver.SendCommand(
            string.Format(
                "[[\"locate_and_click\", {{\"image\": \"{0}\"," +
                "\"mouse_keycode\": \"{1}\"," +
                "\"detect_threshold\": {2:0.0}," +
                "\"draw_image\": {3}}}]]",
                imagePath, mouseKeycode,detectThreshold, MakeBoolToText(drawImage))
        );
    }
    
}