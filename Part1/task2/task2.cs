using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ');
            Words dict = new Words();
            for(int i=0; i<words.Length; i++)
            {
                dict.InsertNewWord(words[i]);
            }
            Console.Write(dict.WriteWords());
        }
    }

    class Words
    {
        Dictionary<string, int> words;

        int maxCount;
        int maxLength;

        public Words()
        {
            words = new Dictionary<string, int>();
            maxCount = 0;
        }

        public void InsertNewWord(string newWord)
        {
            if (newWord.Length > maxLength)
            {
                maxLength = newWord.Length;
            }

            if (words.ContainsKey(newWord))
            {
                words[newWord] += 1;
                if (words[newWord] > maxCount)
                {
                    maxCount = words[newWord];
                }
            }
            else
            {
                words.Add(newWord, 1);
                if (maxCount < 1)
                {
                    maxCount = 1;
                }
            }
        }

        public string WriteWords()
        {
            string result = "";
            words = words.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            foreach (var item in words)
            {
                for (int i = 0; i < (maxLength - item.Key.Length); i++)
                {
                    result += "_";
                }
                result += item.Key + " ";
                double pointCount = (10.0 * item.Value) / maxCount;
                int pointCountR = Round(pointCount);

                for (int i = 0; i < pointCountR; i++)
                {
                    result += ".";
                }

                result += Environment.NewLine;
            }
            return result;
        }

        private int Round(double data)
        {
            if (data - (int)data < 0.5)
            {
                return (int)data;
            }
            else
            {
                return (int)data + 1;
            }
        }
    }
}
