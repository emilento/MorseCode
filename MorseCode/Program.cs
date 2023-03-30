using MorseCode;

var input = Console.ReadLine();
if (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("Wrong input!");
    return;
}

var decoder = new MorseDecoder();
var decoded = decoder.Decode(input);

Console.WriteLine($"Found {decoded.Count} permutations.");

if (decoded.Count > 0)
{
    Console.WriteLine("With the following words from dictionary:");
    var words = await File.ReadAllLinesAsync("words_alpha.txt");
    foreach (var word in words.Intersect(decoded))
    {
        Console.WriteLine(word);
    }
}
