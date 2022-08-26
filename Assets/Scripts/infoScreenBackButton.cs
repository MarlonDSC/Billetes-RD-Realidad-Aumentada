using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class infoScreenBackButton : MonoBehaviour
{
	public string NombreEscena;
    public Animator informacion; 
	// Start is called before the first frame update
	void Start(){
		GetComponent<Button>().onClick.AddListener(() => StartCoroutine(cargarEscena()));
	}
    
	IEnumerator cargarEscena(){
        GetComponent<Button>().interactable = false;
        informacion.Rebind();
        informacion.Play("info screen exit");
        yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene(NombreEscena);
	}	
}