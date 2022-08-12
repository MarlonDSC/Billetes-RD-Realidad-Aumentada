using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CargarInicio : MonoBehaviour
{
	public Button botonVolverInicio;

	
	// Start is called before the first frame update
	void Start()
	{
		botonVolverInicio.onClick.AddListener(carga_carrusel);

	}

    
	void carga_carrusel()
	{
		SceneManager.LoadScene("swipe");
	}
}
