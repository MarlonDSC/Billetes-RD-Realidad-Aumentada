using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ubicadorDePuntos : MonoBehaviour
{
    void Update(){
        for(int i = 0; i < GetComponent<LineRenderer>().positionCount; i+=1){
            switch(i){
                case 0:
                    GetComponent<LineRenderer>().SetPosition(i, new Vector3(-1f*(GetComponent<RectTransform>().rect.width/2f), -1f*(GetComponent<RectTransform>().rect.height/2f), -6));
                    break;
                case 1:
                    GetComponent<LineRenderer>().SetPosition(i, new Vector3(GetComponent<RectTransform>().rect.width/2f, -1f*(GetComponent<RectTransform>().rect.height/2f), -6));
                    break;
                case 2:
                    GetComponent<LineRenderer>().SetPosition(i, new Vector3(GetComponent<RectTransform>().rect.width/2f, GetComponent<RectTransform>().rect.height/2f, -6));
                    break;
                case 3:
                    GetComponent<LineRenderer>().SetPosition(i, new Vector3(-1f*(GetComponent<RectTransform>().rect.width/2f), GetComponent<RectTransform>().rect.height/2f, -6));
                    break;
            }
        }
    }
}
