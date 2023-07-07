namespace Chapter09;

public static class CompressionPractice {
    public static void CompressionPing() {
        System.Console.Write("CompressionPing");
    }

    // Compresses a list of names in a tennis match
    public static void Compress() {
        string filePath, zipPath, fileName, zipName;
        //String? line; // for stream reader
        //byte[] buffer;
        //Stream compressor;
        //FileStream file, zipFile;
        //StreamReader reader;

        // name of the file to be compressed
        fileName = @"\tennis lineup.txt";
        filePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(System.Environment.CurrentDirectory, @"..\..\Documentation" + fileName));
        
        zipName = @"\tennis lineup.gz";
        zipPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(System.Environment.CurrentDirectory, @"..\..\Documentation" + zipName));
        
        System.Console.WriteLine(filePath + "\n" + zipPath);
        // retrieve the file into filestream
        using FileStream file = File.Open(filePath, FileMode.Open);
        using FileStream zipFile = File.Create(zipPath);
        using StreamReader reader = new StreamReader(file);

        using Stream compressor = new System.IO.Compression.GZipStream(zipFile, compressionLevel: 0);
        
        file.CopyTo(compressor);
        
        /* **testing** */

        // File Path
        //System.Console.Write(filePath);
        // Outputing file
        //while ((line = reader.ReadLine()) != null) {System.Console.WriteLine(line);}
    }
}