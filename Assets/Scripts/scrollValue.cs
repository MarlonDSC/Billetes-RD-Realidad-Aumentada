using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DanielLochner.Assets.SimpleScrollSnap;

public class scrollValue : MonoBehaviour
{
    public GameObject btnNext, btnBack;
    public Image titulo, linea;
    public SimpleScrollSnap scrolSnap;
    public Transform billetesContainer;
    void Start(){
        billeteActual regreso = GameObject.Find("billeteActual").GetComponent<billeteActual>();
        if(regreso.billete > -1){
            btnNext.SetActive(false);
            btnBack.SetActive(false);
            titulo.color = Color.clear;
            linea.color = Color.clear;
            scrolSnap.startingPanel = regreso.billete;
            for(int i = 0; i < billetesContainer.childCount; i += 1){
                if(i != regreso.billete){
                    billetesContainer.GetChild(i).GetComponent<Image>().color = Color.clear;
                }
            }
            StartCoroutine(accion(regreso));
        }
    }
    IEnumerator accion(billeteActual regreso){
        yield return new WaitForEndOfFrame();
        GetComponent<Scrollbar>().value = regreso.scrollBar;

        float tiempo = 0f;
        while(tiempo < 0.5f){
            tiempo += Time.deltaTime;
            if(tiempo < 0.5f){
                titulo.color += Color.white * (Time.deltaTime/0.5f);
                linea.color += Color.white * (Time.deltaTime/0.5f);
            }else{
                titulo.color = Color.white;
                linea.color = Color.white;
            }
            for(int i = 0; i < billetesContainer.childCount; i += 1){
                if(i != regreso.billete){
                    if(tiempo < 0.5f){
                        billetesContainer.GetChild(i).GetComponent<Image>().color += Color.white * (Time.deltaTime/0.5f);
                    }else{
                        billetesContainer.GetChild(i).GetComponent<Image>().color = Color.white;
                    }
                }
            }
            yield return null;
        }
        btnNext.SetActive(true);
        btnBack.SetActive(true);
    }
}
