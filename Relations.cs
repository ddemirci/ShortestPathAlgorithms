using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathAlgorithms
{
    public class Relations
    {
        public char source;
        public char target;
        public int distance;

        public Relations(char source, char target, int distance)
        {
            this.source = source;
            this.target = target;
            this.distance = distance;
        }
    }
}
