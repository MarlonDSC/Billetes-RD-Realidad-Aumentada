using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using Vuforia.UnityRuntimeCompiled;

public class CargarVuforia : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
	    VuforiaApplication.Instance.Initialize();
	    //GetComponent<VuforiaBehaviour>().enabled = true;
	    //GetComponent<DefaultInitializationErrorHandler>().enabled = true;
	 
    }

    // Update is called once per frame
    void Update()
    {
	  
    }
}
