using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DropMenu : MonoBehaviour
{
    [Tooltip("Menu Desplegable")]
    public TMP_Dropdown Dropdown;

    [Tooltip("Iconos de las banderas")]
    public Sprite[] flags;

    //public int DropdownValue;

    [Tooltip("Panel de lenguajes")]
    public GameObject Panel_Languajes;

    [Tooltip("Panel de Ayuda")]
    public GameObject Panel_Ayuda;


    void Start()
    {
        Dropdown.GetComponent<TMP_Dropdown>();
        //Dropdown.ClearOptions();
        List<TMP_Dropdown.OptionData> flagItems = new List<TMP_Dropdown.OptionData>();
        List<string> emptyOption = new List<string> { "Option 3" };
        foreach (var flag in flags)
        {
            var flagOption = new TMP_Dropdown.OptionData(flag);
            flagItems.Add(flagOption);
        }

        Dropdown.AddOptions(flagItems);
        Dropdown.AddOptions(emptyOption);

        Dropdown.value = 2;
        Dropdown.onValueChanged.AddListener(delegate { DropdownValueChangeFuntion(Dropdown); });

    }

    public void DropdownValueChangeFuntion(TMP_Dropdown Value)
    {

        switch (Value.value)
        {
            case 0:
                {
                    Panel_Ayuda.SetActive(true);
                    Dropdown.value = 2;
                }
                break;

            case 1:
                {
                    Panel_Languajes.SetActive(true);
                    Dropdown.value = 2;
                }
                break;
        };
        //Debug.Log(Value.value);
    }
}
