using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger3D : MonoBehaviour
{
    public ParticleSystem particles;
    
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        print("entrando");
        print(other.transform);
        print(other.attachedRigidbody);
        particles.Play();
        
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        print("en trigger");
        
    }

    private void OnTriggerExit(Collider other)
    {
        particles.Stop();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    private void OnCollisionStay(Collision collision)
    {
        gameObject.SetActive(false);
    }
    private void OnCollisionExit(Collision collision)
    {
       
    }
}
