// Practicing Writing to a text stream
public class WritingToTextStreamPractice {
    public static void Run() {
        List<string> potionList = new List<string> {};

        // Adds potion
        potionList.Add("Health Potion");
        potionList.Add("Mana Potion");
        potionList.Add("Stamina Potion");
        potionList.Add("Strength Potion");
        potionList.Add("Intelligence Potion");
        potionList.Add("\"Fun\" Potion");

        // Directory address, streamwriter
        string folderPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + "\\PotionGame");
        string textFile = System.IO.Path.Combine(folderPath, "potions.txt");  
   
        // Check if the folder exists in documents
        bool exists = System.IO.Path.Exists(folderPath);

        if ( exists == false)
            System.IO.Directory.CreateDirectory(folderPath);
        
        // Creates Streamwriter
        var text = System.IO.File.CreateText(textFile);

        foreach (string potion in potionList) {
            //System.Console.Write(potion + " ");
            text.Write(potion + ", ");
        }
        text.Close();


        System.Console.Write(textFile);
    }

    public static void Dispose() {
        // Directory address, streamwriter
        string folderPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + "\\PotionGame");
        string textFile = System.IO.Path.Combine(folderPath, "potions.txt");  

        //System.Console.Write("Folder Path: " + folderPath + "\nText File: " + textFile);
        // Check if the folder exists in documents 
        bool exists = System.IO.Path.Exists(folderPath);

        if (exists == false)
            return;
        
        System.IO.Directory.Delete(textFile, recursive: true);
    }
}