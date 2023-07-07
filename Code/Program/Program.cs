namespace Chapter09;
using static System.Console;
using System.Xml;
using static System.Environment;
using static System.IO.Path;
using static System.IO.Directory;

public partial class Program {
    public static void Main(string[] args) {
        //PrintTest.Ping();
        //WritingToTextStreamPractice.Run();
        //WritingToTextStreamPractice.Dispose();
        //WritingToXMLStreams.Run();
        //XMLPractice.Run();
        //CompressProgram.Compress(algorithim: "gzip");
        //CompressProgram.Compress(algorithim: "brotli");
        //CompressionPractice.CompressionPing();
        CompressionPractice.Compress();
    }
}



