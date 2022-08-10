using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class regresarBillete : MonoBehaviour
{
    public RectTransform billete;
    public Animator cuadroDeTexto;
    void Start(){
        GetComponent<Button>().onClick.AddListener(() => StartCoroutine(regresar()));
    }
    IEnumerator regresar(){
        GetComponent<Button>().interactable = false;
        cuadroDeTexto.Rebind();
        cuadroDeTexto.Play("Informacion de billete Reverse");

        Vector3 posicionDelta = variables.billetePosition - billete.localPosition;
        Vector2 sizeDelta = variables.billeteSize - billete.sizeDelta;
        float segundo = 0f;
        while(segundo < 1f){
            segundo += Time.deltaTime;
            if(segundo >= 1f){
                billete.localPosition = variables.billetePosition;
                billete.sizeDelta = variables.billeteSize;
            }else{
                billete.localPosition += posicionDelta*Time.deltaTime;
                billete.sizeDelta += sizeDelta*Time.deltaTime;
            }
            yield return null;
        }

        for(int i = 0; i < billete.childCount; i += 1){
            billete.GetChild(i).gameObject.SetActive(true);
            billete.GetChild(i).GetComponent<LineRenderer>().sortingOrder = 4;
        }

        transform.parent.gameObject.SetActive(false);
        yield return null;
    }
}
