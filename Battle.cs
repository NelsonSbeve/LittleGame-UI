class Battle
{
    public Caracter Player { get; set; }
    public Caracter Opponent { get; set; }

    public Battle(Caracter player, Caracter opponent)
    {
        Player = player;
        Opponent = opponent;
    }
     void SlowPrint(string msg, int delay) {
	    foreach (char c in msg.ToCharArray()) {
		        Console.Write(c);
		        Thread.Sleep(delay);
            }
	        Console.WriteLine();
        }

    public void Start()
    {   
        //Console.Clear();
        Console.SetCursorPosition(0, 0);
        while (Player.IsAlive() && Opponent.IsAlive()){

        Console.SetCursorPosition(0, 0);
        Console.Write($"Player HP: {Player.health} | Opponent HP: {Opponent.health} \n");
        

    // Get player's choice (attack or defend)
    SlowPrint("Choose an action: (A)ttack or (D)efend", 20);
    ConsoleKeyInfo keyInfo = Console.ReadKey();
    string choice = keyInfo.KeyChar.ToString();
    Console.WriteLine("\n");
    Combat combat = new Combat();
    int damage;

    // Perform player's action
    if (choice == "A" || choice == "a")
    {
        // Player attacks opponent
        damage = combat.Attack();
        Opponent.health -= damage;
        SlowPrint($"Player attacks opponent for {damage} damage.", 30);
    }
    else if (choice == "D" || choice == "d")
    {
        // Player defends against opponent's attack
        int defend = combat.Defend();
        Player.health += defend; 
        SlowPrint($"Player defends against opponent's attack and gained {defend} HP now having: "+  Player.health,30);
    }
    else
    {
        // Invalid choice
        SlowPrint("Invalid choice. Please choose 'A' for attack or 'D' for defend.", 50);
        Console.SetCursorPosition(0, 1);
        for (int i = 1; i < Console.WindowHeight; i++)
        {
            Console.Write(new string(' ', Console.WindowWidth - 1));
        }

        // Move the cursor back to the first row
        Console.SetCursorPosition(0, 1);
        continue;
    }

    // Check if opponent is still alive
    if (Opponent.health <= 0)
    {
        Console.WriteLine("Player wins!");
        break;
    }

    // Generate random action for opponent (attack or defend)
    Random random = new Random();
    int opponentChoice = random.Next(1, 3);

    // Perform opponent's action
    if (opponentChoice == 1)
    {
        // Opponent attacks player
        damage = combat.Attack();
        Player.health -= damage;
        SlowPrint($"Opponent attacks player for {damage} damage.", 30);
    }
    else if (opponentChoice == 2)
    {
        int defend = combat.Defend();
        Opponent.health += defend; 
        SlowPrint($"Opponent defends against player's attack and gained {defend} health now having "+ Opponent.health,30);
    }

    // Check if player is still alive
    if (Player.health <= 0)
    {
        Console.WriteLine("Opponent wins!");
        break;
    }
    SlowPrint("Press any key for next round", 50);
    Console.ReadKey(true);
    Console.SetCursorPosition(0, 1);
        for (int i = 1; i < Console.WindowHeight; i++)
        {
            Console.Write(new string(' ', Console.WindowWidth - 1));
        }

        // Move the cursor back to the first row
        Console.SetCursorPosition(0, 1);
}
    }
}