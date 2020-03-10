using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleParallel
{
    class Numbers
    {
        static List<int> randomNumbers { get; set; }
        Dictionary<int, int> result = new Dictionary<int, int>();
        static Numbers()
        {
            Random rnd = new Random();
            randomNumbers = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                randomNumbers.Add(i+1);
            }
        }

        public void Print()
        {
            Console.WriteLine("Print number foreach...");
            foreach (var item in result.OrderBy(o=> o.Key))
            {
                Console.Write($"({item.Key},{item.Value})  ");
            }
        }

        public void FindNumberDivisorsParallel()
        {
            result = new Dictionary<int, int>();
            Parallel.For(0, randomNumbers.Count - 1, i =>
              {
                  int counter = 0;
                  for (int j = 0; j < randomNumbers.Count - 2; j++)
                  {
                      if (randomNumbers[j] % randomNumbers[i] == 0)
                      { counter++; }
                  }
                  result.Add(randomNumbers[i], counter);
              }
            );
            this.Print();
        }

        public void FindNumberDivisorsSequential()
        {
            result = new Dictionary<int, int>();
            for(int i = 0; i< randomNumbers.Count - 1; i++)
            {
                int counter = 0;
                for (int j = 0; j < randomNumbers.Count - 2; j++)
                {
                    if (randomNumbers[j] % randomNumbers[i] == 0)
                    { counter++; }
                }
                result.Add(randomNumbers[i], counter);
            }
            this.Print();
        }
    }
}
