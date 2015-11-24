using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongGenerator
{
    class Chorus
    {
        string text;

        public Chorus(string theText)
        {
            text = theText;
        }

        public void Print()
        {
            Console.WriteLine(text);
        }
    }
}
