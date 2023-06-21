using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    [SerializeField] private Partitioning partitioning;
    [SerializeField] private Vector2 size;
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

        Grid<int> grid = new Grid<int>(transform.position, 100, 100, 1, -1);
        grid.Draw(Color.blue, 10, -1);

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
