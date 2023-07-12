namespace Chapter09;
using static System.Console;
using System.Text;

public static class EncodingWrapper {
    public static void Run() {
        WriteLine("Encodings");
        WriteLine("[1] ASCII");
        WriteLine("[3] UTF-8");
        WriteLine("[4] UTF-16 (Unicode)");
        WriteLine("[5] UTF-32");
        WriteLine("[6] Latin1");
        WriteLine("[any other key] Default encoding");
        WriteLine();

        // choose an encoding
        Write("Press a number to choose an encoding.");
        ConsoleKey number = ReadKey(intercept: true).Key;

        WriteLine(); WriteLine();

        Encoding encoder = number switch {
            ConsoleKey.D1 or ConsoleKey.NumPad1 => Encoding.ASCII,
            ConsoleKey.D2 or ConsoleKey.NumPad2 => Encoding.UTF7,
            ConsoleKey.D3 or ConsoleKey.NumPad3 => Encoding.UTF8,
            ConsoleKey.D4 or ConsoleKey.NumPad4 => Encoding.Unicode,
            ConsoleKey.D5 or ConsoleKey.NumPad5 => Encoding.UTF32,
            ConsoleKey.D6 or ConsoleKey.NumPad6 => Encoding.Latin1,
            _                                   => Encoding.Default

        };

        // define a string to encode
        string message = "Café £4.39";
        WriteLine($"Text to encode: {message} Characters: {message.Length}");
        // encode the string into a byte array
        byte[] encoded = encoder.GetBytes(message);
        // Testing
        System.Console.Write("Success");
    }
}