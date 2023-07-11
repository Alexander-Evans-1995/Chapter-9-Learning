namespace Chapter09;
using static System.Console;
using System.Formats.Tar; // TarFile
public static class TarFileWrapper {
    public static void TarFileRun() {
        try {
            string current = Environment.CurrentDirectory;
            WriteInformation($"Current directory: {current}");
            string sourceDirectory = Path.GetFullPath(Path.Combine(current + @"..\..\..\Documentation\images"));
            string destinationDirectory = Path.GetFullPath(Path.Combine(current + @"..\..\..\Documentation\", "extracted"));
            string tarFile = Path.GetFullPath(Path.Combine(current + @"..\..\..\Documentation\images-archive\", "images-archive.tar"));
        
            if (!Directory.Exists(sourceDirectory)) {
                WriteError($"The {sourceDirectory} directory must exist. Please create it and add some files to it.");
            }
            if (File.Exists(tarFile)) {
                // If the Tar archive file already exists then we must delete it.
                File.Delete(tarFile);
                WriteWarning($"{tarFile} already existed so it was deleted.");
            }

            WriteInformation($"Archiving directory: {sourceDirectory}\n      To .tar file:        {tarFile}");
            TarFile.CreateFromDirectory(sourceDirectoryName: sourceDirectory, destinationFileName: tarFile, includeBaseDirectory: true);
            WriteInformation($"Does {tarFile} exist? {File.Exists(tarFile)}.");

            if (!Directory.Exists(destinationDirectory)) {
                // If the destination directory does not exist then we must create
                // it before extracting a Tar archive to it.
                Directory.CreateDirectory(destinationDirectory);
                WriteWarning($"{destinationDirectory} did not exist so it was created.");
            }

            WriteInformation($"Extracting archive:  {tarFile}\n      To directory:        {destinationDirectory}");
            TarFile.ExtractToDirectory(sourceFileName: tarFile, destinationDirectoryName: destinationDirectory, overwriteFiles: true);
        
            if (Directory.Exists(destinationDirectory))
            {
                foreach (string dir in Directory.GetDirectories(destinationDirectory))
                {
                    WriteInformation($"Extracted directory {dir} containing these files: " + string.Join(',', Directory.EnumerateFiles(dir).Select(file => Path.GetFileName(file))));
                }
            }
        }
        catch (Exception ex) {
            WriteError(ex.Message);
        }
    }    
    static void WriteError(string message)
    {
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.Red;
        WriteLine($"Fail: {message}");
        ForegroundColor = previousColor;
    }

    static void WriteWarning(string message) {
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine($"WARN: {message}");
        ForegroundColor = previousColor;
    }

    static void WriteInformation (string message) {
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine($"INFO: {message}");
        ForegroundColor = previousColor;
    }
}