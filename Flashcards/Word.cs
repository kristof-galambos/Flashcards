using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards
{
    class Word
    {
        public string known;
        public string foreign;
        public bool active;
        public int counter;
        public Word(string k, string f)
        {
            known = k;
            foreign = f;
            active = true;
            counter = 0;
        }
    }
}
