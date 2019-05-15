using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWord
{
   public class WordGenerator
    {
        public WordGenerator()
        {

        }
        Random rnd = new Random();
        string[] words = new string[]
        {
            "cow","dog","cancer","burger","spider"
        };
        public string Generate()
        {
            int num = rnd.Next(0, words.Length - 1);
            return words[num];
        }
    }
}
