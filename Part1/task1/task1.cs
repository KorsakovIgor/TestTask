using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            HashTable hashTable = new HashTable(N);
            string[] values = Console.ReadLine().Split(' ');
            for(int i=0; i< values.Length; i++)
            {
                hashTable.Insert(Convert.ToInt32(values[i]));
            }
            Console.Write(hashTable.WriteHash());
           
        }

    }

    class ListNode
    {
        int value;
        public int Value
        {
            get
            {
                return this.value;
            }
        }
        public ListNode next;

        public ListNode(int data)
        {
            value = data;
        }
    }

    class List
    {
        ListNode first;
        ListNode last;
        int count;

        public List()
        {
            count = 0;
            first = null;
            last = null;
        }

        public void Add(int data)
        {
            ListNode node = new ListNode(data);

            if (count == 0)
            {
                first = node;
            }
            else
            {
                last.next = node;
            }
            last = node;
            count++;
        }

        public string WriteList()
        {
            string list = "";
            ListNode cur = first;

            while (cur != null)
            {
                list += " " + cur.Value.ToString();
                cur = cur.next;
            }
            return list;
        }

    }

    class HashTable
    {
        public List[] values;
        int N;

        public HashTable(int N)
        {
            values = new List[N];
            this.N = N;
        }

        public void Insert(int newValue)
        {
            int index = newValue % N;
            if (values[index] == null)
            {
                values[index] = new List();
            }
            values[index].Add(newValue);
        }

        public string WriteHash()
        {
            string hash = "";

            for (int i = 0; i < N; i++)
            {
                hash += i.ToString() + ":";
                if (values[i] != null)
                {
                    hash += values[i].WriteList();
                }

                if (i != N - 1) hash += Environment.NewLine;
            }
            return hash;
        }
    }
}
