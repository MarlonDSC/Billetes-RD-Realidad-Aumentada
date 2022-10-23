using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scrollToBillete : MonoBehaviour
{
    [SerializeField] private string scene;
    [SerializeField] private int numBillete;
    private billeteActual chest;
    private scrollChanger properties;
    public bool billetes_temas = true;

    void Start(){
        chest = GameObject.Find("billeteActual").GetComponent<billeteActual>();
        properties = GameObject.Find("Scroll changer").GetComponent<scrollChanger>();
        GetComponent<Button>().onClick.AddListener(() => StartCoroutine(accion()));
    }
    IEnumerator accion(){
        var sceneLoad = SceneManager.LoadSceneAsync(scene);
		sceneLoad.allowSceneActivation = false;

        properties.DNTA.SetActive(true);
        properties.AR.interactable = false;
        properties.GetComponent<Button>().interactable = false;
        properties.menu.interactable = false;

        Text titulo = properties.titulo;
        Image linea = properties.linea;

        string txtTitulo = titulo.text;
        Transform padre = transform.parent;

        if(billetes_temas){
            chest.billete = numBillete;
        }else{
            chest.topico = numBillete;
            chest.titulo = transform.GetChild(0).GetComponent<Text>().text;
            chest.descripcion = transform.GetChild(1).GetComponent<Text>().text;
        }

        chest.size = GetComponent<RectTransform>().sizeDelta;
        chest.position = transform.position;
        chest.billetes_temas = billetes_temas;

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
                }else if(!billetes_temas){
                    if(tiempo < 0.5f){
                        padre.GetChild(i).GetComponent<Image>().color += new Color(0f, 0f, 0f, -1f*Time.deltaTime*2f);
                    }else{
                        padre.GetChild(i).GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
                    }
                }
            }
            if(tiempo < 0.5f){
                titulo.text = txtTitulo.Substring(0, txtTitulo.Length - (int)((float)txtTitulo.Length * tiempo/0.5f));
                linea.color += new Color(0f, 0f, 0f, -1f*Time.deltaTime*2f);
            }else{
                titulo.text = "";
                linea.color = new Color(0f, 0f, 0f, 0f);
            }
            yield return null;
        }
        
        sceneLoad.allowSceneActivation = true;
    }
}
