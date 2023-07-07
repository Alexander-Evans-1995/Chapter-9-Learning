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

public static class WritingToXMLStreams {
    public static void Run() {
        SectionTitle("Writing to XML streams");

        // define a file path to write to
        string xmlFile = System.IO.Path.GetFullPath(System.IO.Path.Combine(System.Environment.CurrentDirectory, @"..\..\Documentation\streams.xml"));

        // declare variables for the filestream and XML writer
        // refractored for using statement rather than calling dispose()
        using FileStream? xmlFileStream = File.OpenWrite(xmlFile);
        using (System.Xml.XmlWriter? xml = System.Xml.XmlWriter.Create(xmlFileStream, new System.Xml.XmlWriterSettings {Indent = true})){
            // write the XML declaration
            xml.WriteStartDocument();

            // write a root element
            xml.WriteStartElement("callsigns");

            // enumerate the strings, writing each one to the stream
            foreach (string item in Viper.Callsigns) {
                xml.WriteElementString("callsign", item);
            }

            // write the close root element
            xml.WriteEndElement();
            
            // closer helper and stream
            xml.Close();
            xmlFileStream.Close();
        }

        // output all the contents to the file.
        WriteLine("{0} contains {1:N0} bytes", arg0: xmlFile, arg1: new FileInfo(xmlFile).Length);
        WriteLine(File.ReadAllText(xmlFile));
        // testing
        //System.Console.Write(xmlFile);
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