using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathAlgorithms
{
    public class DijkstrasAlgorithm
    {
        int numberOfNodes;
        int visitedNodes;
        List<Relations> relations;
        Dictionary<char, bool> isVisited;
        Dictionary<char, int> minDistances;
        Dictionary<char, string> minPaths;

        public DijkstrasAlgorithm(int numberOfNodes, List<Relations> relations, char startingNode)
        {
            this.numberOfNodes = numberOfNodes;
            this.relations = relations;
            this.visitedNodes = 0;
            isVisited = new Dictionary<char, bool>();
            minDistances = new Dictionary<char, int>();
            minPaths = new Dictionary<char, string>();

            for(int i = 0; i < numberOfNodes; i++)
            {
                isVisited.Add(Convert.ToChar('A' + i), false);
                minDistances.Add(Convert.ToChar('A' + i), int.MaxValue);
                minPaths.Add(Convert.ToChar('A' + i), string.Empty);
            }
            //TODO: Implement
            //solveByDijkstrasAlgorithm(startingNode,relations)
        }

        public void solveByDijkstrasAlgorithm(char startingNode, List<Relations> relations)
        {
            if(!isVisited[startingNode])
            {
                isVisited[startingNode] = true;
                visitedNodes++;
                minDistances[startingNode] = 0;
                minPaths[startingNode] = startingNode.ToString();
            }
        }



        public Dictionary<char,int> findNotVisitedNeighbours(char currentNode, List<Relations> relations)
        {
            Dictionary<char, int> neighbours = new Dictionary<char, int>();
            foreach (Relations rel in relations)
            {
                if (!isVisited[rel.source] && rel.source.Equals(currentNode))
                    neighbours.Add(rel.target, rel.distance);
                else if (!isVisited[rel.target] && rel.target.Equals(currentNode))
                    neighbours.Add(rel.source, rel.distance);
            }
            return neighbours;
        }

        public char findNearestNeighbours(char currentNode, Dictionary<char,int> neighbours)
        {
            //Update new distances 
            foreach(var item in neighbours)
            {
                if( minDistances[item.Key] > minDistances[currentNode] + item.Value)
                    minDistances[item.Key] = minDistances[currentNode] + item.Value;
            }

            //To find the closest neighbour
            var min = int.MaxValue;
            char nearest=' ';
            foreach(var distance in minDistances)
            {
                if ((!isVisited[distance.Key]) && (distance.Value < min))
                {
                    min = distance.Value;
                    nearest = distance.Key;
                }
            }
            return nearest;
        }
    }
}
