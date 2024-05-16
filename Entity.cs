namespace OOP_Prov
{
    public class Entity
    {
        private int hp;
        private string name;
        private int damage;

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
            Hp = hp;
            Name = name;
            Damage = damage;
        }

        public bool Attack()
        {
            TG.Normal(name + " attacks!\n");
            return true;
        }

        public void TakeDamage(int amount)
        {
            hp -= amount;
            hp = (int)MathF.Max(hp, 0);
            TG.Normal($"{name} HP: {hp}\n");
        }

    }
}