using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node <T>
{
    public T Data { get; private set; } = default;
    
    public int Level { get; private set; }

    public Node<T> Bottomleft { get; set; }

    public Node<T> Bottomright { get; set; }
    public Node<T> Topleft { get; set; }
    public Node<T> Topright { get; set; }

    public Node(T data, int level)
    {
        Data = data;
        Level=level;
    }

    public void Leaves(List< Node<T>> leaves)
    {
        if (Bottomleft != null) Bottomleft.Leaves(leaves);
        if (Bottomright != null) Bottomright.Leaves(leaves);
        if (Topleft != null) Topleft.Leaves(leaves);
        if (Topright != null) Topright.Leaves(leaves);
        if (Bottomleft==null &&Bottomright==null && Topleft==null && Topright==null)
            leaves.Add(this);
    }
}
