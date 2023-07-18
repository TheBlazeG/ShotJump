using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cube;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void SetActiveCube(bool state)
    {
        cube.SetActive(state);
    }
    public void MoveCube(float value)
    {
        cube.transform.position = new Vector3(value, 0, 0);
        Debug.Log(value);
    }
}
