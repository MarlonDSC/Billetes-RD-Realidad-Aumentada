using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using TMPro;
public class SelectorIdioma : MonoBehaviour
{
    public Canvas Pantalla;
    public bool Panelstade;

    [Tooltip("Canvas alerta")]
    public GameObject CavasMesagge;

    [Tooltip("Mensagge alerta")]
    public Text TmpMessage;

    [Tooltip("Iconos de las banderas")]
    public Sprite[] flags;

    public int ActiveLanguajeindex;
    void Start()
    {
       
    }

    public void LocaleSelected(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
        ActiveLanguajeindex = index;
        WaitAndPrint();
    }

    public void WaitAndPrint()
    {
        switch (ActiveLanguajeindex)
        {
            case 0:
                {
                    TmpMessage.text = "Lenguaje Cambiado";               
                }
                break;
            case 1:
                {
                    TmpMessage.text = "Changed Language";

                }
                break;
            case 2:
                {
                    TmpMessage.text = "LLangue modifiée";
                }
                break;
        }
    }

    public void panelStade(bool Panelstade)
    {
        if(Panelstade == true)
        {
            CavasMesagge.SetActive(true);
        }
        else
        {
            CavasMesagge.SetActive(false);
        }
    }
}
