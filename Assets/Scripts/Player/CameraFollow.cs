using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public Transform player;
    public float speed;
    public float Depth;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, speed * Time.deltaTime);
        Vector3 pos = transform.position;
        pos.z = Depth;
        transform.position = pos;
    }
}
