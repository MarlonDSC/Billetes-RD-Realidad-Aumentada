using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class luckAndUnluck : MonoBehaviour
{
    public GameObject arCamera;
    public GameObject emptyPadre;
    public Button botonLock, botonUnlock;

    public GameObject prefab, prefabInstanciado;

    public GameObject [] imageTargets;
    public GameObject imageTarget;


    private Vector3 PositonModel;
    private Quaternion RotationModel;
    private bool Estado = true;

    private void Start()
    {
        botonLock.onClick.AddListener(apagarEncenderImageTargets);
        botonUnlock.onClick.AddListener(apagarEncenderImageTargets);
    }




    void apagarEncenderImageTargets()
    {
        
        for (var i = 0; i < imageTargets.Length; i++)
        {
            if (imageTargets[i].activeSelf)imageTargets[i].SetActive(false);

            else imageTargets[i].SetActive(true);
        }

        if (botonLock.gameObject.activeSelf) botonLock.gameObject.SetActive(false);
        else botonLock.gameObject.SetActive(true);

        if (botonUnlock.gameObject.activeSelf) botonUnlock.gameObject.SetActive(false);
        else botonUnlock.gameObject.SetActive(true);
        
        

    }


   public void instanciarPrefab()
    {
        prefabInstanciado = Instantiate(prefab);

        prefabInstanciado.transform.parent = emptyPadre.transform;

        emptyPadre.transform.position = imageTarget.transform.position;
        emptyPadre.transform.rotation = imageTarget.transform.rotation;


        prefabInstanciado.transform.position = prefab.transform.position;
        prefabInstanciado.transform.rotation = prefab.transform.rotation;

        emptyPadre.transform.parent = arCamera.transform;

        imageTarget.SetActive(false);
        Estado = false;


    }


    public void DestruirPrefab()
    {
        Destroy(prefabInstanciado);
        Estado = true;

    }


}
