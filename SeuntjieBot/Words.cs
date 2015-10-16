using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeuntjieBot
{
    class Words
    {
        public string word { get; private set; }
        public int score { get; private set; }
        public bool post { get; private set; }
        public bool are { get; private set; }
        public bool an { get; private set; }
        public Words(string word, int score, bool post, bool are)
        {
            this.word = word;
            this.score = score;
            this.post = post;
            this.are = are;
            this.an = false;
        }
        public Words(string word, int score, bool post, bool are, bool an)
        {
            this.word = word;
            this.score = score;
            this.post = post;
            this.are = are;
            this.an = an;
        }
        public Words(string word, int score)
        {
            this.word = word;
            this.score = score;
            this.post = false;
            this.are = false;
        }

        public override string ToString()
        {
            string s = "";
            if (!post)
            {
                s = word + " you";
            }
            else
            {
                s = "you" + (are ? "'re " + (an ? startsWithVowel() ? "an " : "a " : "") : " ") + word;
            }
            return s;
        }

        bool startsWithVowel()
        {
            char c = word.ToLower()[0];
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                return true;
            if (c == 'h' && word.ToLower().StartsWith("hu"))
                return true;
            return false;
        }
    }
}
