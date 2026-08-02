namespace Cat
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}
