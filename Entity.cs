namespace OOP_Prov
{
    public class Entity
    {
        public int hp;
        public string name;
        public int damage;

        public int Hp
        {
            get{return hp;}
            set{hp = value;}
        }

        public string Name
        {
            get{return name;}
            set{name = value;}
        }

        public int Damage
        {
            get{return damage;}
            set{damage = value;}
        }

        public Entity(int hp, string name, int damage)
        {
            this.Hp = hp;
            this.Name = name;
            this.Damage = damage;
        }

        public bool Attack()
        {
            Console.WriteLine(name + " attacks!\n");
            return true;
            
        }

        public void TakeDamage(int amount)
        {
            hp -= amount;
            Console.WriteLine($"{name} HP: {hp}\n");
        }

    }
}