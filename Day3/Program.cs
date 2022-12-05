var sumOfFirstTask = 0;
var groupRucksack = File.ReadLines("./data.txt").ToList();
foreach (var line in groupRucksack)
{
    var firstRucksack = line[..(line.Length / 2)];
    var secondRucksack = line.Substring(line.Length / 2, line.Length / 2);

    var commonCharacters = firstRucksack.Intersect(secondRucksack).SingleOrDefault();
    sumOfFirstTask += CheckPriorities(commonCharacters);
}

var secondTaskSum = groupRucksack
    .Chunk(3)
    .Select(group => group[0].Intersect(group[1]).Intersect(group[2])
        .ToList())
    .Select(common => CheckPriorities(common.Single())).Sum();

Console.WriteLine($"FirstTaskSum: {sumOfFirstTask}");
Console.WriteLine($"SecondTaskSum: {secondTaskSum}");

int CheckPriorities(char c)
{
    return char.IsLower(c) ? c < 97 ? c - 64 : c - 96 : (c - 64) + 26;
}