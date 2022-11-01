using AutoControlCShapeBind.DriverManager;

namespace AutoControlCShapeBind.Bind.RecordBind;

public class Record
{
    private readonly Driver _driver;

    public Record(Driver driver)
    {
        _driver = driver;
    }
    
    public string StartRecord(){
        return _driver.SendCommand("[[\"record\"]]");
    }

    public string StopRecord(){
        return _driver.SendCommand("[[\"stopRecord\"]]");
    }
    
}