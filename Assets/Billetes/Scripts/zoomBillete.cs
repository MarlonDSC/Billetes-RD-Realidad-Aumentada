using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zoomBillete : MonoBehaviour{
    public Button regresar;
    [System.NonSerialized] public Vector3 posInicial;
    [System.NonSerialized] public Vector2 tamInicial;
    void Start(){
        posInicial = GetComponent<RectTransform>().localPosition;
        tamInicial = GetComponent<RectTransform>().sizeDelta;
    }

    public IEnumerator zoom(Vector3 position, Vector2 width_height){
        regresar.interactable = false;
        float segundo = 0f;
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector3 positionDelta = position - rectTransform.localPosition;
        Vector2 sizeDelta = width_height - rectTransform.sizeDelta;
        while(segundo < 1f){
            segundo += Time.deltaTime;
            if(segundo >= 1f){
                rectTransform.localPosition = position;
                rectTransform.sizeDelta = width_height;
            }else{
                rectTransform.localPosition += positionDelta*Time.deltaTime;
                rectTransform.sizeDelta += sizeDelta*Time.deltaTime;
            }
            yield return null;
        }
        regresar.interactable = true;
    }
}