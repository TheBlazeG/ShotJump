using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsInstance : MonoBehaviour
{
    private static ControlsAsset m_Instance; //Almacena una única instancia de controles
    //regresa el objeto de controles
    public static ControlsAsset Instance
    {
        get 
        { 
            return m_Instance; 
        }
}

    private void Awake() 
    {

        //si ya existen los controles
        if (m_Instance != null)
        {
            //destruye el objeto actual
            Destroy(gameObject);
            return;
        }
        //Crea los nuevos controles
        m_Instance = new ControlsAsset();
    }

    private void OnEnable()
    {
        m_Instance.Enable(); //activa los controles
    }

    private void OnDisable() // desactiva los controles
    {
        m_Instance.Disable();
    }
}
