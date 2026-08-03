namespace Cat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Step 1
            if (args.Length == 1 && !Console.IsInputRedirected)
            {
                string filePath = args[0];
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"cat: {filePath}: no such file or directory");
                    Environment.ExitCode = 1;
                    return;
                }

                try
                {
                    using Stream sourceStream = File.OpenRead(filePath);
                    using Stream standardOut = Console.OpenStandardOutput();

                    sourceStream.CopyTo(standardOut);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"cat: {filePath}: {ex.Message}");
                    Environment.ExitCode = 1;
                }
            }
            // Step 2
            else if (args.Length == 0 && Console.IsInputRedirected)
            {
                string standardInData = Console.In.ReadToEnd();
                Console.Write(standardInData);

            }
            else
            {
                Console.Error.WriteLine("Usage: cat <file_path>");
                Environment.ExitCode = 1;
                return;
            }
        }

    }
}
