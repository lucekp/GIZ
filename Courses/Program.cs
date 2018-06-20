using System;
using System.IO;
using System.Reflection;
using Input;

namespace Courses
{
    internal class Program
    {
        private static int[,] GetFile()
        {
            Console.WriteLine("Choose File {bezcyklu, jestcykl}");
            var filePath = ConsoleInput.ReadToWhiteSpace(true);
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"TestFiles\",
                filePath + @".txt");
            Console.WriteLine(path);

            if (File.Exists(path))
            {
                var counter = 0;
                var file = new StreamReader(path);
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

        private static void Main(string[] args)
        {
            var edges = GetFile();
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
}