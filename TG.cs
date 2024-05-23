namespace OOP_Prov
{
    public class TG
    {
        public static void Normal(string text)
        {
            foreach(char c in text)
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.WriteLine();
        }

        public static void Slow(string text)
        {
            foreach(char c in text)
            {
                Console.Write(c);
                Thread.Sleep(200);
            }
            Console.WriteLine();
        }
    }
}