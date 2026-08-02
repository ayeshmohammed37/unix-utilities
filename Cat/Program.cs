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

            string path = args[0];

            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"cat: {path}: no such file or directory");
                Environment.ExitCode = 1;
                return;
            }

            try
            {
                using Stream sourceStream = File.OpenRead(path);
                using Stream standardOut = Console.OpenStandardOutput();

                sourceStream.CopyTo(standardOut);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"cat: {path}: {ex.Message}");
                Environment.ExitCode = 1;
            }
        }
    }
}
