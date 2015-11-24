using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongGenerator
{
    class Verse
    {
        string text;

        public Verse(string theText)
        {
            text = theText;
        }

        void NewLine()
        {
            Console.WriteLine();
        }

        public void Print()
        {
            Console.WriteLine(text);
        }

        /*

        void Chorus(string drink)
        {
            //Chorus
            Console.WriteLine("Musha ring dum a do dum a da.\n" +
                                "Whack for my daddy-o, \n" +
                                "Whack for my daddy-o \n" +
                                "There's " + drink + " in the jar-o");
            NewLine();
        }

        void Verse1(string who)
        {
            Console.WriteLine("As I was going' over the Cork and Kerry mountains\n" +
                                "I saw " + who + " and his money he was counting\n" +
                                "I first produced my pistol and I then produced my rapier\n" +
                                "I said stand or deliver or the devil he may take ya\n");
            NewLine();
        }

        void Verse2(string betterHalf)
        {
            Console.WriteLine("I took all of his money and it was a pretty penny.\n" +
                                "I took all of his money and I brought it home to " + betterHalf + "\n" +
                                "She swore that she loved me never would she leave me\n" +
                                "But the devil take that woman for you know she tricked me easy");
            NewLine();
        }

        void Verse3(string betterHalf)
        {
            Console.WriteLine("Being drunk and weary I went to " + betterHalf + "'s chamber takin' my " + betterHalf + " with me\n" +
                                "And I never knew the danger for about six or maybe seven, in walked Captain Farrell.\n" +
                                "I jumped up, fired off my pistols and I shot him with both barrels.");
            NewLine();
        }

        void Verse4(string betterHalf)
        {
            Console.WriteLine("Now some men like the fishin' and some men like the fowlin',\n" +
                                "And some men like ta hear, the cannon ball a roarin'.\n" +
                                "Me? I like sleepin' especially in my " + betterHalf + "'s chamber.\n" +
                                "But here I am in prison, here I am with ball and chain, yeah.");
            NewLine();
        }

        void playSong(string drink, string antagonist, string betterHalf)
        {
            Console.WriteLine("*******************");
            Console.WriteLine(drink + " IN THE JAR");
            Console.WriteLine("*******************");

            Verse1(antagonist);
            Chorus(drink);
            Verse2(betterHalf);
            Chorus(drink);
            Verse3(betterHalf);
            Chorus(drink);
            Verse4(betterHalf);
            Chorus(drink);
        }

        String GetUserInput(String prompt)
        {
            String userInput;
            do
            {
                Console.WriteLine(prompt);
                userInput = Console.ReadLine();
                if (userInput.Length == 0)
                {
                    Console.WriteLine("You must fill in something.");
                }
            }
            while (userInput.Length == 0);
            return userInput;
        }

        int GetNumber(String prompt)
        {
            int userInputValue;
            do
            {
                String userInput = GetUserInput(prompt);
                userInputValue = int.Parse(userInput);
                if (userInputValue <= 0)
                {
                    Console.WriteLine("Your input is wrong.  It was " + userInputValue + " but must be greater than zero.");
                }
            }
            while (userInputValue <= 0);
            return userInputValue;
        }

        Song()
        {
            GetUserInput("Fish: ");
            String antagonist = GetUserInput("Please enter the antagonist: ");
            String drink = GetUserInput("Please enter the drink: ");
            String missus = GetUserInput("Please enter the protagonist's significant other: ");

            int plays = GetNumber("How many times should the song play? ");

            for (int play = 0; play < plays; play++)
            {
                playSong(drink, antagonist, missus);
            }
        }
        */

    }
}
