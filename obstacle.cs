public class Obstacle
{
    // Field to store the health points (HP) of the obstacle
    private int hp;

    // Constructor to initialize the obstacle's HP to 25
    public Obstacle()
    {
        hp = 25;
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

    // Method to display the current HP of the obstacle
    public void DisplayStatus()
    {
        Console.WriteLine("Obstacle HP: " + hp);
    }

    // Method to take damage
    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            Console.WriteLine("Damage cannot be negative.");
            return;
        }

        // Reduce HP by the damage amount
        HP -= damage;
        Console.WriteLine($"Obstacle took {damage} damage.");
    }
}
