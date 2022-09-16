using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Flags : MonoBehaviour
{
    [Tooltip("Menu Desplegable")]
    public TMP_Dropdown Dropdown;

    [Tooltip("Iconos de las banderas")]
    public Sprite[] flags;



    void Start()
    {
        Dropdown.ClearOptions();
        List<TMP_Dropdown.OptionData> flagItems = new List<TMP_Dropdown.OptionData>();
        foreach (var flag in flags)
        {
            var flagOption = new TMP_Dropdown.OptionData(flag);
            flagItems.Add(flagOption);
        }

        Dropdown.AddOptions(flagItems);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
