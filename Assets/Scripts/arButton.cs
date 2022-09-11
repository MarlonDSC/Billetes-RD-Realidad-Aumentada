using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class arButton : MonoBehaviour
{
    public Camera mainCamera;
    public RotacionBilletes btnRotacion;
    public Animator btnVolver, btnRotar, titulo, btnAR;
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

        Animator[] animations = {btnVolver, btnRotar, titulo, btnAR};
        foreach(Animator animacion in animations){
            animacion.Rebind();
        }
        btnVolver.Play("btnAR");
        btnRotar.Play("btnAR");
        titulo.Play("title");
        btnAR.Play("btnAR");
        yield return new WaitForSeconds(0.5f);

        scene.allowSceneActivation = true;
    }
}
