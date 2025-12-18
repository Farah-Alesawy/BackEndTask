namespace ShortestStringProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] stringArray = { "code", "backend", "ai", "circle" };
            string answer = DetShortestString(stringArray);
            Console.WriteLine($"Output: {answer}");
        }

        static string DetShortestString(string[] stringArray)
        {
            string shortest = stringArray[0];

            foreach (string item in stringArray)
            {
                if (item.Length < shortest.Length)
                {
                    shortest = item;
                }
            }

            return shortest;
        }
    }
}
