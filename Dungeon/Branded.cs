using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
using MonsterLibrary;



namespace Dungeon
{
    class Branded
    {
        static void Main(string[] args)
        {
            Console.Title = "Branded";
            Console.Write("Please Enter Your Name: ");
            string playerName = Console.ReadLine();

            int score = 0;

            Weapon shortsword = new Weapon(1, 8, "Short Sword", 10, true);
            
            Player player = new Player(playerName, 65, 45, 50, 50, shortsword);

            Console.Clear();
            Console.WriteLine("Castle Prolymeus. A long since abandoned underground castle, nestled in a large cave system.\nRumors and local stories say that once a great and powerful king held power over this land from that castle. " +
                "\nBut, without warning the castle grew dark and the kingdom fell into ruin. You however yearn for the answers.\nA kingdom doesn't just disapear over night and surely there is some treasure to be had?");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("I've finally come upon the castle, a large road made of stone stretches from the mouth of this cave up to the castles\nmain entrance.\nOn either side there is water leading all the way to the walls of the " +
                "cave. The castle is large with a flat rounded top, a spiral staircase leads up this castles spire.\nIt's too dark to make out finer details but you can FEEL this castles magnificence from where you stand.");
            Console.ReadKey();
            Console.WriteLine("........");
            Console.WriteLine("Better get moving, the air feels like its getting colder..... Must be the water.");
            Console.ReadKey();
            Console.WriteLine("I've made it inside of the castle, the entrance is grand and well decorated. There is no sign of a single soul having\nbeen here in ages.\nI begin to take a few steps forward and suddenly a voice appears, it " +
                "consumes my thoughts, it's not a voice you can hear but it's a voice that is felt");
            Console.WriteLine("Branded one..... You return to this cursed castle seeking what? Treasure? Glory?...... Or maybe something more?");
            Console.ReadKey();
            Console.WriteLine("It's a womans voice, so soft a delicate, but it almost has a haunting feel to it. I try to call out to answer her\nbut the words can't escape.\nI can't move a muscle almost as if I was chained to my surroundings.");
            Console.ReadKey();
            Console.WriteLine("Ascend the castle. Go to the very top of the spire and you will find whatever it is that you seek. But be weary Branded one, you might not like what you find within this castle.");
            Console.ReadKey();
            Console.WriteLine("My muscles feel released. The voice is gone but now the air is even cooler than it was before.\nWho was that woman? Guess there is only one way to find out.");
            Console.ReadKey();
            Console.WriteLine("I guess I'll start by exploring this first floor and then making my way up.");
            Console.ReadKey();
            Console.Clear();



            bool exit = false;

            do
            {
                Console.WriteLine(GetRoom());

                Monster slime = new Monster("Slime", 10, 10, 30, 15, 1, 5, "A small glob of ooze");

                Monster rabbit = new Monster("White Rabbit", 12, 12, 40, 20, 2, 8, "A small hare, although it does have a certain look to it.....");
   
                Monster[] monsters = { slime, slime, slime, rabbit, rabbit};

                Random rand = new Random();

                int randomNbr = rand.Next(monsters.Length);

                Monster monster = monsters[randomNbr];

                Console.WriteLine("\nIn this room you encounter a " + monster.Name);

                bool reload = false;

                do
                {

                    #region MENU

                    Console.Write("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "C) Character Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n");
                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                    Console.Clear();


                    switch (userChoice)
                    {

                        case ConsoleKey.A:

                            Combat.DoBattle(player, monster);

                            if (monster.Life <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}!\n", monster.Name);
                                Console.ResetColor();
                                reload = true;
                                score++;
                            }
                            break;

                        

                        case ConsoleKey.R:

                            Console.WriteLine("Run away!");

                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, player);
                            Console.WriteLine();
                            reload = true;

                            break;

                        case ConsoleKey.C:

                            Console.WriteLine("Player Info");

                            Console.WriteLine(player);
                            Console.WriteLine("Monsters defeated: " + score);

                            break;

                        case ConsoleKey.M:

                            Console.WriteLine("Monster Info");
                            Console.WriteLine(monster);

                            break;



                        case ConsoleKey.X:
                        case ConsoleKey.E:

                            Console.WriteLine("Thanks for playing!");

                            exit = true;

                            break;

                        default:

                            Console.WriteLine("That isn't in the options list.");

                            break;
                    }


                    #endregion

                    if (player.Life <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("YOU ARE DEAD");
                        Console.WriteLine("You defeated " + score + " monster" + ((score == 1) ? "." : "s."));
                        Console.WriteLine("The curse will continue......");
                        Console.ResetColor();
                        exit = true;
                    }

                } while (!reload && !exit);




            } while (!exit && score < 10); 

