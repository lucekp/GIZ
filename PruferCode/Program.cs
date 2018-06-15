using System;

namespace Input
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var prufer = new Prufer();

            // Take the input of the number of vertices of the tree.
            var vertices = GetVerticies();
            var edge = GetEdges(vertices);

            var pruferCode = prufer.Code(vertices, edge);

            Console.WriteLine(prufer.DeCode(pruferCode));

            Console.ReadKey();
        }

        private static int GetVerticies()
        {
            Console.Write("Enter the number of vertices of the tree: ");
            var vertexes = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            return vertexes;
        }

        private static int[,] GetEdges(int vertexes)
        {
            var edges = vertexes - 1;
            var edge = new int[edges, 2];
            Console.Write("\nFor ");
            Console.Write(vertexes);
            Console.Write(" vertices this connected tree must have exactly ");
            Console.Write(edges);
            Console.Write(" edges.\n");
            // Enter the vertex pairs which have an edge between them.
            Console.Write("\nEnter ");
            Console.Write(edges);
            Console.Write(" pair of vertices for the tree.\n");
            for (var i = 0; i < edges; i++)
            {
                Console.Write("Enter the vertex pair for edge ");
                Console.Write(i + 1);
                Console.Write(":");
                Console.Write("\nV(1): ");
                edge[i, 0] = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
                Console.Write("V(2): ");
                edge[i, 1] = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            }

            return edge;
        }
    }

    public class Prufer
    {
        public int[] Code(int vertices, int[,] edge)
        {
            var x = 0;
            var result = new int[vertices - 2];
            var edges = vertices - 1;
            var deg = new int[vertices + 1];

            for (var i = 0; i < edges; i++)
            {
                deg[edge[i, 0]]++;
                deg[edge[i, 1]]++;
            }

            Console.Write("\nThe Prufer code for the given tree is: { ");
            for (var i = 0; i < vertices - 2; i++)
            {
                var min = 10000;

                for (var j = 0; j < edges; j++)
                {
                    if (deg[edge[j, 0]] == 1)
                        if (min > edge[j, 0])
                        {
                            min = edge[j, 0];
                            x = j;
                        }

                    if (deg[edge[j, 1]] == 1)
                        if (min > edge[j, 1])
                        {
                            min = edge[j, 1];
                            x = j;
                        }
                }

                // Remove the selected vertex by decreasing its degree to 0.
                deg[edge[x, 0]]--;

                // Decrement the degree of other vertex, since we have removed the edge.
                deg[edge[x, 1]]--;

                // Print the vertex from which leaf vertex is removed.
                if (deg[edge[x, 0]] == 0)
                {
                    result[i] = edge[x, 1];
                    Console.Write(edge[x, 1]);
                    Console.Write(" ");
                }
                else
                {
                    result[i] = edge[x, 0];
                    Console.Write(edge[x, 0]);
                    Console.Write(" ");
                }
            }

            Console.Write("}\n");

            return result;
        }

        public string DeCode(int[] prufer)
        {
            var m = prufer.Length;
            var vertices = m + 2;
            var vertexSet = new int[vertices];
            for (var i = 0; i < vertices - 2; i++) vertexSet[prufer[i] - 1] += 1;
            var result = "The edge set E(G) is: ";
            var j = 0;
            for (var i = 0; i < vertices - 2; i++)
            for (j = 0; j < vertices; j++)
                if (vertexSet[j] == 0)
                {
                    vertexSet[j] = -1;
                    result += "(" + (j + 1) + "," + prufer[i] + ")";
                    vertexSet[prufer[i] - 1]--;
                    break;
                }
            for (var i = 0; i < vertices; i++)
                if (vertexSet[i] == 0 && j == 0)
                {
                    result += "(" + (i + 1) + ",";
                    j++;
                }
                else if (vertexSet[i] == 0 && j == 1)
                {
                    result += (i + 1) + ")";
                }

            return result;
        }
    }
}