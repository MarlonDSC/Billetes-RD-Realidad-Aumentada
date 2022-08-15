using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class infoBillete : MonoBehaviour
{
    [SerializeField] private string titulo;
    [SerializeField] private string informacion;
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector2 width_height;
    public Animator cuadroDeTexto;
    public Button btnRotar;
    void Start(){
        GetComponent<Button>().onClick.AddListener(() => mostrarInfo());
    }
    void mostrarInfo(){
        btnRotar.interactable = false;
        //width_height
        Transform padre = transform.parent;
        for(int i = 0; i < padre.childCount; i+= 1){
            if(i != transform.GetSiblingIndex()){
                padre.GetChild(i).gameObject.SetActive(false);
            }
        }
        RectTransform padreRect = padre.GetComponent<RectTransform>();
        StartCoroutine(padreRect.GetComponent<zoomBillete>().zoom(position, width_height));
        cuadroDeTexto.transform.parent.gameObject.SetActive(true);
        cuadroDeTexto.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = titulo;
        cuadroDeTexto.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = informacion;
        cuadroDeTexto.Rebind();
        cuadroDeTexto.Play("Informacion de billete");
        GetComponent<LineRenderer>().sortingOrder = -1;
        //Position Vector3(0,-109,0)
        //Width 1200
        //Height 505
    }
}
