namespace Videogame.Model;

public class Monster:Entity
{
    public Monster(int damage, Range damageRange, int defence, int maxHealth) : base(damage, damageRange, defence, maxHealth)
    {
    }
}