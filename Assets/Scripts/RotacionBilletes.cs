using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RotacionBilletes : MonoBehaviour
{
	public GameObject CaraFrontal;
	public GameObject CaraTrasera;
	bool activarRotacion = true;
	public regresarBillete btnVolver;
	// Start is called before the first frame update
	void Start(){
		btnVolver.billete = CaraFrontal.GetComponent<RectTransform>();
		GetComponent<Button>().onClick.AddListener(() => StartCoroutine(rotador()));
	}

	IEnumerator rotador(){
		GetComponent<Button>().interactable = false;
		activarRotacion = !activarRotacion;

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
