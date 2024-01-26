class Combat
{
    public int Attack()
    {
        // Generate random damage between 1 and 10
        Random random = new Random();
        int damage = random.Next(1, 11);

        return damage;
    }
    public int Defend()
    {
        // Generate random defense bonus between 1 and 5
        Random random = new Random();
        int defenseBonus = random.Next(1, 6);

        return defenseBonus;
    }
   
}