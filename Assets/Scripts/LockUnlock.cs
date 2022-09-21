using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LockUnlock : MonoBehaviour
{
    public GameObject ArCamera;
    public GameObject Empty;
    public Button Boton;
    public GameObject prefab;
    public GameObject ImageTarget;
    public GameObject newObject;

    public Vector3 PositonModel;
    public Quaternion RotationModel;
    public bool Estado = true;

    // Start is called before the first frame update
    void Start()
    {

        PositonModel = prefab.transform.position;
        RotationModel = prefab.transform.rotation;
        if (Estado == true)
        {
            Boton.onClick.AddListener(delegate { CrearPrefab(prefab); });
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

    public void CrearPrefab(GameObject miPrefab)
    {
        Debug.Log("rotation: " + miPrefab.transform.rotation);
        Debug.Log("position: "+ miPrefab.transform.position);

        newObject = Instantiate(miPrefab);
        
        newObject.transform.parent = Empty.transform;


        Empty.transform.position = ImageTarget.transform.position; 
        Empty.transform.rotation = ImageTarget.transform.rotation;

        newObject.transform.position = miPrefab.transform.position;
        newObject.transform.rotation = miPrefab.transform.rotation;


        Empty.transform.parent = ArCamera.transform;

        ImageTarget.SetActive(false);
        Estado = false;
    }
    public void DestruirPrefab()
    {
        Destroy(newObject);
        Estado = true;
        
    }
}
