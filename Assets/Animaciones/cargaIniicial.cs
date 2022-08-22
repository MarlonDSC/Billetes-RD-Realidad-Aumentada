using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cargaIniicial : MonoBehaviour
{
	public string scene;
	void Start(){
		StartCoroutine(accion());
	}
	IEnumerator accion(){
		GetComponent<Animator>().Rebind();
		GetComponent<Animator>().Play("Pantalla de carga de inicio");
		yield return new WaitForSeconds(139f/60f);
		SceneManager.LoadScene(scene);
	}
}