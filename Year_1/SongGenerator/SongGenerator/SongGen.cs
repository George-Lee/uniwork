using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongGenerator
{
    class SongGen
    {
        static void Main(string[] args)
        {
            Song song1 = new Song("Bittersweet");
            Song song2 = new Song("Three and a half Inch Floppy");
            Song song3 = new Song("Two Minutes to Midnight");
            Song song4 = new Song("Whisky in the Jar");

            Console.WriteLine(song1.GetSongName());
            Console.WriteLine(song2.GetSongName());
            Console.WriteLine(song3.GetSongName());
            Console.WriteLine(song4.GetSongName());

            Verse verse1 = new Verse("As I was going' over the Cork and Kerry mountains\n" +
                                "I saw Captain Farrell and his money he was counting\n" +
                                "I first produced my pistol and I then produced my rapier\n" +
                                "I said stand or deliver or the devil he may take ya\n");
            Verse verse2 = new Verse("I took all of his money and it was a pretty penny.\n" +
                                "I took all of his money and I brought it home to Molly\n" +
                                "She swore that she loved me never would she leave me\n" +
                                "But the devil take that woman for you know she tricked me easy");

            Chorus chorus1 = new Chorus("Musha ring dum a do dum a da.\n" +
                                "Whack for my daddy-o, \n" +
                                "Whack for my daddy-o \n" +
                                "There's whisky in the jar-o");

            // song3.Print();

            song4.SetChorus(chorus1);
            song4.SetVerse(verse1, 1);
            song4.SetVerse(verse2, 2);
            song4.Print();
        }
    }
}
