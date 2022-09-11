using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backVisualizador3D : MonoBehaviour
{
    public GameObject[] carasDelanteras;
	public GameObject[] carasTraseras;
    private string prevScene;
    private GameObject Billete;
    private infoCarrier openChest;
    private billeteActual billeteUsar;
    void Start(){
        GetComponent<Button>().onClick.AddListener(() => accion());
        openChest = GameObject.Find("infoCarrier").GetComponent<infoCarrier>();
		billeteUsar = GameObject.Find("billeteActual").GetComponent<billeteActual>();
        openChest.regreso = 2;
        prevScene = openChest.lastScene;

        for(int i = 0; i < carasDelanteras.Length; i += 1){
			if(i != billeteUsar.billete){
				Destroy(carasDelanteras[i]);
				Destroy(carasTraseras[i]);
			}else if(openChest.billeteFace){
                Destroy(carasTraseras[i]);
                Billete = carasDelanteras[i];
            }else{
                Destroy(carasDelanteras[i]);
                Billete = carasTraseras[i];
            }
		}
        StartCoroutine(venida());
    }

    IEnumerator venida(){
        GetComponent<Animator>().Rebind();
		GetComponent<Animator>().Play("btnRotacionDesactivador1s");
        Vector3 truePosition = Billete.transform.position;
        Vector3 trueScale = Billete.transform.localScale;
        Vector3 trueRotation = Billete.transform.eulerAngles;

        Vector3 difPosition = truePosition - openChest.position;
        Vector3 difScale = trueScale - new Vector3(1f, 1f, 1f);
        Vector3 difRotation = trueRotation - new Vector3(0f, 0f, 0f);

        Billete.transform.position = openChest.position;
        Billete.transform.localScale = new Vector3(1f, 1f, 1f);
        Billete.transform.eulerAngles = new Vector3(0f, 0f, 0f);

        Billete.SetActive(true);
        for(int i = 0; i < Billete.transform.childCount; i += 1){
            Billete.transform.GetChild(i).gameObject.SetActive(false);
        }

        float tiempoTardar = 0.5f;
        float tiempoTardado = 0f;
        while(tiempoTardado < tiempoTardar){
            tiempoTardado += Time.deltaTime;
            if(tiempoTardado < tiempoTardar){
                Billete.transform.position += difPosition*(Time.deltaTime/tiempoTardar);
                Billete.transform.localScale += difScale*(Time.deltaTime/tiempoTardar);
                Billete.transform.eulerAngles += difRotation*(Time.deltaTime/tiempoTardar);
            }else{
                Billete.transform.position = truePosition;
                Billete.transform.localScale = trueScale;
                Billete.transform.eulerAngles = trueRotation;
            }
            yield return null;
        }

        for(int i = 0; i < Billete.transform.childCount; i += 1){
            Billete.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    void accion(){

    }
}
