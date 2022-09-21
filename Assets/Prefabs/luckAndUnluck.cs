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


    private Vector3 positonModel;
    private Quaternion rotationModel;
    private bool estado = true;

    private void Start()
    {
        //rotationModel = prefab.transform.rotation;
        //positonModel = prefab.transform.position;


        botonLock.onClick.AddListener(apagarEncenderImageTargets);
        //botonLock.onClick.AddListener(delegate { instanciarPrefab(prefab); });


        botonUnlock.onClick.AddListener(apagarEncenderImageTargets);
        //botonUnlock.onClick.AddListener(destruirPrefab);




    }

   public void apagarEncenderImageTargets()
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


   public void instanciarPrefab(GameObject miPrefab)
    {
        prefabInstanciado = Instantiate(miPrefab);

        prefabInstanciado.transform.parent = emptyPadre.transform;

        emptyPadre.transform.position = imageTarget.transform.position;
        emptyPadre.transform.rotation = imageTarget.transform.rotation;


        prefabInstanciado.transform.position = miPrefab.transform.position;
        prefabInstanciado.transform.rotation = miPrefab.transform.rotation;

        emptyPadre.transform.parent = arCamera.transform;

        imageTarget.SetActive(false);
        estado = false;


    }


    public void destruirPrefab()
    {
        Destroy(prefabInstanciado);
        estado = true;

    }


}
