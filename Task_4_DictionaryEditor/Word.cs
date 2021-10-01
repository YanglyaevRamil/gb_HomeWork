using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEditor
{
    public class Word
    {
        public string WordRU { get; set; }
        public string WordENG { get; set; }

        public Word()
        {

        }
        public Word(string RU, string ENG)
        {
            WordRU = RU;
            WordENG = ENG;
        }
    }
}
