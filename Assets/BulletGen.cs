using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGen : MonoBehaviour
{
    [SerializeField] private int samples;
    private void Awake()
    {
        Vector2[] positions = Generate();
        for (int i = 0; i < positions.Length-1; i++)
        {
            Vector2 o = positions[i];
            Vector2 f = positions[i + 1];
            Debug.DrawLine(o, f, Color.blue, 10);
        }
    }
    public Vector2[] Generate()
    {
        Vector2[] result = new Vector2[samples];
        float angle = (Mathf.PI * 2) / samples;
        for (int i = 0; i < samples; i++)
        {
            float a = i * angle;

            Vector2 pos = new Vector2();
            pos.x = Mathf.Sin(a);
            pos.x=Mathf.Cos(a);
            result[i] = pos;
        }
        return result;
    }
}
