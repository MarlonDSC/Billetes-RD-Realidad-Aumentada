using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class displayBilleteInfo : MonoBehaviour
{
    public Text titulo;
    public Text descripcion;
    public Image imagen;
    public infoScreenBackButton boton;
    void Start(){
        infoCarrier openChest = GameObject.Find("infoCarrier").GetComponent<infoCarrier>();
        titulo.text = openChest.titulo;
        descripcion.text = openChest.descripcion;
        boton.NombreEscena = openChest.lastScene;
        imagen.sprite = openChest.imagen;

        Sprite parteBillete = openChest.imagen;
        Vector2 sizePadre = imagen.transform.parent.GetComponent<RectTransform>().sizeDelta;
        if(parteBillete.rect.width > parteBillete.rect.height){
            float height = sizePadre.x*((float)parteBillete.rect.height/(float)parteBillete.rect.width);
            imagen.rectTransform.sizeDelta = new Vector2(sizePadre.x, height);
        }else{
            float width = sizePadre.y*((float)parteBillete.rect.width/(float)parteBillete.rect.height);
            imagen.rectTransform.sizeDelta = new Vector2(width, sizePadre.y);
        }
        imagen.transform.parent.GetChild(1).GetComponent<RectTransform>().sizeDelta = new Vector2(imagen.rectTransform.sizeDelta.x + 20f, imagen.rectTransform.sizeDelta.y + 20f);
    }
}
