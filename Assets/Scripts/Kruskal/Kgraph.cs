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
                edges.Add(edge);
            }
        }
        edges.Sort(delegate (Kedge x, Kedge y)
        {
            if (x.weight > y.weight) return 1;
            if (x.weight < y.weight) return -1;
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
            if (src.group==dst.group)
            {
                continue;
            }
            if (dst.group==-1)
            {
                int group = src.group;
                int destination = edge.destination;
                dst.group = group;
                vertex[destination] = dst;
                groups[group].vertex.Add(destination);
                path.Add(edges[i]);
                continue;
            }
            if (src.group==-1)
            {
                int group = dst.group;
                int source = edge.source;
                src.group = group;
                vertex[source] = src;
                groups[group].vertex.Add(source);
                path.Add(edges[i]);
                continue;
            }
            Kgroup sg = groups[src.group];
            Kgroup dg = groups[dst.group];
            for (int j = 0; j < dg.vertex.Count; j++)
            {
                int dgv = dg.vertex[j];
                Kvertex v = vertex[dgv];
                v.group = src.group;
                vertex[dgv] = v;
                sg.vertex.Add(dgv);
            }
            groups[src.group] = sg;
            path.Add(edges[i]);
        }
        return path.ToArray();
    }
    //public void Draw(Kedge[] edges,Color color,float duration)
}
