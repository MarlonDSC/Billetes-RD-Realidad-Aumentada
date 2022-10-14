using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scrollChanger : MonoBehaviour
{
    public GameObject DNTA;
    public Transform fondo;
    public Button AR;
    public TMP_Dropdown menu;
    private bool cambiar = false;
    public GameObject Billetes, Historias;

    void Start(){
        GetComponent<Button>().onClick.AddListener(() => StartCoroutine(accion()));
    }
    IEnumerator accion(){
        DNTA.SetActive(true);
        AR.interactable = false;
        menu.interactable = false;
        GetComponent<Button>().interactable = false;
        Transform content = fondo.GetChild(0).GetChild(0).GetChild(0);

        float tiempo = 0f;
        while(tiempo < 0.5f){
            tiempo += Time.deltaTime;

            if(tiempo < 0.5f){
                for(int i = 0; i < content.childCount; i += 1){
                    content.GetChild(i).GetComponent<Image>().color += new Color(0f, 0f, 0f, -1f) * (Time.deltaTime/0.5f);
                }
            }else{
                for(int i = 0; i < content.childCount; i += 1){
                    Destroy(fondo.GetChild(0).gameObject);
                }
            }
            yield return null;
        }
        if(cambiar){
            Instantiate(Billetes, fondo);
            cambiar = false;
        }else{
            Instantiate(Historias, fondo);
            cambiar = true;
        }
        for(int i = 0; i < fondo.childCount; i += 1){
            if(fondo.GetChild(i).name == "Temas(Clone)" || fondo.GetChild(i).name == "Billetes(Clone)"){
                content = fondo.GetChild(i).GetChild(0).GetChild(0);
                fondo.GetChild(i).SetSiblingIndex(0);
                break;
            }
        }

        tiempo = 0f;
        while(tiempo < 0.5f){
            tiempo += Time.deltaTime;
            if(tiempo < 0.5f){
                for(int i = 0; i < content.childCount; i += 1){
                    content.GetChild(i).GetComponent<Image>().color += new Color(0f, 0f, 0f, 1f) * (Time.deltaTime/0.5f);
                }
            }else{
                for(int i = 0; i < content.childCount; i += 1){
                    content.GetChild(i).GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                }
            }
            yield return null;
        }

        AR.interactable = true;
        menu.interactable = true;
        GetComponent<Button>().interactable = true;
        DNTA.SetActive(false);
    }
}
