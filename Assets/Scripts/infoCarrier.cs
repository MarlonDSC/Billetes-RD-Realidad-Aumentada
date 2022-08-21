using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class infoCarrier : MonoBehaviour{
    public static infoCarrier existoInfoCarrier;
    [NonSerialized] public string titulo;
    [NonSerialized] public string descripcion;
    [NonSerialized] public Sprite imagen;
    [NonSerialized] public string lastScene;
    [NonSerialized] public bool billeteFace = true;
    // Start is called before the first frame update
    void Start(){
        if(existoInfoCarrier == null){
            existoInfoCarrier = this;
            DontDestroyOnLoad(this);
        }else{
            Destroy(gameObject);
        }
    }
    public void destruir(){
        Destroy(gameObject);
    }
}
