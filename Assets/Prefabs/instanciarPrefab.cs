using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instanciarPrefab : MonoBehaviour
{
    //La ARCamera será el objeto padre de nuestro modelo para que se mantenga estático en pantalla
    public GameObject arCamera;

    //Este empty será el padre de la nueva instancia del modelo escaneado
    public GameObject emptyPadre;

    //Contenedor del padre (Abuelo)
    public GameObject emptyContenedor;

    //Botones para mantener modelos en pantalla estátticos y volver al estado original
    public Button botonLock, botonUnlock;

    //El objeto que debemos de instanciar en un nuevo GameObject
    public GameObject prefab;

    //Nueva instancia de nuestro prefab. Este se mostrará en pantalla.
    GameObject prefabInstanciado;

    //Image Targets
    public GameObject[] imageTargets;
    public GameObject imageTarget;

    //Prefabs vacío
    GameObject prefabVacio;

    //prueba
    private bool estado = true;


    private void Start()
    {
        botonUnlock.onClick.AddListener(delegate { crearInstanciaPrefab(prefab);});
        botonLock.onClick.AddListener(destruirInstanciaPrefab);
    }

    public void crearInstanciaPrefab(GameObject prefabParaInstanciar)
    {
        if (prefabParaInstanciar.activeSelf)
        {
        prefabInstanciado = prefabVacio;
        prefabInstanciado = Instantiate(prefabParaInstanciar);
        prefabInstanciado.transform.parent = emptyPadre.transform;

        emptyPadre.transform.position = imageTarget.transform.position;
        emptyPadre.transform.rotation = imageTarget.transform.rotation;

  
        emptyPadre.transform.parent = arCamera.transform;

        }
        else
        {
            return;
        }
 
    }

    public void destruirInstanciaPrefab()
    {
       
        Destroy(prefabInstanciado);
        estado = true;
        emptyPadre.transform.parent = emptyContenedor.transform;
        emptyPadre.transform.position = new Vector3(0, 0, 0);
        emptyPadre.transform.rotation = new Quaternion(0, 0, 0,0);
        Destroy(prefabInstanciado);

        
    }





}
