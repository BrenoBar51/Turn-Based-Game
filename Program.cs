public class CombatGame{
  public static void Main(string[] args){
    RunGame();
  }

  public static void RunGame(){
    int heroHealth = 10, monsterHealth = 10, defenseReduction = 2, healLimit = 2;
    Random dice = new();

    while (heroHealth > 0 && monsterHealth > 0){
      DisplayHealth(heroHealth, monsterHealth);
      string choice = GetPlayerChoice();

      switch (choice){
        case "1":
          int damageDealt = dice.Next(1, 6);
          monsterHealth -= damageDealt;
          Console.WriteLine($"You attacked and dealt {damageDealt} damage to the monster.");
          break;
        case "2":
          Console.WriteLine("You braced yourself for the monster's attack.");
          break;
        case "3":
          int healAmount = HealHero(healLimit);
          if (healAmount > 0){
            heroHealth += healAmount;
            Console.WriteLine($"You healed {healAmount} health.");
          }
          break;
        default:
          Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
          break;
      }

      if (heroHealth > 0 && monsterHealth > 0){
        int monsterDamage = dice.Next(1, 5);
        monsterDamage -= defenseReduction; // Apply defense
        monsterDamage = Math.Max(monsterDamage, 0);  // Prevent negative damage
        heroHealth -= monsterDamage;
        Console.WriteLine($"The monster attacked and caused {monsterDamage} damage.");
      }
    }

    Console.WriteLine(heroHealth > monsterHealth ? "You win!" : "The monster defeats you!");
  }

  public static string GetPlayerChoice(){
    Console.WriteLine("\nWhat do you want to do?");
    Console.WriteLine("1. Attack");
    Console.WriteLine("2. Defend");
    Console.WriteLine("3. Heal");
    return Console.ReadLine();
  }

  public static int HealHero(int healLimit){
    Random dice = new();
    if (healLimit >= 0){
      int healPotion = dice.Next(2, 4);
      healLimit--;
      return healPotion;
    }else{
      Console.WriteLine("You don't have any heal potions");
      return 0;
    }
  }
  public static void DisplayHealth(int heroHealth, int monsterHealth){
    Console.WriteLine($"Hero Health: {heroHealth}");
    Console.WriteLine($"Monster Health: {monsterHealth}");
  }
}