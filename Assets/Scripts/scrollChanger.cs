using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DanielLochner.Assets.SimpleScrollSnap;

public class scrollChanger : MonoBehaviour
{
    public GameObject DNTA;
    private Transform fondo;
    public Button AR;
    public TMP_Dropdown menu;
    private bool cambiar = false;
    public GameObject Billetes, Temas;
    private billeteActual regreso;
    public Image linea;
    public Text titulo;
    private SimpleScrollSnap scroller;

    void Start(){
        DNTA.SetActive(true);
        
        fondo = transform.parent;

        GetComponent<Button>().onClick.AddListener(() => StartCoroutine(btnAccion()));
        
        regreso = GameObject.Find("billeteActual").GetComponent<billeteActual>();

        bool noAnim = true;
        if(regreso.billetes_temas){
            Instantiate(Billetes, fondo);
            reUbicarScrollSnap();

            if(regreso.billete > -1){
                noAnim = false;
                Transform scrollSnap = fondo.GetChild(0);
                linea.color = Color.clear;
                scrollSnap.GetComponent<SimpleScrollSnap>().startingPanel = regreso.billete;

                scrollSnap.GetChild(0).GetChild(0).GetChild(regreso.billete).GetComponent<Image>().color = Color.white;

                StartCoroutine(animRegrasar(scrollSnap.GetChild(0).GetChild(0), regreso.billete));
            }
        }else{
            cambiar = true;
            Instantiate(Temas, fondo);
            reUbicarScrollSnap();

            if(regreso.topico > -1){
                noAnim = false;
                Transform scrollSnap = fondo.GetChild(0);
                linea.color = Color.clear;
                scrollSnap.GetComponent<SimpleScrollSnap>().startingPanel = regreso.topico;

                scrollSnap.GetChild(0).GetChild(0).GetChild(regreso.topico).GetComponent<Image>().color = Color.white;

                StartCoroutine(animRegrasar(scrollSnap.GetChild(0).GetChild(0), regreso.topico));
            }
        }
        scroller = fondo.GetChild(0).GetComponent<SimpleScrollSnap>();
        if(noAnim){
            DNTA.SetActive(false);
            Transform content = fondo.GetChild(0).GetChild(0).GetChild(0);
            for(int i = 0; i < content.childCount; i += 1){
                content.GetChild(i).GetComponent<Image>().color = Color.white;
            }
        }
    }
    IEnumerator animRegrasar(Transform content, int imgMain){
        string txtTitulo = titulo.text;
        titulo.text = "";

        float tiempo = 0f;
        while(tiempo < 0.5f){
            tiempo += Time.deltaTime;
            if(tiempo < 0.5f){
                titulo.text = txtTitulo.Substring(0, (int)((float)txtTitulo.Length * tiempo/0.5f));
                linea.color += Color.white * (Time.deltaTime/0.5f);
            }else{
                titulo.text = txtTitulo;
                linea.color = Color.white;
            }
            for(int i = 0; i < content.childCount; i += 1){
                if(i != imgMain){
                    if(tiempo < 0.5f){
                        content.GetChild(i).GetComponent<Image>().color += Color.white * (Time.deltaTime/0.5f);
                    }else{
                        content.GetChild(i).GetComponent<Image>().color = Color.white;
                    }
                }
            }
            yield return null;
        }
        DNTA.SetActive(false);
    }
    Transform reUbicarScrollSnap(){
        Transform content = null;
        fondo.GetChild(fondo.childCount-1).SetSiblingIndex(0);
        content = fondo.GetChild(0).GetChild(0).GetChild(0);
        return content;
    }
    IEnumerator btnAccion(){
        DNTA.SetActive(true);
        AR.interactable = false;
        menu.interactable = false;
        GetComponent<Button>().interactable = false;
        Transform content = fondo.GetChild(0).GetChild(0).GetChild(0);

        int index = -1;
        float alpha = -1f;
        for(int i = 0; i < content.childCount; i += 1){
            float alpha2 = content.GetChild(i).GetComponent<CanvasGroup>().alpha;
            if(alpha2 >= alpha){
                alpha = alpha2;
                index = i;
            }
        }

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
            regreso.topico = index;
            Instantiate(Billetes, fondo);
            cambiar = false;

            if(regreso.billete > -1){
                fondo.GetChild(fondo.childCount-1).GetComponent<SimpleScrollSnap>().startingPanel = regreso.billete;
            }

        }else{
            regreso.billete = index;
            Instantiate(Temas, fondo);
            cambiar = true;

            if(regreso.topico > -1){
                fondo.GetChild(fondo.childCount-1).GetComponent<SimpleScrollSnap>().startingPanel = regreso.topico;
            }
        }
        
        content = reUbicarScrollSnap();

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
