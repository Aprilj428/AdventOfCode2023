namespace AdventOfCode2023Day2;

public enum Color
{
    Red,
    Blue,
    Green
}

public static class ColorExtensions
{
    public static Color ToColor(this string colorText) => colorText switch
    {
        "red" => Color.Red,
        "blue" => Color.Blue,
        "green" => Color.Green,
        _ => throw new ArgumentOutOfRangeException(nameof(colorText), colorText, null)
    };
}