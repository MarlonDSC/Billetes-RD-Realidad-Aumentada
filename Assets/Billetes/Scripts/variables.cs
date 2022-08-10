using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variables : MonoBehaviour
{
    public static Vector2 billeteSize;
    public static Vector3 billetePosition;
    public RectTransform billete;

    void Start(){
        billetePosition = billete.localPosition;
        billeteSize = billete.sizeDelta;
    }
}
