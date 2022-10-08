using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bibliografias : MonoBehaviour
{
    void Start(){
        GetComponent<Button>().onClick.AddListener(() => accion());
    }

    void accion(){
        Application.OpenURL("https://docs.google.com/document/d/1EwYtzwrO212HH_4fEQX34gyDTHOWQrCagTKHHES2AIQ/edit?usp=sharing");
    }
}
