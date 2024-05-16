namespace OOP_Prov
{
    public class TG
    {
        public static void Normal(string text)
        {
            foreach(char c in text)
            {
                Console.Write(c);
                Thread.Sleep(0); //50
            }
            Console.WriteLine();
        }

        public static void Slow(string text)
        {
            foreach(char c in text)
            {
                Console.Write(c);
                Thread.Sleep(0); //200
            }
            Console.WriteLine();
        }
    }
}