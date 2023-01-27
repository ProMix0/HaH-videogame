using Videogame.Model;
using Range = Videogame.Model.Range;

Player player=CreatePlayer();

List<Monster> monsters = new();
Console.WriteLine("Enter number of monsters:");
for (int i = int.Parse(Console.ReadLine()); i > 0; i--)
{
    monsters.Add(CreateMonster());
}

while (monsters.Count > 0)
{
    PrintPlayer(player);
    Console.WriteLine();
    foreach (var monster in monsters)
    {
        PrintMonster(monster);
    }

    char action;
    do
    {
        Console.WriteLine("Choose your action:");
        Console.WriteLine("\t1 - attack");
        Console.WriteLine(player.CanHeal() ? "\t2 - heal" : "\tHealing unavailable");
        action = Console.ReadKey().KeyChar;
        Console.Write('\b');
    } while (action != '1' && (action != '2' || !player.CanHeal()));

    if (action == '1')
    {
        Monster monster = monsters.First();
        int damage = player.Attack(monster);
        Console.WriteLine($"{damage} damage dealt by player");
        if (monster.Health == 0)
        {
            Console.WriteLine("Monster dead");
            monsters.Remove(monster);
        }
    }
    else
    {
        player.Heal();
        Console.WriteLine($"New health: {player.Health}");
    }

    foreach (var monster in monsters)
    {
        int damage = monster.Attack(player);
        Console.WriteLine($"{damage} damage dealt by monster");
        if (player.Health == 0)
        {
            Console.WriteLine("Player dead");
            return;
        }
    }
}

Console.WriteLine("You win!");

Player CreatePlayer()
{
    Console.WriteLine("Enter player damage:");
    int damage = int.Parse(Console.ReadLine());
    
    Console.WriteLine("Enter player damage range (in one line, space-separated):");
    int[] damageArr = Console.ReadLine().Split().Select(int.Parse).Take(2).ToArray();
    Range damageRange = new Range(damageArr[0], damageArr[1]);
    
    Console.WriteLine("Enter player defence:");
    int defence = int.Parse(Console.ReadLine());
    
    Console.WriteLine("Enter player max health:");
    int maxHealth = int.Parse(Console.ReadLine());

    return new Player(damage, damageRange, defence, maxHealth);
}

Monster CreateMonster()
{
    Console.WriteLine("Enter monster damage:");
    int damage = int.Parse(Console.ReadLine());
    
    Console.WriteLine("Enter monster damage range (in one line, space-separated):");
    int[] damageArr = Console.ReadLine().Split().Select(int.Parse).Take(2).ToArray();
    Range damageRange = new Range(damageArr[0], damageArr[1]);
    
    Console.WriteLine("Enter monster defence:");
    int defence = int.Parse(Console.ReadLine());
    
    Console.WriteLine("Enter monster max health:");
    int maxHealth = int.Parse(Console.ReadLine());

    return new Monster(damage, damageRange, defence, maxHealth);
}

void PrintPlayer(Player player)
{
    Console.WriteLine($"\t@ {player.Health}/{player.MaxHealth}\t{player.HealthFlacks} health flacks");
    Console.WriteLine(
        $"\tDamage: {player.Damage}, damage range: {player.DamageRange.From}-{player.DamageRange.To}, defence: {player.Defence}");
}
void PrintMonster(Monster monster)
{
    Console.WriteLine($"\t# {monster.Health}/{monster.MaxHealth}");
    Console.WriteLine(
        $"\tDamage: {monster.Damage}, damage range: {monster.DamageRange.From}-{monster.DamageRange.To}, defence: {monster.Defence}");
}
