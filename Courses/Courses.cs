namespace Courses
{
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