using AutoControlCShapeBind.DriverManager;

namespace AutoControlCShapeBind.Bind.Screen;

public class Screen
{
    private Driver _driver;

    public Screen(Driver driver)
    {
        _driver = driver;
    }
    
    public void locateAllImage(string imagePath, double detectThreshold, bool drawImage) {
        imagePath = imagePath.Replace("\\", "/");
        _driver.SendCommand(string.Format("[[\"locate_all_image\", {{\"image\": \"{0}\"," +
                                          "\"detect_threshold\": {1}," +
                                          "\"draw_image\": {2}}}]]",
            imagePath, detectThreshold, drawImage)
        );
    }
    
}