public class Player
{
    // Fields to store the health points (HP) and armor of the player
    private int hp;
    private int armor;

    // Constructor to initialize the player's HP to 100 and armor to 50
    public Player()
    {
        hp = 100;
        armor = 50;
    }

    // Property to get or set the HP value
    public int HP
    {
        get { return hp; }
        private set
        {
            // Ensure HP doesn't drop below 0
            if (value < 0)
                hp = 0;
            else
                hp = value;
        }
    }

    // Property to get or set the Armor value
    public int Armor
    {
        get { return armor; }
        private set
        {
            // Ensure Armor doesn't drop below 0
            if (value < 0)
                armor = 0;
            else
                armor = value;
        }
    }

    // Method to display the current status of the player
    public void DisplayStatus()
    {
        Console.WriteLine("Player HP: " + hp + ", Armor: " + armor);
    }

    // Method to take damage
    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            Console.WriteLine("Damage cannot be negative.");
            return;
        }

        if (armor > 0)
        {
            // Reduce damage by 1 when armor is present
            int effectiveDamage = damage - 1;

            // If effective damage exceeds current armor, reduce armor to 0 and subtract leftover damage from HP
            if (effectiveDamage > armor)
            {
                int leftoverDamage = effectiveDamage - armor;
                Armor = 0; // Armor is depleted
                HP -= leftoverDamage;
                Console.WriteLine($"Player's armor absorbed {armor} damage. {leftoverDamage} damage taken to HP.");
            }
            else
            {
                // If effective damage does not exceed armor, just reduce the armor
                Armor -= effectiveDamage;
                Console.WriteLine($"Player's armor absorbed {effectiveDamage} damage.");
            }
        }
        else
        {
            // If no armor is left, take the full damage to HP
            HP -= damage;
            Console.WriteLine($"Player took {damage} damage to HP.");
        }
    }

    // Method to heal the player
    public void Heal(int amount)
    {
        if (amount < 0)
        {
            Console.WriteLine("Heal amount cannot be negative.");
            return;
        }

        HP += amount;
        Console.WriteLine($"Player healed {amount} HP.");
    }

    // Method to repair armor
    public void RepairArmor(int amount)
    {
        if (amount < 0)
        {
            Console.WriteLine("Repair amount cannot be negative.");
            return;
        }

        Armor += amount;
        Console.WriteLine($"Player's armor repaired by {amount}.");
    }
}
