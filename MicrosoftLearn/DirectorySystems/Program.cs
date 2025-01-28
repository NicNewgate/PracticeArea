using System;
using System.IO;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

// Hole den Pfad zum aktuellen Arbeitsverzeichnis
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
