using MorseCode;

var input = Console.ReadLine();
if (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("Wrong input!");
    return;
}

var decoder = new MorseDecoder();
var decoded = decoder.Decode(input).Where(d => !string.IsNullOrWhiteSpace(d)).ToArray();

Console.WriteLine($"Found {decoded.Length} permutations.");

if (decoded.Length > 0)
{
    Console.WriteLine("With the following words from dictionary:");
    var words = await File.ReadAllLinesAsync("words_alpha.txt");
    foreach (var word in words.Intersect(decoded))
    {
        Console.WriteLine(word);
    }
}
