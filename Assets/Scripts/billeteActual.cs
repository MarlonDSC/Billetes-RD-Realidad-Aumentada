using UnityEngine;
using System;
using UnityEngine.UI;

public class billeteActual : MonoBehaviour
{
    [NonSerialized] public int billete = -1;
    [NonSerialized] public int topico = -1;
    [NonSerialized] public Vector2 size;
    [NonSerialized] public Vector3 position;
    [NonSerialized] public static billeteActual existoBilleteActual;
    [NonSerialized] public bool billetes_temas = true;
    [NonSerialized] public string titulo;
    [NonSerialized] public string descripcion;
    void Start(){
        if(existoBilleteActual == null){
            existoBilleteActual = this;
            DontDestroyOnLoad(this);
        }else{
            Destroy(gameObject);
        }
    }
}