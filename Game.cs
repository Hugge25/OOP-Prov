using System;
using System.ComponentModel.Design;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace OOP_Prov
{
    public class Game
    {
        public void Meny() //Ville namn ge den Meny, men går inte eftersom då skapas en konstruktor.
        {
            Console.WriteLine("   - PLAY, P -");
            Console.WriteLine("- LEADERBOARD, L -");
            Console.WriteLine("   - QUIT, Q -");

            var input = Console.ReadKey();
            Console.Clear();
            
            switch(input.Key)
            {
                case ConsoleKey.P:
                    Play();
                    break;

                case ConsoleKey.L:
                    StreamReader sr = new StreamReader("Score.txt");
                    
                    for(int i = 0; i < 3; i++)
                    {
                        Console.WriteLine(sr.ReadLine()); //Skriver ut de tre bästa resultaten
                    }
                    
                    sr.Close();
                    Meny();
                    break;
                
                case ConsoleKey.Q:
                    break;

                default:
                    Console.WriteLine("Type P, L or Q.");
                    Meny();
                    break;
            }
        }

        public void Play()
        {
            Player player = new Player(); //Skapar player
            Goblin goblin = new Goblin(); //Skapar goblin
            Wizard wizard = new Wizard(); //Skapar wizard
            
            List<Goblin> goblins = new List<Goblin>(); //Skapar lista för goblins
            List<Wizard> wizards = new List<Wizard>(); //Skapar lista för wizards

            goblins.Add(goblin); //Lägger till goblin i listan "goblins"
            wizards.Add(wizard); //Lägger till wizards i listan "wizards"



            Random rnd = new Random(); //Skapar en random som används för att bestämma vems tur det är"
            
            while(true)
            {
                int turn = rnd.Next(1, 7); //Bestämmer vems tur det är att anfalla

                if(turn == 1 || turn == 2 || turn == 3 || turn == 4) //De olika fallen då player attackerar
                {
                    player.Attack();
                    if(wizard.Hp < goblin.Hp)
                    {
                        goblin.TakeDamage(player.Damage);
                    }
                    else
                    {
                        wizard.TakeDamage(player.Damage);
                    }
                }
                else if(turn == 5 && goblin.Hp > 0) //Goblin attackerar om det är dess tur och deras hp är mer än 0
                {
                    goblin.Attack();
                    player.TakeDamage(goblin.Damage); //Player tar skada med den mängd som goblin gör skada
                }
                else if(turn == 6 && wizard.Hp > 0) //Wizard attackerar om det är dess tur och deras hp är mer än 0
                {
                    wizard.Attack();
                    player.TakeDamage(wizard.Damage); // ... wizard gör skada
                }

                if(player.Hp <= 0) //Om player är död, har inget hp. Så går den ut ur loopen
                {
                    break;
                }
                else if(goblin.Hp <= 0 && wizard.Hp <= 0)  //Om goblin och wizard är döda går vi också ut ur loopen
                {
                    break;
                }

                Thread.Sleep(500);
            }   

            
            if(player.Hp <= 0)
            {
                TG.Slow("Du förlorade");
            }
            else
            {
                TG.Slow("Du vann!");
            }

            StreamWriter writer = new StreamWriter("Score.txt", true);

            writer.WriteLine(player.Hp);

            writer.Close();

            string data = File.ReadAllText("Score.txt");

            string[] lines = data.Split('\n');

            int[] values = new int[lines.Length];

            for(int i = 0; i < lines.Length; i++)
            {
                if(lines[i] != "") //Gör om string array till int array bara om den har något i sig och inte är tom.
                    values[i] = int.Parse(lines[i]);
            }

            Array.Sort(values);
            Array.Reverse(values);


            StreamWriter sw = new StreamWriter("Score.txt");

            for(int i = 0; i < values.Length; i++)
            {
                sw.WriteLine(values[i]);
            }

            sw.Close();

            Meny(); //Öppnar menyn igen.     
        }

    }
}