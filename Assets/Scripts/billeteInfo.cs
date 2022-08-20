using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class billeteInfo : MonoBehaviour
{
    [SerializeField] private string titulo;
    [SerializeField] private string descripcion;
    [SerializeField] private Sprite imagen;
    private infoCarrier chest;
    // Start is called before the first frame update
    void Start(){
        GetComponent<Button>().onClick.AddListener(() => accion());
        chest = GameObject.Find("infoCarrier").GetComponent<infoCarrier>();
    }

    void accion(){
        chest.titulo = titulo;
        chest.descripcion = descripcion;
        chest.imagen = imagen;
        chest.lastScene = gameObject.scene.name;
        SceneManager.LoadScene("Info");
    }
}
