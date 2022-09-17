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
    public Toggle EsTogle;
    public Toggle EnTogle;
    public Toggle FrTogle;

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
        Loadlanguage();
    }

    public void LocaleSelected(int index)
    {
        Debug.Log(index);
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
        ActiveLanguajeindex = index;

        WaitAndPrint();

        switch (ActiveLanguajeindex)
        {
            case 0:
                {
                    Savelanguage(0);
                }
                break;
            case 1:
                {
                    Savelanguage(1);
                }
                break;
            case 2:
                {
                    Savelanguage(2);
                }
                break;
        }
    }

    public void WaitAndPrint()
    {
        switch (ActiveLanguajeindex)
        {
            case 0:
                {
                    TmpMessage.text = "Lenguaje Cambiado";
                    EsTogle.isOn = true;
                    EnTogle.isOn = false;
                    FrTogle.isOn = false;
                }
                break;
            case 1:
                {
                    TmpMessage.text = "Changed Language";
                    EsTogle.isOn = false;
                    EnTogle.isOn = true;
                    FrTogle.isOn = false;
                }
                break;
            case 2:
                {
                    TmpMessage.text = "LLangue modifiée";
                    EsTogle.isOn = false;
                    EnTogle.isOn = false;
                    FrTogle.isOn = true;
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

    void Savelanguage(int data)
    {
        PlayerPrefs.SetInt("LanguajeIndex", data);
    }

    void Loadlanguage()
    {
        ActiveLanguajeindex = PlayerPrefs.GetInt("LanguajeIndex", ActiveLanguajeindex);
        WaitAndPrint();
        StartCoroutine(ChageLanguageStart());
    }

    IEnumerator ChageLanguageStart()
    {
        Debug.Log("Hello world!");
        yield return new WaitForSeconds(1);
        Debug.Log("bye world!");
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[ActiveLanguajeindex];
    }
}
