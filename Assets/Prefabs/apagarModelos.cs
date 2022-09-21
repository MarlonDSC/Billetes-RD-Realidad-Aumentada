    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class apagarModelos : MonoBehaviour
{
    public GameObject[] modelos;
    public GameObject modelo;
    GameObject objetoVacio;
    private void Start()
    {
        apagarTodosExepto(objetoVacio);  
    }
    
    
    
    public void apagarTodosExepto( GameObject modeloEncendido)
    {
        for (var i=0; i< modelos.Length; i++)
        {
            if (modeloEncendido != modelos[i])
            {
                modelos[i].SetActive(false);
            }
            else
            {
                modelos[i].SetActive(true);
            }
        }
    }
    
    
    

}
