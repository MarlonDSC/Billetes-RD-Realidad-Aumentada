using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CambioEscena : MonoBehaviour
{
	public Button boton_billete50;
	public Button boton_billete100;
	public Button boton_billete200;
	public Button boton_billete500;
	
	[Header("Pantalla carrusel")]
	public GameObject panelCarusel;
	
	// Start is called before the first frame update
	void Start()
	{
		boton_billete50.onClick.AddListener(carga_billete50);
		boton_billete100.onClick.AddListener(carga_billete100);
		boton_billete200.onClick.AddListener(carga_billete200);
		boton_billete500.onClick.AddListener(carga_billete500);
	}

	// Update is called once per frame
	void Update()
	{

	}
    
	void carga_billete50()
	{
		SceneManager.LoadScene("Billete_50");
	}
	void carga_billete100()
	{
		SceneManager.LoadScene("Billete_100");
	}
	
	void carga_billete200()
	{
		SceneManager.LoadScene("Billete_200");
	}
	void carga_billete500()
	{
		SceneManager.LoadScene("Billete_300");
	}
	
}