namespace Cat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                args = new string[] { "-" };
            }

            foreach (string arg in args)
            {
                if (arg == "-")
                {
                    using Stream stdin = Console.OpenStandardInput();
                    using Stream stdout = Console.OpenStandardOutput();

                    stdin.CopyTo(stdout);
                }
                else
                {
                    string filePath = arg;

                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"cat: {filePath}: no such file or directory");
                        Environment.ExitCode = 1;
                        continue;
                    }
                    
                    try
                    {
                        using Stream stdin = File.OpenRead(arg);
                        using Stream stdout = Console.OpenStandardOutput();

                        stdin.CopyTo(stdout);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"cat: {arg}: {ex.Message}");
                        Environment.ExitCode = 1;
                    }

                }
            }
        }
    }
}
