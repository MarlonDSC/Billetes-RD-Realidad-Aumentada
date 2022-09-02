using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class btnInicioBillete : MonoBehaviour
{
	[SerializeField] private string NombreEscena;
	public RotacionBilletes btnRotacion;

	void Start(){
		GetComponent<Button>().onClick.AddListener(() => StartCoroutine(cargarEscena()));
	}
    
	IEnumerator cargarEscena(){
		var scene = SceneManager.LoadSceneAsync(NombreEscena);
		scene.allowSceneActivation = false;
		billeteActual billeteUsar = GameObject.Find("billeteActual").GetComponent<billeteActual>();
		GameObject caraDelantera = null;
		GameObject caraTrasera = null;
		foreach(GameObject cara in btnRotacion.carasDelanteras){
			if(cara != null){
				caraDelantera = cara;
				break;
			}
		}
		foreach(GameObject cara in btnRotacion.carasTraseras){
			if(cara != null){
				caraTrasera = cara;
				break;
			}
		}

		GameObject[] billete = {caraDelantera, caraTrasera};
		foreach(GameObject lado in billete){
			for(int i = 0; i < lado.transform.childCount; i += 1){
				lado.transform.GetChild(i).gameObject.SetActive(false);
			}
		}

		if(!btnRotacion.activarRotacion){
			float segundo = 0f;
			while(segundo < 0.1f){
				segundo += Time.deltaTime;

				if(segundo >= 0.1f/2f && !caraDelantera.activeSelf){
					caraDelantera.SetActive(true);
				}
				if(segundo >= 0.1f){
					caraDelantera.transform.eulerAngles = new Vector3(0f, 0f, 0f);
				}else{
					caraDelantera.transform.eulerAngles += new Vector3(0f, 180f * (Time.deltaTime/0.1f), 0f);
				}

				if(segundo >= 0.1f/2f && caraTrasera.activeSelf){
					caraTrasera.SetActive(false);
				}
				if(segundo >= 0.1f){
					caraTrasera.transform.eulerAngles = new Vector3(0f, 180f, 0f);
				}else{
					caraTrasera.transform.eulerAngles += new Vector3(0f, 180f * (Time.deltaTime/0.1f), 0f);
				}

				yield return null;
			}
		}

		Vector2 sizeDiferencia = billeteUsar.size - caraDelantera.GetComponent<RectTransform>().sizeDelta;
		Vector3 positionDiferencia = billeteUsar.position - caraDelantera.transform.position;

		Animator[] animations = {btnRotacion.btnVolver, btnRotacion.titulo, btnRotacion.btnAR, btnRotacion.GetComponent<Animator>()};
		foreach(Animator animacion in animations){
			animacion.Rebind();
		}
		btnRotacion.btnVolver.Play("btnAR");
        btnRotacion.GetComponent<Animator>().Play("btnAR");
        btnRotacion.titulo.Play("title");
        btnRotacion.btnAR.Play("btnAR");

		float tiempo = 0f;
		while(tiempo < 0.5f){
			tiempo += Time.deltaTime;
			if(tiempo < 0.5f){
				caraDelantera.GetComponent<RectTransform>().sizeDelta += sizeDiferencia*Time.deltaTime*2f;
				caraDelantera.transform.position += positionDiferencia*Time.deltaTime*2f;
			}else{
				caraDelantera.GetComponent<RectTransform>().sizeDelta = billeteUsar.size;
				caraDelantera.transform.position = billeteUsar.position;
			}
			yield return null;
		}

        GameObject chest = GameObject.Find("infoCarrier");
        Destroy(chest);
		scene.allowSceneActivation = true;
	}
}