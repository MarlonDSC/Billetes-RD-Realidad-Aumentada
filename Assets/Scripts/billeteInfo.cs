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

    public Animator btnVolver, btnRotar, titulo2, btnAR;
    // Start is called before the first frame update
    void Start(){
        GetComponent<Button>().onClick.AddListener(() => StartCoroutine(accion()));
        chest = GameObject.Find("infoCarrier").GetComponent<infoCarrier>();
    }

    IEnumerator accion(){
        Transform padre = transform.parent;
        for(int i = 0; i < padre.childCount; i+= 1){
            if(i != transform.GetSiblingIndex()){
                padre.GetChild(i).gameObject.SetActive(false);
            }
        }
        GetComponent<LineRenderer>().sortingOrder = -1;

        chest.titulo = titulo;
        chest.descripcion = descripcion;
        chest.imagen = imagen;
        chest.lastScene = gameObject.scene.name;
        chest.regreso = true;

        Animator[] animations = {btnVolver, btnRotar, titulo2, btnAR};
        foreach(Animator animacion in animations){
            animacion.Rebind();
        }
        btnVolver.Play("btnVolver");
        btnRotar.Play("btnAR");
        titulo2.Play("title");
        btnAR.Play("btnAR");

        float segundos = 0f;
        while(segundos < 0.5f){
            segundos += Time.deltaTime;
            if(segundos >= 0.5f){
                padre.eulerAngles = new Vector3(0f, 90f, 0f);
            }else{
                padre.eulerAngles += new Vector3(0f, 90f*Time.deltaTime*2f, 0f);
            }
            yield return null;
        }

        SceneManager.LoadScene("Info");
    }
}
