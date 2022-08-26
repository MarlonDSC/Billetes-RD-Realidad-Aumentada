using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RotacionBilletes : MonoBehaviour
{
	public GameObject CaraFrontal;
	public GameObject CaraTrasera;
	bool activarRotacion;
	public regresarBillete btnVolver;
	public Animator btnVolver2, titulo, btnAR;
	private infoCarrier openChest;
	// Start is called before the first frame update
	void Start(){
		btnVolver.billete = CaraFrontal.GetComponent<RectTransform>();
		GetComponent<Button>().onClick.AddListener(() => StartCoroutine(rotador()));
		openChest = GameObject.Find("infoCarrier").GetComponent<infoCarrier>();
		activarRotacion = openChest.billeteFace;
		int activador = activarRotacion ? 0 : 1;
		int apagador = !activarRotacion ? 0 : 1;
		GameObject[] billete = {CaraFrontal, CaraTrasera};
		billete[activador].SetActive(true);
		billete[apagador].SetActive(false);

		if(openChest.regreso){
			Animator[] animations = {btnVolver2, titulo, btnAR, GetComponent<Animator>()};
			foreach(Animator animacion in animations){
				animacion.Rebind();
			}

			btnVolver2.Play("btnVolverback");
			titulo.Play("titleback");
			btnAR.Play("btnARback");
			GetComponent<Animator>().Play("btnARback");

			billete[activador].transform.eulerAngles = new Vector3(0f, -90f, 0f);
			StartCoroutine(regreso(activador));
		}else{
			billete[activador].transform.eulerAngles = new Vector3(0f, 0f, 0f);
		}

		billete[apagador].transform.eulerAngles = new Vector3(0f, 180f, 0f);
	}

	IEnumerator regreso(int lado){
		GameObject[] billete = {CaraFrontal, CaraTrasera};
		float segundos = 0f;
		while(segundos < 0.5f){
			segundos += Time.deltaTime;
			if(segundos >= 0.5f){
                billete[lado].transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }else{
                billete[lado].transform.eulerAngles += new Vector3(0f, 90f*Time.deltaTime*2f, 0f);
            }
            yield return null;
		}
		yield return null;
	}

	IEnumerator rotador(){
		GetComponent<Button>().interactable = false;
		activarRotacion = !activarRotacion;
		openChest.billeteFace = activarRotacion;

		int activador = activarRotacion ? 0 : 1;
		int apagador = !activarRotacion ? 0 : 1;

		GameObject[] billete = {CaraFrontal, CaraTrasera};
		btnVolver.billete = billete[activador].GetComponent<RectTransform>();
		foreach(GameObject lado in billete){
			for(int i = 0; i < lado.transform.childCount; i += 1){
				lado.transform.GetChild(i).GetComponent<Button>().interactable = false;
			}
		}

		float segundo = 0f;
		while(segundo < 1f){
			segundo += Time.deltaTime;

			if(segundo >= 0.5f && !billete[activador].activeSelf){
				billete[activador].SetActive(true);
			}
			if(segundo >= 1f){
				billete[activador].transform.eulerAngles = new Vector3(0f, 0f, 0f);
			}else{
				billete[activador].transform.eulerAngles += new Vector3(0f, 180f * Time.deltaTime, 0f);
			}

			if(segundo >= 0.5f && billete[apagador].activeSelf){
				billete[apagador].SetActive(false);
			}
			if(segundo >= 1f){
				billete[apagador].transform.eulerAngles = new Vector3(0f, 180f, 0f);
			}else{
				billete[apagador].transform.eulerAngles += new Vector3(0f, 180f * Time.deltaTime, 0f);
			}

			yield return null;
		}
		GetComponent<Button>().interactable = true;
		foreach(GameObject lado in billete){
			for(int i = 0; i < lado.transform.childCount; i += 1){
				lado.transform.GetChild(i).GetComponent<Button>().interactable = true;
			}
		}
	}
}
