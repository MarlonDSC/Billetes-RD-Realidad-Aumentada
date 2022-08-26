using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class btnInicioBillete : MonoBehaviour
{
	public string NombreEscena;

	// Start is called before the first frame update
	void Start(){
		GetComponent<Button>().onClick.AddListener(cargarEscena);
	}
    
	void cargarEscena(){
        GameObject chest = GameObject.Find("infoCarrier");
        Destroy(chest);
		SceneManager.LoadScene(NombreEscena);
	}
}