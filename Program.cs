using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathAlgorithms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfNodes = 5;
            List<Relations> relations = new List<Relations>();
            relations.Add(new Relations('A', 'B', 3));
            relations.Add(new Relations('A', 'C', 1));
            relations.Add(new Relations('B', 'C', 7));
            relations.Add(new Relations('B', 'D', 5));
            relations.Add(new Relations('B', 'E', 1));
            relations.Add(new Relations('C', 'D', 2));
            relations.Add(new Relations('D', 'E', 7));

            Program pg = new Program();
            pg.printRelations(relations);
            Console.ReadKey();
            
        }

        public void printRelations(List<Relations> relations)
        {
            foreach(Relations rel in relations)
            {
                Console.WriteLine(rel.source.ToString() + " ==> " + rel.target.ToString() + "  " + rel.distance);
            }
        }
    }

}
