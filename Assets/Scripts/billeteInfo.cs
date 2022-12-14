using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class billeteInfo : MonoBehaviour
{
    public TMP_Text Description;
    public TMP_Text Titulo;
    [SerializeField] private Sprite imagen;
    private infoCarrier chest;

    public Animator btnVolver, btnRotar;
    // Start is called before the first frame update
    void Start(){
        GetComponent<Button>().onClick.AddListener(() => StartCoroutine(accion()));
        chest = GameObject.Find("infoCarrier").GetComponent<infoCarrier>();
    }

    IEnumerator accion(){
        var scene = SceneManager.LoadSceneAsync("Info");
        scene.allowSceneActivation = false;
        
        Text screenTitle = btnRotar.GetComponent<RotacionBilletes>().titulo;
        string txtTitulo = screenTitle.text;
   

        Transform padre = transform.parent;
        for(int i = 0; i < padre.childCount; i+= 1){
            if(i != transform.GetSiblingIndex()){
                padre.GetChild(i).gameObject.SetActive(false);
            }
        }
        GetComponent<Image>().color *= new Color(1f, 1f, 1f, 0f);

        chest.titulo =  Titulo.text;
        chest.descripcion = Description.text;
        chest.imagen = imagen;
        chest.lastScene = gameObject.scene.name;
        chest.regreso = true;

        Animator[] animations = {btnVolver, btnRotar};
        foreach(Animator animacion in animations){
            animacion.Rebind();
        }
        btnVolver.Play("btnVolver");
        btnRotar.Play("btnAR");

        float segundos = 0f;
        while(segundos < 0.5f){
            segundos += Time.deltaTime;
            if(segundos >= 0.5f){
                padre.eulerAngles = new Vector3(0f, 90f, 0f);
                screenTitle.text = "";
            }else{
                screenTitle.text = txtTitulo.Substring(0, txtTitulo.Length - (int)((float)txtTitulo.Length * segundos/0.5f));
                padre.eulerAngles += new Vector3(0f, 90f*Time.deltaTime*2f, 0f);
            }
            yield return null;
        }

        scene.allowSceneActivation = true;
    }
}
