public class Enemy
{
    // Field to store the health points (HP) of the enemy
    private int hp;

    // Constructor to initialize the enemy's HP to 100
    public Enemy()
    {
        hp = 100;
    }

    // Property to get or set the HP value
    public int HP
    {
        get { return hp; }
        set
        {
            // Ensure HP doesn't drop below 0
            if (value < 0)
                hp = 0;
            else
                hp = value;
        }
    }

    // Method to display the current HP of the enemy
    public void DisplayStatus()
    {
        Console.WriteLine("Enemy HP: " + hp);
    }

    // Method to take damage
    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            Console.WriteLine("Damage cannot be negative.");
            return;
        }

        HP -= damage;
        Console.WriteLine($"Enemy took {damage} damage.");
    }

    // Method to heal the enemy
    public void Heal(int amount)
    {
        if (amount < 0)
        {
            Console.WriteLine("Heal amount cannot be negative.");
            return;
        }

        HP += amount;
        Console.WriteLine($"Enemy healed {amount} HP.");
    }
}
