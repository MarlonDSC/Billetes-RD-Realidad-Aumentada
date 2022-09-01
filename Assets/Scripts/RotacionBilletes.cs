using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class RotacionBilletes : MonoBehaviour
{
	public GameObject[] carasDelanteras;
	public GameObject[] carasTraseras;
	private GameObject caraDelantera;
	private GameObject caraTrasera;
	[NonSerialized] public bool activarRotacion;
	public Animator btnVolver, titulo, btnAR;
	private infoCarrier openChest;
	// Start is called before the first frame update
	void Start(){
		GetComponent<Button>().onClick.AddListener(() => StartCoroutine(rotador()));

		openChest = GameObject.Find("infoCarrier").GetComponent<infoCarrier>();
		billeteActual billeteUsar = GameObject.Find("billeteActual").GetComponent<billeteActual>();

		activarRotacion = openChest.billeteFace;
		int activador = activarRotacion ? 0 : 1;
		int apagador = !activarRotacion ? 0 : 1;

		caraDelantera = carasDelanteras[billeteUsar.billete];
		caraTrasera = carasTraseras[billeteUsar.billete];

		for(int i = 0; i < carasDelanteras.Length; i += 1){
			if(i != billeteUsar.billete){
				Destroy(carasDelanteras[i]);
				Destroy(carasTraseras[i]);
			}
		}

		GameObject[] billete = {caraDelantera, caraTrasera};
		billete[activador].SetActive(true);
		billete[apagador].SetActive(false);

		if(openChest.regreso){
			Animator[] animations = {btnVolver, titulo, btnAR, GetComponent<Animator>()};
			foreach(Animator animacion in animations){
				animacion.Rebind();
			}

			btnVolver.Play("btnVolverback");
			titulo.Play("titleback");
			btnAR.Play("btnARback");
			GetComponent<Animator>().Play("btnARback");

			billete[activador].transform.eulerAngles = new Vector3(0f, -90f, 0f);
			StartCoroutine(regreso(activador));
		}else{
			Animator[] animations = {btnVolver, titulo, btnAR, GetComponent<Animator>()};
			foreach(Animator animacion in animations){
				animacion.Rebind();
			}

			btnVolver.Play("btnARback");
			titulo.Play("titleback");
			btnAR.Play("btnARback");
			GetComponent<Animator>().Play("btnARback");

			billete[activador].transform.eulerAngles = new Vector3(0f, 0f, 0f);
			StartCoroutine(venida(activador, billeteUsar.size, billeteUsar.position));
		}

		billete[apagador].transform.eulerAngles = new Vector3(0f, 180f, 0f);
	}

	IEnumerator venida(int lado, Vector2 size, Vector3 position){
		GameObject[] billete = {caraDelantera, caraTrasera};
		Vector2 trueSize = billete[lado].GetComponent<RectTransform>().sizeDelta;
		Vector3 truePosition = billete[lado].transform.position;
		ArrayList partes = new ArrayList();
		
		for(int i = 0; i < billete[lado].transform.childCount; i += 1){
			partes.Add(billete[lado].transform.GetChild(i).GetComponent<RectTransform>().sizeDelta);
			billete[lado].transform.GetChild(i).GetComponent<RectTransform>().sizeDelta = Vector2.zero;
			billete[lado].transform.GetChild(i).GetComponent<Button>().interactable = false;
		}
		
		Vector2 sizeDiferencia = trueSize - size;
		Vector3 positionDiferencia = truePosition - position;
		billete[lado].GetComponent<RectTransform>().sizeDelta = size;
		billete[lado].transform.position = position;

		float tiempo = 0f;
		while(tiempo < 0.5f){
			tiempo += Time.deltaTime;
			if(tiempo < 0.5f){
				billete[lado].GetComponent<RectTransform>().sizeDelta += sizeDiferencia*Time.deltaTime*2f;
				billete[lado].transform.position += positionDiferencia*Time.deltaTime*2f;
			}else{
				billete[lado].GetComponent<RectTransform>().sizeDelta = trueSize;
				billete[lado].transform.position = truePosition;
			}
			yield return null;
		}

		tiempo = 0f;
		while(tiempo < 0.1f){
			tiempo += Time.deltaTime;
			if(tiempo < 0.1f){
				for(int i = 0; i < billete[lado].transform.childCount; i += 1){
					billete[lado].transform.GetChild(i).GetComponent<RectTransform>().sizeDelta += (Vector2)partes[i] * (Time.deltaTime/0.1f);
				}
			}else{
				for(int i = 0; i < billete[lado].transform.childCount; i += 1){
					billete[lado].transform.GetChild(i).GetComponent<RectTransform>().sizeDelta = (Vector2)partes[i];
				}
			}
		}

		for(int i = 0; i < billete[lado].transform.childCount; i += 1){
			billete[lado].transform.GetChild(i).GetComponent<Button>().interactable = true;
		}
	}

	IEnumerator regreso(int lado){
		GameObject[] billete = {caraDelantera, caraTrasera};
		float segundos = 0f;
		for(int i = 0; i < billete[lado].transform.childCount; i += 1){
			billete[lado].transform.GetChild(i).GetComponent<Button>().interactable = false;
		}
		while(segundos < 0.5f){
			segundos += Time.deltaTime;
			if(segundos >= 0.5f){
                billete[lado].transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }else{
                billete[lado].transform.eulerAngles += new Vector3(0f, 90f*Time.deltaTime*2f, 0f);
            }
            yield return null;
		}
		for(int i = 0; i < billete[lado].transform.childCount; i += 1){
			billete[lado].transform.GetChild(i).GetComponent<Button>().interactable = true;
		}
	}

	IEnumerator rotador(){
		GetComponent<Animator>().Rebind();
		GetComponent<Animator>().Play("btnRotacionDesactivador1s");
		activarRotacion = !activarRotacion;
		openChest.billeteFace = activarRotacion;

		int activador = activarRotacion ? 0 : 1;
		int apagador = !activarRotacion ? 0 : 1;

		GameObject[] billete = {caraDelantera, caraTrasera};
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
		foreach(GameObject lado in billete){
			for(int i = 0; i < lado.transform.childCount; i += 1){
				lado.transform.GetChild(i).GetComponent<Button>().interactable = true;
			}
		}
	}
}