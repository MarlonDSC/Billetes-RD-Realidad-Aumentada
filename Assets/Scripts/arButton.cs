using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class arButton : MonoBehaviour
{
    public Camera mainCamera;
    public RotacionBilletes btnRotacion;
    public Animator btnVolver, btnRotar;
    public Text titulo;
    void Start(){
        GetComponent<Button>().onClick.AddListener(() => StartCoroutine(accion()));
    }
    IEnumerator accion(){
        var scene = SceneManager.LoadSceneAsync("Visualizador3D");
        scene.allowSceneActivation = false;

        GameObject caraDelantera = btnRotacion.caraDelantera;
		GameObject caraTrasera = btnRotacion.caraTrasera;

        infoCarrier chest = GameObject.Find("infoCarrier").GetComponent<infoCarrier>();
        chest.position = caraDelantera.activeSelf ? caraDelantera.transform.localPosition : caraTrasera.transform.localPosition;

        Animator[] animations = {btnVolver, btnRotar, GetComponent<Animator>()};
        foreach(Animator animacion in animations){
            animacion.Rebind();
        }
        btnVolver.Play("btnAR");
        btnRotar.Play("btnAR");
        GetComponent<Animator>().Play("btnAR");
        
        string txtTitle = titulo.text;
        float tiempo = 0f;
        while(tiempo < 0.5f){
            tiempo+= Time.deltaTime;
            if(tiempo < 0.5f){
                titulo.text = txtTitle.Substring(0, txtTitle.Length - (int)((float)txtTitle.Length * tiempo/0.5f));
            }else{
                titulo.text = "";
            }
            yield return null;
        }

        scene.allowSceneActivation = true;
    }
}
