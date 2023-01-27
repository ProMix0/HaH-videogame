namespace Videogame.Model;

public class Player:Entity
{
    public int HealthFlacks { get; private set; } = 3;
    
    public Player(int damage, Range damageRange, int defence, int maxHealth) : base(damage, damageRange, defence, maxHealth)
    {
    }

    public bool CanHeal() => HealthFlacks > 0;

    public bool Heal()
    {
        if (CanHeal())
        {
            Health += MaxHealth / 2;
            HealthFlacks--;
            return true;
        }

        return false;
    }
}