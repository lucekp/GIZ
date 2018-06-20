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
}