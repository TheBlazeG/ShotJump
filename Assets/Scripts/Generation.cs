using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    [SerializeField] private GameObject roomCorner;
    [SerializeField] private GameObject roomWall;
    [SerializeField] private GameObject roomFloor;
   public void Generate(Grid<int> grid)
    {
        for (int x = 0; x < grid.Width; x++)
        {
            for (int y=0; y<grid.Height; y++)
            {
                int[,] n = new int[3, 3];
                //inferior
                n[0, 0] = grid.Getvalue(x - 1, y - 1);
                n[0, 0] = grid.Getvalue(x, y - 1);
                n[0, 0] = grid.Getvalue(x + 1, y - 1);
                //central
                n[0, 1] = grid.Getvalue(x - 1, y);
                n[1, 1] = grid.Getvalue(x, y);
                n[2, 1] = grid.Getvalue(x + 1, y);

                //Superior
                n[0, 2] = grid.Getvalue(x - 1, y+1);
                n[1, 2] = grid.Getvalue(x, y+1);
                n[2, 2] = grid.Getvalue(x + 1, y + 1);

                //Cuartos
                if (grid.Getvalue(x,y)==0)
                {
                    int left = n[0, 1];
                        int right = n[2, 1];
                        int top = n[1, 2];
                        int bottom = n[1, 0];

                    GameObject prefab;
                    Vector3 Rotation;

                        //esquina superior izquierda
                    if (left==-1 && top==-1 && right== 0 && bottom ==0)
                    {
                        prefab = roomCorner;
                        Rotation = new Vector3(0, 0, -90f);
                    }
                    //Sup der
                   else if (left == 0 && top == -1 && right == -1 && bottom == 0)
                    {
                        prefab = roomCorner;
                        Rotation = new Vector3(0, 0, -180f);
                    }
                    //inf izq
                   else if (left == -1 && top == 0 && right == 0 && bottom == -1)
                    {
                        prefab = roomCorner;
                        Rotation = Vector3.zero;
                    }
                    //inf der
                   else if (left == 0 && top == 0 && right == -1 && bottom == -1)
                    {
                        prefab = roomCorner;
                        Rotation = new Vector3(0, 0, 90f);
                    }
                    //IZQ
                   else if (left == -1 && top == 0 && right == 0 && bottom == 0)
                    {
                        prefab = roomWall;
                        Rotation =  Vector3.zero;
                    }
                    //SUP
                   else if (left == 0 && top == -1 && right == 0 && bottom == 0)
                    {
                        prefab = roomWall;
                        Rotation = new Vector3(0, 0, -90f);
                    }
                    //DER
                    else if (left == 0 && top == 0 && right == -1 && bottom == 0)
                    {
                        prefab = roomWall;
                        Rotation = new Vector3(0, 0, -180f);
                    }
                    //INF
                    else if (left == 0 && top == 0 && right == 0 && bottom == -1)
                    {
                        prefab = roomWall;
                        Rotation = new Vector3(0, 0, 90f);
                    }
                    //celda de cuarto
                    else
                    {
                        prefab = roomFloor;
                        Rotation = new Vector3(0, 0, 0f) ;
                    }
                    GameObject instance = Instantiate(prefab);
                    instance.transform.localEulerAngles = Rotation;

                    grid.IndexToPoint(x, y, out Vector2 point);
                    Vector3 Center = point + (Vector2.one*grid.Size)/2.0f;
                    instance.transform.position = Center;
                }
            }
        }
    }
}
