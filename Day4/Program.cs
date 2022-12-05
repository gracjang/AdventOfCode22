// See https://aka.ms/new-console-template for more information
var firstCounter = 0;
var secondCounter = 0;
await foreach (var line in File.ReadLinesAsync("./data.txt"))
{
    var pairs = line.Split(",");
    var firstPair = pairs[0].Split("-").Select(int.Parse).ToArray();
    var secondPair = pairs[1].Split("-").Select(int.Parse).ToArray();
    
    if( (firstPair[0] <= secondPair[0] && secondPair[0] <= secondPair[1] && secondPair[1] <= firstPair[1]) ||
       (secondPair[0] <= firstPair[0] && firstPair[0] <= firstPair[1] && firstPair[1] <= secondPair[1]))
    {
        firstCounter++;
    }

    if (!(firstPair[1] < secondPair[0]) && !(secondPair[1] < firstPair[0]))
    {
        secondCounter++;
    }
}

Console.WriteLine(firstCounter);
Console.WriteLine(secondCounter);