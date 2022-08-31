using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CambioEscenas : MonoBehaviour
{
	public string NombreEscena;

	// Start is called before the first frame update
	void Start(){
		GetComponent<Button>().onClick.AddListener(cargarEscena);
	}
    
	void cargarEscena(){
		SceneManager.LoadScene(NombreEscena);
	}
}