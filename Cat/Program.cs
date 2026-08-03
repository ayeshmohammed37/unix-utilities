namespace Cat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool nFlag = false;
            bool bFlag = false;
            int numLine = 0;

            if (args.Length == 0)
            {
                args = new string[] { "-" };
            }
            else
            {
                foreach (var arg in args)
                {
                    if (arg == "-b") bFlag = true;
                    if (arg == "-n") nFlag = true;
                }
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
                    if (arg == "-n" || arg == "-b")
                        continue;

                    string filePath = arg;

                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"cat: {filePath}: no such file or directory");
                        Environment.ExitCode = 1;
                        continue;
                    }
                    
                    try
                    {   
                        if (bFlag)
                        {
                            var lines = File.ReadAllLines(filePath);
                            foreach (var l in lines)
                            {
                                if (l == "\n" || l == "\n\r" || l == "\r\n" || l.IsWhiteSpace())
                                {
                                    Console.WriteLine();
                                    continue;
                                }
                                Console.WriteLine($"{++numLine} {l}");
                            }
                        }
                        else if (nFlag)
                        {
                            var lines = File.ReadAllLines(filePath);
                            foreach (var l in lines)
                            {
                                Console.WriteLine($"{++numLine} {l}");
                            }
                        }
                        else
                        {
                            using Stream stdin = File.OpenRead(arg);
                            using Stream stdout = Console.OpenStandardOutput();
                            stdin.CopyTo(stdout);
                        }
                        
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
