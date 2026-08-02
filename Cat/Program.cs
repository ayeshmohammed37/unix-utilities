namespace Cat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Step 1: open the file specified on the command line and write its contents to standard out.
            string path = "C:\\Users\\ayesh\\ayesh_work\\Dev\\unix-utilities\\TestData\\test2.txt";

            try
            {
                string data = File.ReadAllText(path);
                Console.WriteLine(data);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
