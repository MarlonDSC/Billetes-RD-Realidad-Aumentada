using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class btnBackTemas : MonoBehaviour
{
    // Start is called before the first frame update
    private Button button;
    public Text titulo;
    public TextMeshProUGUI descripcion;
    public GameObject DNTA;
    public Image linea;
    private billeteActual informacion;
    void Start(){
        informacion = GameObject.Find("billeteActual").GetComponent<billeteActual>();
        button = GetComponent<Button>();
        button.onClick.AddListener(() => StartCoroutine(accion()));
        StartCoroutine(venida());
    }
    IEnumerator venida(){
        DNTA.SetActive(true);
        button.interactable = false;
        string txtTitulo = informacion.titulo;
        string txtDesc = informacion.descripcion;
        titulo.text = "";
        descripcion.text = "";
        linea.color = new Color(1f, 1f, 1f, 0f);
        button.image.color = new Color(1f, 1f, 1f, 0f);

        float tiempoTranscurrido = 0f;
        float tiempoHaTrancurrir = 0.5f;
        while(tiempoTranscurrido < tiempoHaTrancurrir){
            tiempoTranscurrido += Time.deltaTime;
            if(tiempoTranscurrido < tiempoHaTrancurrir){
                titulo.text = txtTitulo.Substring(0, (int)((float)txtTitulo.Length * (tiempoTranscurrido/tiempoHaTrancurrir)));
                descripcion.text = txtDesc.Substring(0, (int)((float)txtDesc.Length * (tiempoTranscurrido/tiempoHaTrancurrir)));
                linea.color += new Color(0f, 0f, 0f, 1f)*(tiempoTranscurrido/tiempoHaTrancurrir);
                button.image.color += new Color(0f, 0f, 0f, 1f)*(tiempoTranscurrido/tiempoHaTrancurrir);
            }else{
                titulo.text = txtTitulo;
                descripcion.text = txtDesc;
                linea.color = new Color(1f, 1f, 1f, 1f);
                button.image.color = new Color(1f, 1f, 1f, 1f);
            }
            yield return null;
        }

        DNTA.SetActive(false);
        button.interactable = true;
    }
    IEnumerator accion(){
        var scene = SceneManager.LoadSceneAsync("Scroll_Snap");
        scene.allowSceneActivation = false;

        DNTA.SetActive(true);
        button.interactable = false;
        string txtTitulo = titulo.text;
        string txtDesc = descripcion.text;

        float tiempoTranscurrido = 0f;
        float tiempoHaTrancurrir = 0.5f;
        while(tiempoTranscurrido < tiempoHaTrancurrir){
            tiempoTranscurrido += Time.deltaTime;
            if(tiempoTranscurrido < tiempoHaTrancurrir){
                titulo.text = txtTitulo.Substring(0, txtTitulo.Length - (int)((float)txtTitulo.Length * (tiempoTranscurrido/tiempoHaTrancurrir)));
                descripcion.text = txtDesc.Substring(0, txtDesc.Length - (int)((float)txtDesc.Length * (tiempoTranscurrido/tiempoHaTrancurrir)));
                linea.color -= new Color(0f, 0f, 0f, 1f)*(tiempoTranscurrido/tiempoHaTrancurrir);
                button.image.color -= new Color(0f, 0f, 0f, 1f)*(tiempoTranscurrido/tiempoHaTrancurrir);
            }else{
                titulo.text = "";
                descripcion.text = "";
                linea.color = new Color(1f, 1f, 1f, 0f);
                button.image.color = new Color(1f, 1f, 1f, 0f);
            }
            yield return null;
        }
        scene.allowSceneActivation = true;
    }
}
