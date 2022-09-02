using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scrollToBillete : MonoBehaviour
{
    public GameObject btnNext, btnBack;
    public ScrollRect scroll;
    public Image titulo, linea;
    public Scrollbar barraScroll;
    [SerializeField] private string scene;
    [SerializeField] private int numBillete;

    void Start(){
        GetComponent<Button>().onClick.AddListener(() => StartCoroutine(accion()));
    }
    IEnumerator accion(){
        var sceneLoad = SceneManager.LoadSceneAsync(scene);
		sceneLoad.allowSceneActivation = false;
        Transform padre = transform.parent;
        for(int i = 0; i < padre.childCount; i += 1){
            padre.GetChild(i).GetComponent<Button>().interactable = false;
        }
        scroll.horizontal = false;
        btnNext.SetActive(false);
        btnBack.SetActive(false);
        billeteActual chest = GameObject.Find("billeteActual").GetComponent<billeteActual>();
        chest.billete = numBillete;
        chest.size = GetComponent<RectTransform>().sizeDelta;
        chest.position = transform.position;
        chest.scrollBar = barraScroll.value;

        float tiempo = 0f;
        while(tiempo < 0.5f){
            tiempo += Time.deltaTime;
            for(int i = 0; i < padre.childCount; i += 1){
                if(i != transform.GetSiblingIndex()){
                    if(tiempo < 0.5f){
                        padre.GetChild(i).GetComponent<Image>().color += new Color(0f, 0f, 0f, -1f*Time.deltaTime*2f);
                    }else{
                        padre.GetChild(i).GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
                    }
                }
            }
            if(tiempo < 0.5f){
                titulo.color += new Color(0f, 0f, 0f, -1f*Time.deltaTime*2f);
                linea.color += new Color(0f, 0f, 0f, -1f*Time.deltaTime*2f);
            }else{
                titulo.color = new Color(0f, 0f, 0f, 0f);
                linea.color = new Color(0f, 0f, 0f, 0f);
            }
            yield return null;
        }
        
        sceneLoad.allowSceneActivation = true;
    }
}
