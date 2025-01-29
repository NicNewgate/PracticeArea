// Hole den Pfad zum aktuellen Arbeitsverzeichnis
using Newtonsoft.Json;
using System.Text.Json;

string currentDirectory = Directory.GetCurrentDirectory();

// Gib den Pfad aus
Console.WriteLine("Das aktuelle Arbeitsverzeichnis ist: " + currentDirectory + "\n");

// Gibt die erste Indexziffer an der das wort/der zu suchend string gefunden wurde wieder
int index = currentDirectory.IndexOf("bin");

if (index >= 0)
{
    // Schneide den Text ab dem Index des Wortes ab
    string trimmedText = currentDirectory.Substring(0, index);
    Console.WriteLine("Getrimmter Text: " + trimmedText + "\n");

    // Enumeriere alle unterverzeichnisse innerhalb von "stores"
    IEnumerable<string> listOfDirectories = Directory.EnumerateFiles(trimmedText + "stores", "*.txt", SearchOption.AllDirectories);

    // Ausgabe der Verzeichnisse
    foreach (string directory in listOfDirectories)
    {
        Console.WriteLine(directory);
    }
}
else
{
    Console.WriteLine("Das Wort wurde nicht gefunden.");
}

Console.WriteLine($"\n***************************************************\n");

//*********************************- FindFiles -*****************************************************

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (string file in foundFiles)
    {
        // The file name will contain the full path, so only check the end of it
        var extension = Path.GetExtension(file);
        if (file.EndsWith(".json"))
        {
            salesFiles.Add(file);
        }
    } 
    return salesFiles;
}

Console.WriteLine($"\n***************************************************\n");

// further examples
string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
Console.WriteLine(docPath);
Console.WriteLine($"stores{Path.DirectorySeparatorChar}201");
Console.WriteLine(Path.Combine("stores", "201"));
Console.WriteLine(Path.GetExtension("sales.json")); // outputs: .json

Console.WriteLine($"\n***************************************************\n");

// use path-class for directoryseperators - keep in mind that not all systems use the same separators
string fileName = $"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales{Path.DirectorySeparatorChar}sales.json";
FileInfo info = new FileInfo(fileName);
Console.WriteLine($"Full Name: {info.FullName}{Environment.NewLine}Directory: {info.Directory}{Environment.NewLine}Extension: {info.Extension}{Environment.NewLine}Create Date: {info.CreationTime}"); // And many more

Console.WriteLine($"\n***************************************************\n");

// windows doesnt rly care about font or backslashes... but other environments do
FileInfo a =  new FileInfo("C:/Users/steck/source/repos/PracticeArea/MicrosoftLearn/DirectorySystems/stores/204/inventory.txt");
Console.WriteLine($"Full Name: {a.FullName}{Environment.NewLine}Directory: {a.Directory}{Environment.NewLine}Extension: {a.Extension}{Environment.NewLine}Create Date: {a.CreationTime}"); // And many more

Console.WriteLine($"\n***************************************************\n");

// Create, read, update, delete - Files -> Modern = CRUD, one example of creating
var filePath = Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "stores", "201", "newDir")).ToString();


// check if dir exits
bool doesDirectoryExist = Directory.Exists(filePath);
Console.WriteLine($"Existiert der Dateipfad? ->{doesDirectoryExist}");

if( doesDirectoryExist )
{
    Console.WriteLine(filePath);
}

Console.WriteLine();

// Create files in Directory and write
var greetingFile = "greeting.txt";
var greetingFilePath = Path.Combine(Directory.GetCurrentDirectory(), greetingFile);
File.WriteAllText(greetingFilePath, "Hello World!");

if (File.Exists(greetingFilePath))
{
    Console.WriteLine($"File \"{greetingFile}\" exits!");
}

Console.WriteLine($"\n***************************************************\n");

// Further practice with FindFiles()

var storesDirectory = Path.Combine(currentDirectory, "stores");
var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");

Directory.CreateDirectory(salesTotalDir);

var salesFiles = FindFiles(storesDirectory);

// Generate a txt files and write "" in it with String.Empty
var salesTotalsFile = Path.Combine(salesTotalDir, "totals.txt");

//***************************************************
// Reading data from files
var salesJ = File.ReadAllText($"{currentDirectory}{Path.DirectorySeparatorChar}stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");
Console.WriteLine(salesJ + "\n");

// Reading with Newtonsoft.Json
var salesData = JsonConvert.DeserializeObject<SalesTotal>(salesJ);
Console.WriteLine(salesData.Total);

Console.WriteLine($"\n***************************************************\n");

//***************************************************
// Writing data into files
File.WriteAllText(salesTotalsFile, $"{salesData.Total}{Environment.NewLine}");
// Update data in files
File.AppendAllText(salesTotalsFile, $"{salesData.Total}{Environment.NewLine}");

//***************************************************
// New Function to calculate all data
var salesTotal = CalculateSalesTotal(salesFiles);
//File.WriteAllText(salesTotalsFile, String.Empty);
File.AppendAllText(salesTotalsFile, $"{salesTotal}{Environment.NewLine}");


// Reading and Writeing data
double CalculateSalesTotal(IEnumerable<string> salesFiles)
{
    double salesTotal = 0;

    //READ FILES LOOP
    foreach (var file in salesFiles)
    {
        // Read the contents of the file
        string salesJson = File.ReadAllText(file);

        // Parse the contents as JSON
        SalesData? data = System.Text.Json.JsonSerializer.Deserialize<SalesData?>(salesJson);

        // Add the amount found in the Total field to the salesTotal variable
        salesTotal += data?.Total ?? 0;
    }

    return salesTotal;
}

// *** PROPERTIES ***

record SalesData (double Total);

class SalesTotal
{
    public double Total { get; set; }
}