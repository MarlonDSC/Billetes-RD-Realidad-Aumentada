using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startCondition : MonoBehaviour
{
	public Animator animacionLogo;
	public GameObject ScreenPop;
	public GameObject CanvasInfo;
	public Button Next;
	public Button YES;
	public Button NOT;
	public int infoScreen;
	public GameObject animacion;
	
    // Start is called before the first frame update
    
	// Awake is called when the script instance is being loaded.
	void Awake()
	{
		LoadData();
	}
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	void Update()
	{
		//Debug.Log(animacionLogo.GetCurrentAnimatorStateInfo(0).normalizedTime);
		if (animacion.active == false && infoScreen == 0)
		{
			SceneManager.LoadScene("Scroll_Snap");
		}
	}
	void Start()
	{
		//Las funciones DeleteAll y Save sirven para resetear la eleccion de la pantalla de informacion, correr la APP y volver a comentar para no tener fallos;
		//PlayerPrefs.DeleteAll();
		//PlayerPrefs.Save();
		
	    if (infoScreen == 0){
	    	CanvasInfo.SetActive(false);
	    	//ScreenPop.SetActive(false);
	    }
	    
	    Next.onClick.AddListener(POP);
	    YES.onClick.AddListener(()=>SaveData(1));
	    NOT.onClick.AddListener(()=>SaveData(0));
	    
	    
    }

	void SaveData(int data){
		PlayerPrefs.SetInt("Data_Screen", data);
		CanvasInfo.SetActive(false);
		ScreenPop.SetActive(false);
	}
	
	void LoadData(){
		
		infoScreen = PlayerPrefs.GetInt("Data_Screen",1);
	}
	void POP(){
		ScreenPop.SetActive(true);
	}
	

	
}
