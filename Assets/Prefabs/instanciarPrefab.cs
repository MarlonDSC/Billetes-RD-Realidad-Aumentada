using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instanciarPrefab : MonoBehaviour
{
    //La ARCamera ser� el objeto padre de nuestro modelo para que se mantenga est�tico en pantalla
    public GameObject arCamera;

    //Este empty ser� el padre de la nueva instancia del modelo escaneado
    public GameObject emptyPadre;

    //Contenedor del padre (Abuelo)
    public GameObject emptyContenedor;

    //Botones para mantener modelos en pantalla est�tticos y volver al estado original
    public Button botonLock, botonUnlock;

    //El objeto que debemos de instanciar en un nuevo GameObject
    public GameObject prefab;

    //Nueva instancia de nuestro prefab. Este se mostrar� en pantalla.
    GameObject prefabInstanciado;

    //Image Targets
    //public GameObject[] imageTargets;
    public GameObject imageTarget;

    //Prefabs vac�o
    public GameObject targets;

    //prueba
    private bool estado = true;


    private void Start()
    {
        botonUnlock.onClick.AddListener(delegate { crearInstanciaPrefab(prefab); });
        botonLock.onClick.AddListener(destruirInstanciaPrefab);


        //botonLock.onClick.AddListener(apagarTargets);
        //botonUnlock .onClick.AddListener(apagarTargets);
        //botonUnlock.onClick.AddListener(apagarEncenderImageTargets);
        //botonLock.onClick.AddListener(apagarEncenderImageTargets);
    }

    public void crearInstanciaPrefab(GameObject prefabParaInstanciar)
    {
        if (prefabParaInstanciar.activeSelf)
        {
        
        //Asignar el par�metro que recibimos en una variable
        prefabInstanciado = Instantiate(prefabParaInstanciar);

        //Volvemos el objeto instanciado hijo del Empty padre
        prefabInstanciado.transform.parent = emptyPadre.transform;
        
        //Asignamos valores de position y rotation para ubicarlo en el lugar exacto
        emptyPadre.transform.position = imageTarget.transform.position;
        emptyPadre.transform.rotation = imageTarget.transform.rotation;

        //Volvemos al emptyPadre hijo del arCamera para que quede est�ticos
        emptyPadre.transform.parent = arCamera.transform;


            //Apagamos el boton desactivar
            botonUnlock.gameObject.SetActive(false);

            //encendemos el boton activar
            botonLock .gameObject.SetActive(true);

            //apagamos targets
            targets.SetActive(false);
        }
        else
        {
            
        }
 
    }

    public void destruirInstanciaPrefab()
    {
       
        Destroy(prefabInstanciado);
        emptyPadre.transform.parent = emptyContenedor.transform;
        emptyPadre.transform.position = new Vector3(0, 0, 0);
        emptyPadre.transform.rotation = new Quaternion(0, 0, 0,0);
        Destroy(prefabInstanciado);

        //apagamos el bot�n

        botonLock.gameObject.SetActive(false);

        //Encendemos targets
        targets.SetActive(true);
    }

    
    public void apagarTargets()
    {
        targets.SetActive(false);
    }



}
