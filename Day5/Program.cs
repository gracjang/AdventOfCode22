var crates = Enumerable.Range(0, 9).Select(x => new Stack<string>()).ToList();
foreach (var line in File.ReadAllLines("./stackInput.txt"))
{
    for (var k = 0; k <= line.Length/4; k++)
    {
        var character = line[k * 4 + 1].ToString();
        if (character == " ")
        {
            continue;
        }
        crates[k].Push(character);
    }
}

var reverseStack = crates.Select(x => x.Reverse().ToList()).ToList();
foreach (var line in File.ReadAllLines("./data.txt"))
{
    
    var numbers = line.Split(new[] { "move", "from", "to" }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    var count = numbers[0];
    var from = numbers[1]-1;
    var to = numbers[2]-1;

    var sourceElements = reverseStack[from].Take(count).Reverse();
    reverseStack[to].InsertRange(0, sourceElements);
    reverseStack[from].RemoveRange(0, count);
}

Console.WriteLine(string.Join("", reverseStack.Select(x => x.First())));