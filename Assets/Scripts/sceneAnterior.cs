using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneAnterior : MonoBehaviour
{
	public GameObject PantallaDeCarga;
	public Slider Slide;
	public int NumeroEscena;

	void Start(){
		gameObject.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(CargarAsync()));
	}
	
	IEnumerator CargarAsync(){

		AsyncOperation Operacion = SceneManager.LoadSceneAsync(NumeroEscena);
		
		PantallaDeCarga.SetActive(true);
		
		while (!Operacion.isDone)
		{
			//Operacion Mathf para tener un valor mas preciso de la carga de la escena 
			float progreso = Mathf.Clamp01(Operacion.progress / .9f);
			
			Slide.value = progreso;
			
			yield return new WaitForEndOfFrame();
		}
		
	}
}