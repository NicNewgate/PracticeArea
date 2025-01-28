using System.Diagnostics;

/**
* Microsoft Übung! 
* Übungsbeschreibung:
* gegeben:

var fibonacciNumbers = new List<int> {1, 1};

var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];

fibonacciNumbers.Add(previous + previous2);

foreach(var item in fibonacciNumbers)
{
    Console.WriteLine(item);
}

* Versuchen Sie, einige dieser Konzepte aus dieser Lektion 
* und früheren Lektionen in einen Zusammenhang zu bringen. 
* Erweitern Sie das, was Sie bisher bezüglich Fibonacci-Zahlen erstellt haben. 
* Versuchen Sie, den Code zum Generieren der ersten 20 Zahlen 
* der Sequenz zu schreiben. (Hinweis: Die 20. Fibonacci-Zahl lautet 6765.)
**/

var fibonacciNumbers = new List<int> { 1, 1 };
int previous, preprevious, sum;

Debug.WriteLine($"Entering for-iteration");

//index 0 und 1 sind schon in verwendung von daher starten wir mit 2
for (int i = 2; i < 20; ++i)
{
    previous = fibonacciNumbers[i - 1];
    preprevious = fibonacciNumbers[i - 2];

    Debug.WriteLineIf(preprevious == 1 && previous ==1, $"preprevious and previous is 1");

    sum = previous + preprevious;

    Debug.Assert(sum == 5, "The return value is not 5 and it should be.");

    fibonacciNumbers.Add(sum);
}

//Ausgabe
foreach (var number in fibonacciNumbers)
{
    Console.WriteLine(number);
}