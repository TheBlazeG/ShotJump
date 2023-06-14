using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kgraph 
{
    private List<Kvertex> vertex;
    private List<Kedge> edges;

    public Kvertex[] Vertex => vertex.ToArray();
    public Kedge[] Edges => edges.ToArray();
    public Kgraph(Vector2[] positions)
    {
        vertex = new List<Kvertex>();
        for (int i = 0; i < positions.Length; i++)
        {
            Kvertex vertex = new Kvertex();
            vertex.position = positions[i];
            vertex.group = -1;
            this.vertex.Add(vertex);
        }
        edges = new List<Kedge>();
        for (int i = 0; i < vertex.Count; i++)
        {
            for (int j = i+1; j < vertex.Count; j++)
            {
                Kedge edge = new Kedge();
                edge.source = i;
                edge.destination = j;
                edge.weight = Vector2.Distance(vertex[i].position, vertex[j].position);
            }
        }
        edges.Sort(delegate (Kedge x, Kedge y)
        {
            if (x.weight > y.weight) return 1;
            if (x.weight < y.weight) return 1;
            return 0;
        });
        
    }
    
    public Kedge[] Kruskal()
    {
        List<Kedge> path = new List<Kedge>();
        List<Kgroup> groups = new List<Kgroup>();

        for (int i = 0; i < edges.Count; i++)
        {
            Kedge edge = edges[i];
            Kvertex src = vertex[edge.source];
            Kvertex dst = vertex[edge.destination];

            if (src.group==-1 && dst.group==-1)
            {
                src.group = groups.Count;
                dst.group = groups.Count;
                vertex[edge.source] = src;
                vertex[edge.destination] = dst;

                Kgroup group = new Kgroup();
                group.vertex = new List<int>
                {
                edge.source,
                edge.destination
                };

                groups.Add(group);
                path.Add(edges[i]);
                continue;
            }
        }
        return path.ToArray();
    }
}
