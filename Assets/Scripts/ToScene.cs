using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToScene : MonoBehaviour {

	private int currentSceneIndex;

	public void LoadScene() 
	{
    
		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
		SceneManager.LoadScene(0);
   
	}
}
