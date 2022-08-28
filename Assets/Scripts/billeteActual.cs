using UnityEngine;
using System;

public class billeteActual : MonoBehaviour
{
    [NonSerialized] public int billete;
    public static billeteActual existoBilleteActual;
    void Start(){
        if(existoBilleteActual == null){
            existoBilleteActual = this;
            DontDestroyOnLoad(this);
        }else{
            Destroy(gameObject);
        }
    }
}