using System;

public class The
{
    private static FruitGenerator _generator;

    public static Fruit SelectedFruit { get; set; }
    
    public static Line Line { get; set; }

    public static MatchRule MatchRule { get; set; }
    
    public static int Seed { get; set; }
    
    public static Board Board { get; set; }
    
    public static Config Config { get; set; }

    public static int Width
    {
        get { return Config.dimensions.x; }
    }

    public static int Height
    {
        get { return Config.dimensions.y; }
    }

    public static FruitGenerator Generator
    {
        get { return _generator; }
        set
        {
            if (_generator != null)
            {
                throw new Exception("Fruit Generator instance already set");
            }
            _generator = value;
        }
    }
}
