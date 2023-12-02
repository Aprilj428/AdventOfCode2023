namespace AdventOfCode2023Day2;

public static class Extensions
{
    public static char? ToCharFromWordForm(this string wordForm) => wordForm switch
    {
        "one" => '1',
        "two" => '2',
        "three" => '3',
        "four" => '4',
        "five" => '5',
        "six" => '6',
        "seven" => '7',
        "eight" => '8',
        "nine" => '9',
        _ => null
    };
}