// See https://aka.ms/new-console-template for more information

var elvesCalories = new List<int>();
var caloriesCounter = 0;

await foreach (var line in File.ReadLinesAsync("./data.txt"))
{
    if (string.IsNullOrEmpty(line))
    {
        elvesCalories.Add(caloriesCounter);
        caloriesCounter = 0;
        continue;
    }

    caloriesCounter += ((IConvertible)line).ToInt32(default);
}

var maxCalories = elvesCalories.Max();
var bestThreeElves = elvesCalories.OrderDescending().Take(3).Sum();

Console.WriteLine(maxCalories);
Console.WriteLine(bestThreeElves);