            Console.WriteLine("You have reached the second floor of the castle, you feel more comfortable fighting monsters now\nand your strength seems to have grown.");
            Weapon greatsword = new Weapon(10, 25, "Dragon Slayer", 15, true);
            Console.ReadKey();
            Console.WriteLine("There's supposed to be a total of four floors in this castle and the staircase leading up the spire is on the third floor.");
            Console.WriteLine("You see what appears to be an armory down the hall a bit, I'm sure no one would miss it if you took a better weapon for yourself");
            Console.ReadKey();
            Console.WriteLine("The armory is almost entirely empty..... Except for a large great sword leaning up against the wall.\nNo it's much too large to be called a sword it's more like a large hunk of iron. You go to pick up the great sword and the weight of this blade seems almost familiar.\nYou've never wielded a blade like this before however.");
            Console.ReadKey();
            Console.WriteLine("I'm sure no one would mind if I borrowed this.");
            Player player2 = new Player(playerName, 65, 55, 70, 70, greatsword);
            Console.Clear();
            Console.WriteLine("Upon exiting the room you see several monsters in the hallway, guess you'll be fighting your way up to that third floor.");
            Console.ReadKey();
            Console.Clear();

            do
            {
                Console.WriteLine(GetRoom());

                Monster ghast = new Monster("Ghast", 20, 25, 45, 25, 8, 15, "A ghostly figure, not sure how you can even make contact with it.");

                Monster knighthusk = new Monster("Knight Husk", 25, 28, 50, 25, 12, 18, "What appears to be an empty suit of armor weilding a long sword and a kite shield");

                Monster[] monsters = { ghast, ghast, ghast, ghast, knighthusk };

                Random rand = new Random();

                int randomNbr = rand.Next(monsters.Length);

                Monster monster = monsters[randomNbr];

                Console.WriteLine("\nIn this room you encounter a " + monster.Name);

                bool reload = false;

                do
                {

                    #region MENU

                    Console.Write("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "C) Character Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n");
                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                    Console.Clear();


                    switch (userChoice)
                    {

                        case ConsoleKey.A:

                            Combat.DoBattle(player2, monster);

                            if (monster.Life <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}!\n", monster.Name);
                                Console.ResetColor();
                                reload = true;
                                score++;
                            }
                            break;

                        case ConsoleKey.R:

                            Console.WriteLine("Run away!");

                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, player2);
                            Console.WriteLine();
                            reload = true;

                            break;

                        case ConsoleKey.C:

                            Console.WriteLine("Player Info");

                            Console.WriteLine(player2);
                            Console.WriteLine("Monsters defeated: " + score);

                            break;

                        case ConsoleKey.M:

                            Console.WriteLine("Monster Info");
                            Console.WriteLine(monster);

                            break;

                        case ConsoleKey.X:
                        case ConsoleKey.E:

                            Console.WriteLine("Thanks for playing!");
                            Console.WriteLine("You defeated " + score + " monster" + ((score == 1) ? "." : "s."));
                            Console.WriteLine("The curse will continue......");
                            exit = true;

                            break;

                        default:

                            Console.WriteLine("That isn't in the options list.");

                            break;
                    }


                    #endregion

