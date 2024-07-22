namespace oop_practice
{
    public static class Extension_methods
    {
       static void Main()
        {
            var text = "Hello bro";
            Console.WriteLine(text.WordCount());
        }
    }

    public static class StringExtensions
    {
        public static int WordCount(this string str)
        {
            return str.Split(' ').Length;
        }
    }

}
