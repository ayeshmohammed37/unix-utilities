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
                if (arg == "-n" || arg == "-b") continue;

                Stream inputStream = null;

                if (arg == "-")
                {
                    inputStream = Console.OpenStandardInput();
                }
                else
                {
                    if (!File.Exists(arg))
                    {
                        Console.Error.WriteLine($"cat: {arg}: no such file or directory");
                        Environment.ExitCode = 1;
                        continue;
                    }
                    inputStream = File.OpenRead(arg);
                }

                try
                {
                    // if either flag is true, then we must process line-by-line
                    if (bFlag || nFlag)
                    {
                        using var record = new StreamReader(inputStream, leaveOpen: true);
                        string line;

                        while ((line = record.ReadLine()) is not null)
                        {
                            if (bFlag && string.IsNullOrEmpty(line))
                            {
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine($"{++numLine,6}\t{line}");
                            }
                        }
                    }
                    // no flags; write all inputStream to outputStream
                    else
                    {
                        using Stream stdout = Console.OpenStandardOutput();
                        inputStream.CopyTo(stdout);
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"cat: {arg}: {ex.Message}");
                    Environment.ExitCode = 1;
                }
                finally
                {
                    if (arg == "-")
                        inputStream.Dispose();
                }                
            }
        }
    }
}
