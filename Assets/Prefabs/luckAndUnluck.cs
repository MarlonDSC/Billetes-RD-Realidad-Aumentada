using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class luckAndUnluck : MonoBehaviour
{
    public GameObject arCamera;
    public GameObject emptyPadre;
    public Button botonLock, botonUnlock;

    public GameObject prefab;

    public GameObject [] imageTarget;


    private Vector3 PositonModel;
    private Quaternion RotationModel;
    private bool Estado = true;

    private void Start()
    {
        botonLock.onClick.AddListener(apagarEncenderElementos);
        botonUnlock.onClick.AddListener(apagarEncenderElementos);
    }

    void apagarEncenderElementos()
    {
        for (var i = 0; i < imageTarget.Length; i++)
        {
            if (imageTarget[i].activeSelf)imageTarget[i].SetActive(false);

            else imageTarget[i].SetActive(true);
        }


    }
  


}
