using UnityEngine;
using System;

public class billeteActual : MonoBehaviour
{
    [NonSerialized] public int billete;
    [NonSerialized] public Vector2 size;
    [NonSerialized] public Vector3 position;
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