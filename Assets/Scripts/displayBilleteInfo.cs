using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class displayBilleteInfo : MonoBehaviour
{
    public TextMeshProUGUI titulo;
    public TextMeshProUGUI descripcion;
    public Image imagen;
    public CambioEscenas boton;
    void Start(){
        infoCarrier openChest = GameObject.Find("infoCarrier").GetComponent<infoCarrier>();
        titulo.text = openChest.titulo;
        descripcion.text = openChest.descripcion;
        imagen.sprite = openChest.imagen;
        boton.NombreEscena = openChest.lastScene;
    }
}
