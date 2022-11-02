using AutoControlCShapeBind.DriverManager;

Driver driver = new Driver("127.0.0.1", 9938, "", "windows");

Console.WriteLine(driver.Mouse.Position());
