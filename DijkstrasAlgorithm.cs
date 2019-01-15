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

        public DijkstrasAlgorithm(int numberOfNodes, List<Relations> relations)
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
        }

        public Dictionary<char, int> solveByDijkstrasAlgorithm(char currentNode)
        {
            startDijkstrasAlgorithm(currentNode);

            //Main while
            while(visitedNodes != numberOfNodes)
            {
                var neighbours = findNotVisitedNeighbours(currentNode);
                if (neighbours.Count == 0) //There is no neighbour
                    break;
                else
                {
                    isVisited[currentNode] = true;
                    currentNode = findNearestNeighbours(currentNode, neighbours);
                    visitedNodes++;
                }
            }
            return minDistances;
        }

        public void startDijkstrasAlgorithm(char currentNode)
        {
            if (!isVisited[currentNode])
            {
                isVisited[currentNode] = true;
                visitedNodes++;
                minDistances[currentNode] = 0;
                minPaths[currentNode] = currentNode.ToString();
            }
        }

        public Dictionary<char,int> findNotVisitedNeighbours(char currentNode)
        {
            Dictionary<char, int> neighbours = new Dictionary<char, int>();
            foreach (Relations rel in relations)
            {
                if (rel.source.Equals(currentNode) && !isVisited[rel.target])
                    neighbours.Add(rel.target, rel.distance);
                else if (rel.target.Equals(currentNode) && !isVisited[rel.source] )
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
