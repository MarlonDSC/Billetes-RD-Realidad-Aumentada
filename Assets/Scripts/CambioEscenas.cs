using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CambioEscenas : MonoBehaviour
{
	public string NombreEscena;
	[SerializeField] private int numBillete = -1;

	// Start is called before the first frame update
	void Start(){
		GetComponent<Button>().onClick.AddListener(cargarEscena);
	}
    
	void cargarEscena(){
		if(numBillete > -1){
			GameObject.Find("billeteActual").GetComponent<billeteActual>().billete = numBillete;
		}
		SceneManager.LoadScene(NombreEscena);
	}
}