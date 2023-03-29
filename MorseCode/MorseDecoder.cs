namespace MorseCode
{
    public class MorseDecoder
    {
        private static readonly Dictionary<char, string> Map = new()
        {
            { 'A', ".-" },
            { 'B', "-..." },
            { 'C', "-.-." },
            { 'D', "-.." },
            { 'E', "." },
            { 'F', "..-." },
            { 'G', "--." },
            { 'H', "...." },
            { 'I', ".." },
            { 'J', ".---" },
            { 'K', "-.-" },
            { 'L', ".-.." },
            { 'M', "--" },
            { 'N', "-." },
            { 'O', "---" },
            { 'P', ".--." },
            { 'Q', "--.-" },
            { 'R', ".-." },
            { 'S', "..." },
            { 'T', "-" },
            { 'U', "..-" },
            { 'V', "...-" },
            { 'W', ".--" },
            { 'X', "-..-" },
            { 'Y', "-.--" },
            { 'Z', "--.." }
        };

        public IEnumerable<string> Decode(string input)
        {
            var results = Map
                .Where(pair => input.StartsWith(pair.Value))
                .Select(pair => new
                {
                    Letter = pair.Key,
                    Remaining = input[pair.Value.Length..]
                })
                .ToArray();

            if (results.Length <= 0)
            {
                return new[] { string.Empty };
            }

            var query =
                from r in results
                from decoded in Decode(r.Remaining)
                select (r.Letter + decoded).ToLowerInvariant();

            return query.ToArray();
        }
    }
}
