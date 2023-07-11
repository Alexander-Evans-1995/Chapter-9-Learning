namespace Chapter09;

public static class TarPracticeWrapper {
    public static void Run() {
        // Decompress a group of images from zip.
        // Then Compress them into tar.

        string startPath, zipPath, extractedPath, tarStartPath, tarEndPath;

        startPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(System.Environment.CurrentDirectory, @"..\..\Documentation\"));
        // Zip images
        zipPath = System.IO.Path.Combine(startPath, "images.zip");
        extractedPath = System.IO.Path.Combine(startPath, @"extracted");
        tarStartPath = System.IO.Path.Combine(extractedPath, @"\images");
        tarEndPath = System.IO.Path.Combine(startPath, @"images-archive\images.tar");

        // Extracts the file from .zip into extracted
        System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractedPath);

        // tar execution
        System.Formats.Tar.TarFile.CreateFromDirectory(extractedPath, tarEndPath, true);


        
        // Testing
        System.Console.Write("End of Program");
    }
}