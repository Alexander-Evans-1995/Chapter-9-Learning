namespace Chapter09;

using static System.Console;
using System.Xml.Serialization; // XmlSerializer
using static System.Environment;
using static System.IO.Path;
using Packt.Shared; // Person

public class SerializationWrapper {
    public static void Run() {
        // Create an object graph
        List<Person> people = new() {
            new(30000M) {
                FirstName = "Alice",
                LastName = "Smith",
                DateOfBirth = new(year: 1974, month: 3, day: 14)
            },

            new(40000M) 
            {
                FirstName = "Bob",
                LastName = "Jones",
                DateOfBirth = new(year: 1969, month: 11, day: 23)
            },

            new(20000M)
            {
                FirstName = "Charlie",
                LastName = "Cox",
                DateOfBirth = new(year: 1984, month: 5, day: 4),
                Children = new()
                {
                    new(0M)
                    {
                        FirstName = "Sally",
                        LastName = "Cox",
                        DateOfBirth = new(year: 2012, month: 7, day: 12)
                    }
                }
            }
        }; // End Person Constructor

        // create objec that will format a List of Persons as XML
        XmlSerializer xs = new(type: people.GetType());

        // Create a file to write to
        string path = GetFullPath(Combine(CurrentDirectory, @"..\..\Documentation\people.xml"));

        using (FileStream stream = File.Create(path)) {
            // serialize the object graph to the stream
            xs.Serialize(stream, people);
        }

        WriteLine("Written {0:N0} bytes of XML to {1}", arg0: new FileInfo(path).Length, arg1: path);
        WriteLine();

        // Display the serialized object graph
        WriteLine(File.ReadAllText(path));

        WriteLine();
        WriteLine("* Deserializing XML files");
        using (FileStream xmlLoad = File.Open(path, FileMode.Open)) {
            // deserialize and cast the object graph into a List of Persons
            List<Person>? loadedPeople = xs.Deserialize(xmlLoad) as List<Person>;

            if (loadedPeople is not null) {
                foreach (Person p in loadedPeople) {
                    WriteLine("{0} has {1} children.", p.LastName, p.Children?.Count ?? 0);
                }
            }
        }
        
        // Testing
        System.Console.WriteLine("Path: " + path);
    }

    public static void Print() {
        string path = GetFullPath(Combine(CurrentDirectory, @"..\..\Documentation\xmlSerialization\people.xml"));

        // Testing
        System.Console.WriteLine("Path: " + path);
    }

    public static void Deserialize() {
        string path = GetFullPath(Combine(CurrentDirectory, @"..\..\Documentation\people.xml"));


    }
}