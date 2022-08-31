using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PantallaCarga : MonoBehaviour
{	
	public string nombreScena;
    // Start is called before the first frame update
    void Start()
    {   
	    StartCoroutine(CargarAsync(nombreScena));    
    }

    // Update is called once per frame
	void Update()
    
	{

    }

	//Co-rutina para cargar la escena de forma Asincrona
	IEnumerator CargarAsync(string nombreScena){
		yield return new WaitForSeconds(2f);
		
		AsyncOperation Operacion = SceneManager.LoadSceneAsync(nombreScena);
		
		// Espera hasta que la escena este completamente cargada
		while (!Operacion.isDone)
		{
			yield return null;
		}
	}
	
}
