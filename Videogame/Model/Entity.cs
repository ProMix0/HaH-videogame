namespace Videogame.Model;

public abstract class Entity
{
    Random rand = new();
    
    protected int damage;
    public int Damage
    {
        get => damage;
        protected set
        {
            if (value is > 20 or <= 0)
                throw new ArgumentOutOfRangeException(nameof(Damage), value, "Damage must be in range 1..20");

            damage = value;
        }
    }
    
    public Range DamageRange { get; }

    protected int defence;
    public int Defence
    {
        get => defence;
        protected set
        {
            if (value is > 20 or <= 0)
                throw new ArgumentOutOfRangeException(nameof(Damage), value, "Defence must be in range 1..20");

            defence = value;
        }
    }

    protected int health;

    public int Health
    {
        get => health;
        protected set => health = value < 0 ? 0 : value;
    }
    
    public int MaxHealth { get; }

    public Entity(int damage, Range damageRange, int defence, int maxHealth)
    {
        Damage = damage;
        DamageRange = damageRange;
        Defence = defence;
        Health = MaxHealth = maxHealth;
    }

    public int Attack(Entity enemy)
    {
        if (enemy is null)
            throw new ArgumentNullException(nameof(enemy));
        
        int modifier = Damage - enemy.Defence + 1;
        if (modifier < 1) modifier = 1;

        bool success = false;
        for(int i=0;i<modifier;i++)
            if (rand.Next(3) == 0)
            {
                success = true;
                break;
            }

        if (success)
        {
            int damage = rand.Next(DamageRange.From, DamageRange.To + 1);
            enemy.Health -= damage;
            return damage;
        }

        return 0;
    }

}