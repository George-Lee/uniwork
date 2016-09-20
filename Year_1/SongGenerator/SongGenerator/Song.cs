using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongGenerator
{
    class Song
    {
        string songName;
        string artist;
        string dateOfAuthorship;
        string genre;
        string album;
        int length;
        int bpm;
        Verse verse1;
        Verse verse2;
        Verse verse3;
        Verse verse4;
        Chorus chorus;

        public Song(string songName)
        {
            SetSongName(songName);
        }

        public void SetVerse(Verse verse, int verseNumber)
        {
            switch (verseNumber)
            {
                case 1: verse1 = verse; break;
                case 2: verse2 = verse; break;
                case 3: verse3 = verse; break;
                case 4: verse4 = verse; break;
                default:
                    Console.WriteLine("ERROR! " + verseNumber + " is invalid!");
                    break;
            }
        }

        public void SetChorus(Chorus chrs)
        {
            chorus = chrs;
        }

        public void SetSongName(string name)
        {
            songName = name;
        }

        public string GetSongName()
        {
            return songName;
        }

        public void Print()
        {
            Console.WriteLine("=== " + GetSongName() + " ===");
            if (verse1 != null)
                verse1.Print();
            if (chorus != null)
                chorus.Print();
            if (verse2 != null)
                verse2.Print();
            if (chorus != null)
                chorus.Print();
            if (verse3 != null)
                verse3.Print();
            if (chorus != null)
                chorus.Print();
            if (verse4 != null)
                verse4.Print();
            if (chorus != null)
                chorus.Print();
        }
    }
}
