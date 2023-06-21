using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid<T>
{
    public Vector2 Origin { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }
    public float Size { get; private set; }
    public T Default { get; private set; }
    public T[][] Cells {get; private set;}

    public Grid(Vector2 origin, int width, int height, float size, T @default)
    {
        Origin = origin;
        Width = width;
        Height = height;
        Size = size;
        Default = @default;

        Cells = new T[width][];
        for (int i = 0; i < width; i++)
            Cells[i] = new T[height];
        
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                Cells[x][y] = @default;
            }

        
    }

    public void SetValue(T value, int x, int y)
    {
        if (x < 0 || x >= Width) return;
        if (y < 0 || y >= Height) return;

        Cells[x][y] = value;
    }

    public T Getvalue(int x,int y)
    {
        if (x < 0 || x >= Width) return Default;
        if (y < 0 || y >= Height) return Default;

        return Cells[x][y];
    }

    public bool IndexToPoint(int x,int y,out Vector2 point)
    {
        point = Origin + new Vector2(x, y) * Size;
        if (x < 0 || x >= Width) return false;
        if (y < 0 || y >= Height) return false;

        return true;
    }

    public bool PointToIndex(Vector2 point,out int x, out int y)
    {
        Vector2 delta = point - Origin;
        x = (int)Mathf.Floor(delta.x / Size);
        y = (int)Mathf.Floor(delta.y / Size);

        if (x < 0 || x >= Width) return false;
        if (y < 0 || y >= Height) return false;

        return true;

    }

    public void Draw(Color color, float duration, T withValue)
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                if (!Cells[x][y].Equals(withValue))
                    continue;

                    Vector2 xOffset = Vector2.right * Size * x;
                    Vector2 yOffset = Vector2.up * Size * y;
                Vector2 origin = Origin + xOffset + yOffset;
                Debug.DrawLine(origin, origin + Vector2.up * Size, color, duration);
                Debug.DrawLine(origin + Vector2.up * Size,origin+Vector2.one*Size, color, duration);
                Debug.DrawLine(origin + Vector2.one * Size, origin + Vector2.right * Size, color, duration);
                Debug.DrawLine(origin, origin + Vector2.right * Size, color, duration);
            }
        }
    }
}
