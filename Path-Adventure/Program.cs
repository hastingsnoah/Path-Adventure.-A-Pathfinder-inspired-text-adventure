using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
* 02/10/2022
* CSC 153
* Hastings, Noah
* This program is a simple text adventure with room and item tracking. Later iterations will contain a simple combat system based on pathfinder 2e mechanics, weapons, and enemies. 
*/

namespace Text_Adventure_1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int ROOMSIZE = 5;
            const int WEAPONSIZE = 4;
            const int POTIONSIZE = 2;
            const int TREASURESIZE = 3;
            //loop to break holder
            bool loop = true;

            string[] rooms = new string[ROOMSIZE] { "Inn Entrance", "Tavern room", "Barkeep's Office", "Storage Room", "Cellar" };
            string[] weapons = new string[WEAPONSIZE] { "Shortsword", "ShortBow", "Dagger", "QuarterStaff" };
            string[] potions = new string[POTIONSIZE] { "Lesser Healing Potion ", "BarkSkin Potion" };
            string[] treasures = new string[TREASURESIZE] { "50 GP", "+1 Shortsword", "100 GP" };

            List<String> mobs = new List<String>(5) { "Ruffian", "Tavern Security Guard", "Innkeeper", "Angered Orc", "Tavern Owner" };
            List<String> items = new List<String>(4) { "Crowbar", "Lockpicks", "Cellar Chest Key", "Barkeeper's left shoe" };
            //Player Stats
            int ac = 22;
            int hp = 82;
            string equiptWeapon = weapons[0];

            //Weapon stats

            //Mob Stats

            string userInput = "0";
            int currentRoom = 0;



            //Write intro story
            //Menu
            while (userInput != "7")
            {
                // Current Room output
                Console.WriteLine("You are currently in the " + rooms[currentRoom] + "\n---------------------------------------------");
                //Main menu
                Console.WriteLine("1. Display Rooms\n2. Display Weapon\n3. Display Potion" +
                    "\n4. Display Treasutre\n5. Display Items\n6. Display Mobs\n7. Exit\n" +
                    "---------------------------------------------\n" +
                    "What would you like to do? (Enter a number from 1-7 )");
                //User input
                userInput = Console.ReadLine();

                //Menu option 1
                if (userInput == "1")
                {
                    Array.Reverse(rooms);
                    Console.WriteLine("---------------------------------------------");
                    foreach (String room in rooms)
                    {
                        Console.WriteLine(room);
                    }
                    Console.WriteLine("\n ---------------------------------------------");
                    Console.WriteLine("You are currently in the " + rooms[currentRoom] +
                        "\n\nWould you like to move? (y/n)");
                    userInput = Console.ReadLine();
                    if (userInput == "y")
                    {
                        Console.WriteLine("Where would you like to move? (N or S)");
                        userInput = Console.ReadLine();
                        if (userInput == "N")
                        {
                            if (currentRoom == 4)
                            {
                                Console.WriteLine("You are unable to move and furthur in that direction.\n\n\n");
                            }
                            else
                            {
                                currentRoom++;
                                Console.WriteLine("You move into the " + rooms[currentRoom] + "\n\n\n");

                            }
                        }
                        else if (userInput == "S")
                        {
                            if (currentRoom == 0)
                            {
                                Console.WriteLine("You are unable to move any further in that direction.\n\n\n");
                            }
                            else
                            {
                                currentRoom--;
                                Console.WriteLine("You move into the " + rooms[currentRoom] + "\n\n\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("That was an invalid option. Please enter N or S\n\n\n");
                        }
                    }
                }

                //Menu Option 2
                else if (userInput == "2")
                {
                    Console.WriteLine("\n\n\n---------------------------------------------\nYou currently have the " + equiptWeapon + " equipped\nThese are your available weapons:");
                    Array.Sort(weapons);
                    foreach (string weapon in weapons)
                    {
                        Console.WriteLine(weapon);
                    }
                    Console.WriteLine("---------------------------------------------\n");
                    Console.WriteLine("Would you like to change weapons? (y/n)");
                    userInput = Console.ReadLine();
                    while (loop)
                    {


                        if (userInput == "y")
                        {
                            while (loop)
                            {
                                Console.WriteLine("What weapon would you like to switch to? (sword, bow, staff, dagger)");
                                userInput = Console.ReadLine();

                                if (userInput == "sword")
                                {
                                    Console.WriteLine("You dawn the shortsword and prepare to use it.\n---------------------------------------------");
                                    equiptWeapon = "ShortSword";
                                    break;
                                }
                                else if (userInput == "bow")
                                {
                                    Console.WriteLine("You draw the string, ready to loose an arrow at your foes.\n\nYou equip the bow.\n---------------------------------------------");
                                    equiptWeapon = "ShortBow";
                                    break;
                                }
                                else if (userInput == "staff")
                                {
                                    Console.WriteLine("Sometimes some people just need a lesson beat into them.\n\nYou equip the quarter staff.\n---------------------------------------------");
                                    equiptWeapon = "QuarterStaff";
                                    break;
                                }
                                else if (userInput == "dagger")
                                {
                                    Console.WriteLine("A blade as fine as any with the mobility to make precise cuts.\n\nYou equip the dagger.\n---------------------------------------------");
                                    equiptWeapon = "Dagger";
                                    break;

                                }
                                else
                                {
                                    Console.WriteLine("---------------------------------------------\nInvalid selection. Please enter sword, dagger, bow, or staff.\n---------------------------------------------");
                                }
                                break;

                            }
                        }
                        else if (userInput == "n")
                        {
                            Console.WriteLine("You keep the " + equiptWeapon + " in your hand.\n---------------------------------------------\n\n\n");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That is an invalid selection. Please enter y or n");
                        }
                        break;
                    }

                }

                //Menu Option 3
                else if (userInput == "3")
                {
                    foreach (String potion in potions)
                    {
                        Console.WriteLine(potion);
                    }
                }
                //Menu option 4
                else if (userInput == "4")
                {
                    foreach (String treasure in treasures)
                    {
                        Console.WriteLine(treasure);
                    }
                }
                //Menu option 5
                else if (userInput == "5")
                {
                    foreach (String item in items)
                    {
                        Console.WriteLine(item);
                    }
                }
                //Menu option 6
                else if (userInput == "6")
                {
                    foreach (String mob in mobs)
                    {
                        Console.WriteLine(mob);
                    }
                }

                //Menu option 7
                else if (userInput == "7")
                {
                    Console.WriteLine("Are you sure you want to quit? Your progress will be lost. (y/n)");
                    while (userInput != "y")
                    {
                        userInput = Console.ReadLine();
                        if (userInput == "y")
                        {
                            Console.WriteLine("Okay, ending program. Thanks for playing!");
                            userInput = "7";
                            break;
                        }
                        else if (userInput == "n")
                        {
                            Console.WriteLine("---------------------------------------------\n" +
                                "Good choice! There's still loot to be found!" +
                                "\n---------------------------------------------\n\n\n");
                            break;
                        }
                        else { Console.WriteLine("Invalid input. Please enter y or n"); }
                    }
                }

                //Invalid option
                else
                {
                    Console.WriteLine("---------------------------------------------\n" +
                        "Invalid Selection. Please enter a number from " +
                 "1 - 7\n" +
                 "---------------------------------------------");
                }
            }


        }
    }
}
