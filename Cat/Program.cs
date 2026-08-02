namespace Cat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Step 1: open the file specified on the command line and write its contents to standard out.
            
            

            try
            {
                if (args.Length != 1)
                {
                    throw new Exception("Invalid Parameters");
                }

                string data = File.ReadAllText(args[0]);
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