                    if (player.Life <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("YOU ARE DEAD");
                        Console.WriteLine("You defeated " + score + " monster" + ((score == 1) ? "." : "s."));
                        Console.WriteLine("The curse will continue......");
                        Console.ResetColor();
                        exit = true;
                    }

                } while (!reload && !exit);




            } while (!exit && score < 17);

            Console.Clear();

            Player player3 = new Player(playerName, 80, 75, 80, 80, greatsword);

            Console.WriteLine("I've made my way to the third floor, I no longer fear the monsters or what comes next in the castle.");
            Console.ReadKey();
            Console.WriteLine("The floor above is just supposed to be storage, so I think I'll head towards the spire.");
            Console.WriteLine("....... I can't move again");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You have done well to make it this far Branded one.....\nyou have one final task to complete before you can find the answers you seek......");
            Console.ReadKey();
            Console.WriteLine("Tell me Branded one, where did you come from before coming to this castle?");
            Console.ReadKey();
            Console.WriteLine("What does she mean? I came from...... Where did I come from? Why am I here?\nMy memory is so hazy, all I knew of was this castles story. How can there be nothing before this?");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Your journey has led to more questions than answers so far, I believe if you're able to pass the final test everything will be clear for you");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("What does she mean final test? Have these monsters in this castle all been some sort of test for me? Is that why I'm 'Branded'");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Your final test is to face me Branded one. I am all that stands in the way for your answers.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("The castle begins to shake and down from the spire comes a tall figure completely cloaked in black..... That is no human woman.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("As she approaches you see what was once probably skin is now a dark black substance that appears to be moving. It almost looks like pure darkness.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Ready your blade Branded one, just know that I don't want to do this. I love you.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("No time to decipher that, she rushes at you!");
            Console.ReadKey();
            Console.Clear();

            do
            {
                
                Monster curseoftheking = new Monster("Kings Curse", 90, 90, 65, 30, 15, 30, "The woman who has been guiding you on your quest.... Was she the queen? or did she take over the queens body?");

                Monster[] monsters = { curseoftheking };

                Random rand = new Random();

                int randomNbr = rand.Next(monsters.Length);

                Monster monster = monsters[randomNbr];

                Console.WriteLine("\nThe " + monster.Name + " draws near.");

                bool reload = false;

                

                do
                {

                    #region MENU

                    Console.Write("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "C) Character Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n");
                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                    Console.Clear();


                    switch (userChoice)
                    {

                        case ConsoleKey.A:

                            Combat.DoBattle(player3, monster);

                            if (monster.Life <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}!\n", monster.Name);
                                Console.ResetColor();
                                score++;
                                Console.Clear();

                                Console.WriteLine("I do not blame you Branded one, you've passed the test and now you can find your truth.");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("Our love is eternal");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("You experience and extreme pain in your head.... Why does she say that she loves you? Was she the queen of this castle?");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("Only one way to find out");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("You make your way all the way up the spire, you clear the steps and the moonlight shines through a hole in the top of the cave. ");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine(".......");
                                Console.WriteLine("What is this...... Surely this hast to be a trick");
                                Console.WriteLine("The pain in your head grows stronger, your body warming up internally");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("You are faced with a stone statue.... Chained to the top of the spire bathed in moonlight, the statue looks just like you.");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("That statue has a crown on top of it head, but you can't shake the fact that the statue is the spitting image of you.");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("You cannot shake the urge to reach for the crown... It's almost like it is drawing you in closer.");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("You reach for the crown and slowly go to place it on your head, as the crown touches your head the moonlight grows even brighter. The statue begins to crumble and the castle shakes.");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("The pain in your head is gone and the memories begin to flood your mind. It's too much, it feels like your head is about to explode.");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("Everything stops. Everything is clear. This is your castle, YOU were the king. Once you were offered complete power in the form of the flames of creation and in your arrogance you accepted the flame not knowing what would follow.");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("Once you accepted the flame from the wanderer your kingdom fell to ruin, you were turned to stone and all your subjects to monsters. The flame cursed you to relive this night over and over. An endless " +
                                    "quest for answers you already know, and answers to a problem that you yourself caused.");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("The chains animate, and being to latch onto your limbs and body.");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("You know it's useless to fight back, and you are aware of what comes next. Everything starts to leave you again, memories from before and the memories from this adventure.");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("The curse of the Branded King..... A tale never to be told. Is there a cure for this curse?");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("Then it was dark, almost as if everything returned to nothing.");
                                Console.ReadKey();
                                Console.Clear();
                                Console.Write("Press any key to continue.");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("Castle Prolymeus. A long since abandoned underground castle, nestled in a large cave system. Rumors and local stories say that once a great and powerful king held power over this land from that castle. " +
                                    "But, without warning the castle grew dark and the kingdom fell into ruin. You however yearn for the answers. A kingdom doesn't just disapear over night and surely there is some treasure to be had?");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("I've finally come upon the castle, a large road made of stone stretches from the mouth of this cave up to the castles main entrance. On either side there is water leading all the way to the walls of the " +
                                    "cave. The castle is large with a flat rounded top, a spiral staircase leads up this castles spire. It's too dark to make out finer details but you can FEEL this castles magnificence from where you stand............");
                                Console.ReadKey();
                                Console.Clear();
                                exit = true;
                                reload = false;

                            }
                            break;

                        case ConsoleKey.R:

                            Console.WriteLine("Run away!");

                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, player3);
                            Console.WriteLine();
                            reload = true;

                            break;

                        case ConsoleKey.C:

                            Console.WriteLine("Player Info");

                            Console.WriteLine(player3);
                            Console.WriteLine("Monsters defeated: " + score);

                            break;

                        case ConsoleKey.M:

                            Console.WriteLine("Monster Info");
                            Console.WriteLine(monster);

                            break;

                        case ConsoleKey.X:
                        case ConsoleKey.E:

                            Console.WriteLine("Thanks for playing!");
                            Console.WriteLine("You defeated " + score + " monster" + ((score == 1) ? "." : "s."));
                            Console.WriteLine("The curse will continue......");
                            exit = true;

                            break;

                        default:

                            Console.WriteLine("That isn't in the options list.");

                            break;
                    }


                    #endregion

                    if (player.Life <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("YOU ARE DEAD");
                        Console.WriteLine("You defeated " + score + " monster" + ((score == 1) ? "." : "s."));
                        Console.WriteLine("The curse will continue......");
                        Console.ResetColor();
                        exit = true;
                    }

                } while (!exit);




            } while (!exit);

            Console.Clear();

            Console.WriteLine("I do not blame you Branded one, you've passed the test and now you can find your truth.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Our love is eternal");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You experience and extreme pain in your head.... Why does she say that she loves you? Was she the queen of this castle?");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Only one way to find out");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You make your way all the way up the spire, you clear the steps and the moonlight shines through a hole in the top of the cave. ");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(".......");
            Console.WriteLine("What is this...... Surely this hast to be a trick");
            Console.WriteLine("The pain in your head grows stronger, your body warming up internally");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You are faced with a stone statue.... Chained to the top of the spire bathed in moonlight, the statue looks just like you.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("That statue has a crown on top of it head, but you can't shake the fact that the statue is the spitting image of you.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You cannot shake the urge to reach for the crown... It's almost like it is drawing you in closer.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You reach for the crown and slowly go to place it on your head, as the crown touches your head the moonlight grows even brighter. \nThe statue begins to crumble and the castle shakes.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("The pain in your head is gone and the memories begin to flood your mind. It's too much, it feels like your head is about to explode.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Everything stops. Everything is clear. This is your castle, YOU were the king. \nOnce you were offered complete power in the form of the flames of creation and in your arrogance you accepted the flame not knowing what would follow.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Once you accepted the flame from the wanderer your kingdom fell to ruin, you were turned to stone and all your subjects to monsters. \nThe flame cursed you to relive this night over and over. An endless " +
                "quest for answers you already know, and answers to a problem that you yourself caused.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("The chains animate, and being to latch onto your limbs and body.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You know it's useless to fight back, and you are aware of what comes next. Everything starts to leave you again, memories from before and the memories from this adventure.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("The curse of the Branded King..... A tale never to be told. Is there a cure for this curse?");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Then it was dark, almost as if everything returned to nothing.");
            Console.ReadKey();
            Console.Clear();
            Console.Write("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Castle Prolymeus. A long since abandoned underground castle, nestled in a large cave system. \nRumors and local stories say that once a great and powerful king held power over this land from that castle. " +
                "But, without warning the castle grew dark and the kingdom fell into ruin. You however yearn for the answers. \nA kingdom doesn't just disapear over night and surely there is some treasure to be had?");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("I've finally come upon the castle, a large road made of stone stretches from the mouth of this cave up to the castles main entrance. \nOn either side there is water leading all the way to the walls of the " +
                "cave. \nThe castle is large with a flat rounded top, a spiral staircase leads up this castles spire. \nIt's too dark to make out finer details but you can FEEL this castles magnificence from where you stand............");
            Console.ReadKey();
            Console.Clear();


            Console.WriteLine("You defeated " + score + " monster" + ((score == 1) ? "." : "s."));
            Console.WriteLine("The curse will continue......");

        }//end main

        private static string GetRoom()
        {
            string[] rooms =
            {
                "This room seems to be mostly for decoration",
                "This clearly was a womans makeup room at one point",
                "This room was a storage room",
                "You enter a library, books scattered all around.",
                "An ornate dining room, there is nothing but dust on the tables.",
                "Slaves quarters...... Blood stains the walls.",
                "You take a look around... This room is empty.",
                "You enter what appears to be a war room. Ornate swords hang from the wall."
            };

            Random rand = new Random();

            int indexNbr = rand.Next(rooms.Length);

            string room = rooms[indexNbr];

            return room;

        }













    }
    }
    
        

