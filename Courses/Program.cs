using System;
using System.IO;
using System.Text;
using Input;

namespace Courses
{
    internal class Program
    {
        private static int[,] ReadFile
        {
            get
            {
                Console.WriteLine("Choose File {bezcyklu, jestcykl}");
                var filePath = ConsoleInput.ReadToWhiteSpace(true);
                var sb = new StringBuilder(@"C:\Users\pawel\source\repos\GIZ\Courses\TestFiles\filePath.txt");
                sb.Replace("filePath", filePath);

                if (File.Exists(sb.ToString()))
                {
                    var counter = 0;
                    var file = new StreamReader(sb.ToString());
                    string line;
                    var bounds = new int[2];
                    while ((line = file.ReadLine()) != null)
                    {
                        var entry = line.Split(' ');
                        bounds[0] = int.Parse(entry[0]);
                        bounds[1] = int.Parse(entry[1]);
                        break;
                    }

                    var entries = new int[bounds[1], 2];
                    while ((line = file.ReadLine()) != null)
                    {
                        var entry = line.Split(' ');
                        entries[counter, 0] = int.Parse(entry[0]);
                        entries[counter, 1] = int.Parse(entry[1]);
                        counter++;
                    }

                    file.Close();
                    return entries;
                }

                Console.WriteLine("File not found!");
                return new int[0, 0];
            }
        }

        private static void Main(string[] args)
        {
            var edges = ReadFile;
            var courses = new Courses(edges);

            for (var i = 0; i < edges.GetLength(0); i++)
            {
                var checkedEdges = new int[edges.GetLength(0), edges.GetLength(1)];

                courses.GetN(edges[i, 0], edges[i, 1], 0, checkedEdges);
            }

            if (courses.Result == false) Console.WriteLine("No");
            if (courses.Result) Console.WriteLine("Yes");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    internal class Courses
    {
        public Courses(int[,] entries)
        {
            Edges = entries;
        }

        public int[,] Edges { get; }
        public bool Result { get; set; } = true;

        public void GetN(int n, int c, int depth, int[,] checkedEdges)
        {
            for (var i = 0; i < Edges.GetLength(0); i++)
                if (n == checkedEdges[i, 0] && c == checkedEdges[i, 1])
                {
                    //Console.WriteLine("loop found");
                    Result = false;
                    return;
                }

            checkedEdges[depth, 0] = n;
            checkedEdges[depth, 1] = c;
            for (var i = 0; i < Edges.GetLength(0); i++)
                if (Edges[i, 0] == c)
                {
                    depth++;
                    //Console.WriteLine("Moving from:{0} {1} => {2} {3}", n, c, Entries[i, 0], Entries[i, 1]);
                    GetN(Edges[i, 0], Edges[i, 1], depth, checkedEdges);
                }
        }
    }
}