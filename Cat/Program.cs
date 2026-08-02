namespace Cat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.Error.WriteLine("Usage: cat <file_path>");
                Environment.ExitCode = 1;
                return;
            }

            try
            {
                string data = File.ReadAllText(args[0]);
                Console.WriteLine(data);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}
