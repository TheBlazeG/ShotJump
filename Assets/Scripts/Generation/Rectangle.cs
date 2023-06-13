using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rectangle 
{
    private Vector2 origin;
    private Vector2 size;

    public Vector2 Origin => origin;
    public Vector2 Size => size;
    public Vector2 Center => origin + size/2.0f;
public Rectangle(Vector2 origin, Vector2 size)
    {
        this.origin = origin;
        this.size = size;
       
    }
    public void Draw(Color color, float duration)
    {
        Vector2 blc=origin;
        Vector2 brc=origin+new Vector2(size.x,0);
        Vector2 tlc= origin + new Vector2(0, size.y);
        Vector2 trc=origin + size;
        Debug.DrawLine(blc, tlc, color, duration);
        Debug.DrawLine(tlc, trc, color, duration);
        Debug.DrawLine(trc, brc, color, duration);
        Debug.DrawLine(brc, blc, color, duration);
    }
}
