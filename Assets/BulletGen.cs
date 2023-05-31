using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGen : MonoBehaviour
{
    [SerializeField] private int samples;
    [SerializeField] private float horizontalSize;
    [SerializeField] private float verticalSize;
    [SerializeField] private float Circunference;
    [SerializeField] private float offset;
    [SerializeField] private float force;
    [SerializeField] private GameObject bulletPrefab;
    private void Awake()
    {
        Vector2[] positions = Generate();
        for (int i = 0; i < positions.Length; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, positions[i], Quaternion.identity);
            Vector2 Direction = positions[i] - (Vector2)transform.position;
            bullet.GetComponent<Rigidbody2D>().AddForce(Direction.normalized * force);
        }
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
        
        float angle = Circunference / samples;
        for (int i = 0; i < samples; i++)
        {
            float a = i * angle;

            Vector2 pos = new Vector2();
            pos.x = Mathf.Sin(offset+a)*horizontalSize;
            pos.y =Mathf.Cos(offset+a)*verticalSize;
            pos += (Vector2)transform.position;
            result[i] = pos;
        }
        return result;
    }
}
