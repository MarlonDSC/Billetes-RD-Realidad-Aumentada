using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LockUnlock : MonoBehaviour
{
    public Button Boton;
    public GameObject prefab;
    public GameObject newObject;
    public bool Estado = true;

    // Start is called before the first frame update
    void Start()
    {
        if (Estado == true)
        {
            Boton.onClick.AddListener(delegate { CrearPrefab(); });
        }
        else
        {
            Boton.onClick.AddListener(delegate { DestruirPrefab(); });
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CrearPrefab()
    {
       newObject = Instantiate(prefab);
       Estado = false;
    }
    public void DestruirPrefab()
    {
        Destroy(newObject);
        Estado = true;
        
    }
}
