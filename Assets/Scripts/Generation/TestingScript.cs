using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    [SerializeField] private Partitioning partitioning;
    [SerializeField] private Generation generation;
    [SerializeField] private Vector2 size;
    [SerializeField] private int margin;

    // Start is called before the first frame update
    void Start()
    {
        Rectangle canvas = new Rectangle(transform.position, size);
        Node<Rectangle> root = new Node<Rectangle>(canvas, 0);
        print(partitioning);
        partitioning.Generate(root);

        List<Node<Rectangle>> leaves = new();
        root.Leaves(leaves);

        for (int i = 0; i < leaves.Count; i++)
        {
            leaves[i].Data.Draw(Color.red, 10);
        }
       
        Vector2[] positions = new Vector2[leaves.Count];
        for (int i = 0; i < leaves.Count; i++)
        {
            positions[i] = leaves[i].Data.Center;
        }
        
        Kgraph graph = new Kgraph(positions);
        Kedge[] path = graph.Kruskal();
        
        for (int i = 0; i < path.Length; i++)
        {
            Vector2 src = graph.Vertex[path[i].source].position;
            Vector2 dst = graph.Vertex[path[i].destination].position;
            Debug.DrawLine(src, dst, Color.yellow, 10);
        }
        int width = (int)Mathf.Ceil(size.x);
        int height = (int)Mathf.Ceil(size.y);

        Grid<int> grid = new Grid<int>(transform.position, width, height, 1, -1);
        grid.Draw(Color.blue, 10, -1);
        

        for (int i = 0; i < path.Length; i++)
        {
            Kedge e = path[i];
            Kvertex s = graph.Vertex[e.source];
            Kvertex d = graph.Vertex[e.destination];

            grid.PointToIndex(s.position, out int sX, out int sY);
            grid.PointToIndex(d.position, out int dX, out int dY);
            float distance = Grid<bool>.Distance(sX, sY, dX, dY);
            while(distance>0)
            { int dx = dX - sX;
                int dy = dY - sY;

                if (dx != 0)
                    sX += dx / Mathf.Abs(dx);

                else
                    sY += dy / Mathf.Abs(dy);

                grid.SetValue(1, sX, sY);
                distance = Grid<bool>.Distance(sX, sY, dX, dY);

            }
        }
        grid.Draw(Color.yellow, 10, 1);

        for (int i = 0; i < leaves.Count; i++)
        {
            Rectangle r = leaves[i].Data;

            Vector2 bl = r.Origin;
            Vector2 tr = r.Origin + r.Size;

            grid.PointToIndex(bl, out int blx, out int bly);
            grid.PointToIndex(tr, out int trx, out int @try);

            for (int x = blx + margin; x < trx - margin; x++)
            {
                for (int y = bly + margin; y < @try - margin; y++)
                {
                    grid.SetValue(0, x, y);
                }
            }
        }
        grid.Draw(Color.green, 10, 0);
        generation.Generate(grid);
        //Rectangle rectangle = new Rectangle(transform.position, new Vector2(5, 7));
        //rectangle.Draw(Color.red, 5);
        //    Node<int> Root = new Node<int>(5, 0);

        //    Node<int> bl1 = new Node<int>(3, 1);

        //    Node<int> br1 = new Node<int>(8, 1);

        //    Node<int> tl1 = new Node<int>(7, 1);

        //    Node<int> tr1 = new Node<int>(14, 1);

        //    Root.Bottomleft = bl1;
        //    Root.Bottomright = br1;
        //    Root.Topleft = tl1;
        //    Root.Topright = tr1;

        //    Node<int> bl2 = new Node<int>(3, 2);
        //    Node<int> br2 = new Node<int>(2, 2);
        //    Node<int> tl2 = new Node<int>(27, 2);
        //    Node<int> tr2 = new Node<int>(4, 2);

        //    br1.Bottomleft = bl2;
        //    br1.Bottomright = br2;
        //    br1.Topleft = tl2;
        //    br1.Topright = tr2;

        //    Node<int> bl3 = new Node<int>(6, 3);
        //    Node<int> br3 = new Node<int>(0, 3);
        //    Node<int> tl3 = new Node<int>(-5, 3);
        //    Node<int> tr3 = new Node<int>(8, 3);
        //    tr2.Bottomleft = bl3;
        //    tr2.Bottomright = br3;
        //    tr2.Topleft = tl3;
        //    tr2.Topright = tr3;

        //    List<Node<int>> leaves = new List<Node<int>>();
        //    Root.Leaves(leaves);

        //    for (int i = 0; i < leaves.Count; i++)
        //    {
        //        print(leaves[i].Data);
        //    }
    }
}
