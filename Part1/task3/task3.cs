using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ').ToList<string>();
            Calculate(input);
            Console.WriteLine(input[0]);
            
            
        }

        public static List<string> Calculate(List<string> input)
        {
            for(int i=0; i<input.Count; i++)
            {
                if(input[i]=="-")
                {
                    input[i] = (Convert.ToInt32(input[i - 2]) - Convert.ToInt32(input[i - 1])).ToString();
                    input.RemoveAt(i - 1);
                    input.RemoveAt(i - 2);
                    break;
                }

                if (input[i] == "+")
                {
                    input[i] = (Convert.ToInt32(input[i - 2]) + Convert.ToInt32(input[i - 1])).ToString();
                    input.RemoveAt(i - 1);
                    input.RemoveAt(i - 2);
                    break;
                }

                if (input[i] == "*")
                {
                    input[i] = (Convert.ToInt32(input[i - 2]) * Convert.ToInt32(input[i - 1])).ToString();
                    input.RemoveAt(i - 1);
                    input.RemoveAt(i - 2);
                    break;
                }

                if (input[i] == "/")
                {
                    input[i] = (Convert.ToInt32(input[i - 2]) / Convert.ToInt32(input[i - 1])).ToString();
                    input.RemoveAt(i - 1);
                    input.RemoveAt(i - 2);
                    break;
                }
            }

            if(input.Count!=1)
            {
                Calculate(input);
            }
            return input;
        }
    }
}
