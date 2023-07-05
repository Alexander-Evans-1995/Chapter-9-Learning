namespace Chapter09;
using static System.Console;

public class PrintTest {
    public static void Ping() {
        System.Console.Write("Success");
    }
}

public static class WritingToTextStream {
    public static void Run() {
        SectionTitle("Writing to text streams");
        // define a file to write to
        string textFile = System.IO.Path.Combine(System.Environment.CurrentDirectory, "streams.txt");
        Console.WriteLine(System.Environment.CurrentDirectory);
        // create a text file and return a helper writer
        StreamWriter text = File.CreateText(textFile);
        // enumerate the strings, writing each one
        // to the stream on a separate line
        foreach (string item in Viper.Callsigns)
        {
            text.WriteLine(item);
        }
        text.Close(); // release resources
        // output the contents of the file
        WriteLine("{0} contains {1:N0} bytes.",
        arg0: textFile,
        arg1: new FileInfo(textFile).Length);
        WriteLine(File.ReadAllText(textFile));
    }

    static void SectionTitle(string title)
    {
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine("*");
        WriteLine($"* {title}");
        WriteLine("*");
        ForegroundColor = previousColor;
    }
}