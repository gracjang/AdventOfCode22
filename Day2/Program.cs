// A - ROCK / B - Paper / C- Scissors
// X / Y / Z

// rock - 1 / paper - 2 / scissors - 3
// win - 6 / draw - 3 /  lost 0
var shapeScores = new Dictionary<string, int>()
{
    {"BX", 1}, // lost + rock
    {"CY", 2}, // lost + paper
    {"AZ", 3}, // lost + scissors
    
    {"AX", 4}, // draw + rock
    {"BY", 5}, // draw + paper
    {"CZ", 6}, // draw + scissors
    
    {"CX", 7}, // lost + rock
    {"AY", 8}, // draw + rock
    {"BZ", 9} // win + scissors
};

// X - lose / Y - draw / Z - win
var shapeSecondStrategy = new Dictionary<string, int>()
{
    {"AY", 4}, // draw + rock
    {"AX", 3}, // lose + scissors
    {"AZ", 8}, // win + paper
    
    {"BY", 5}, // draw + paper
    {"BX", 1}, // lose + rock
    {"BZ", 9}, // win + scissors
    
    {"CY", 6}, // draw + scissors 
    {"CX", 2}, // lose + paper
    {"CZ", 7}, // win + rock
    
};

var counter = 0;
var secondCounter = 0;
await foreach (var line in File.ReadLinesAsync("./data.txt"))
{
    var gameResult = line.Replace(" ", string.Empty);
    counter += shapeScores[gameResult];
    secondCounter += shapeSecondStrategy[gameResult];
}

Console.WriteLine(counter);
Console.WriteLine(secondCounter);
