namespace Cat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Step 1: open the file specified on the command line and write its contents to standard out.
            string path = "C:\\Users\\ayesh\\ayesh_work\\Dev\\unix-utilities\\TestData\\test.txt";

            string data = File.ReadAllText(path);

            Console.Write(data);
        }
    }
}
