namespace Chapter09;

using System.IO.Compression; // BrotliStream, GZipStream, CompressionMode
using System.Xml; // XmlWriter, XmlReader
using static System.Environment; // CurrentDirectory
using static System.IO.Path; // Combine

public class CompressProgram {
    public static void Compress(string algorithim = "gzip") {
        // define a file path using algorithim as file extension
        string filePath;

        filePath = GetFullPath(Combine(CurrentDirectory, @"..\..\Documentation" ,$"streams.{algorithim}"));
        FileStream file = File.Create(filePath);
        Stream compressor;
        //System.Console.Write(filePath);

        if (algorithim == "gzip") {
            compressor = new GZipStream(file, CompressionMode.Compress);
        }
        else {
            compressor = new BrotliStream(file, CompressionMode.Compress);
        }

        using (compressor) {
            using (XmlWriter xml = XmlWriter.Create(compressor)) {
                xml.WriteStartDocument();
                xml.WriteStartElement("callsigns");
                foreach (string item in Viper.Callsigns) {
                    xml.WriteElementString("callsign", item);
                }
            }
        } // also closes the underlying stream

        // output all the contents of the compressed file.
        System.Console.WriteLine("{0} contains {1:N0} bytes.", filePath, new FileInfo(filePath).Length);
        System.Console.WriteLine($"The compressed contents:");
        System.Console.WriteLine(File.ReadAllText(filePath));

        // read a compressed file
        System.Console.WriteLine("Reading the compressed XML file:");
        file = File.Open(filePath, FileMode.Open);
        Stream decompressor;

        // Decompress
        if (algorithim == "gzip") {
            decompressor = new GZipStream(file, CompressionMode.Decompress);
        }
        else {
            decompressor = new BrotliStream (file, CompressionMode.Decompress);
        }

        using (decompressor)
        using (XmlReader reader = XmlReader.Create(decompressor))

        while (reader.Read()) {

            // Check if we are on an element node named callsign
            if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsign")) {
                reader.Read(); // move to the text inside element
                System.Console.WriteLine($"{reader.Value}"); // read its value
            }
        }
    }
}
