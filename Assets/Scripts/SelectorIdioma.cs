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

    //[Tooltip("Iconos de las banderas")]
    //public Sprite[] flags;

   public int ActiveLanguajeindex;
    void Start()
    {
        Loadlanguage();
        changeTitleLanguages();

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
                    
                    EsTogle.isOn = true;
                    EnTogle.isOn = false;
                    FrTogle.isOn = false;
                    TmpMessage.text = "Lenguaje Modificado";
                }
                break;
            case 1:
                {
                    
                    EsTogle.isOn = false;
                    EnTogle.isOn = true;
                    FrTogle.isOn = false;
                    TmpMessage.text = "Changed Language";
                }
                break;
            case 2:
                {
                    
                    EsTogle.isOn = false;
                    EnTogle.isOn = false;
                    FrTogle.isOn = true;
                    TmpMessage.text = "LLangue modifi?e";
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
        
        yield return new WaitForSeconds(1);
       
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[ActiveLanguajeindex];
    }

    public void changeTitleLanguages()
    {
        switch (ActiveLanguajeindex)
        {
            case 0:
                {
                    Savelanguage(0);
                    TmpMessage.text = "IDIOMAS";
                }
                break;
            case 1:
                {
                    Savelanguage(1);
                    TmpMessage.text = "LANGUAGES";
                }
                break;
            case 2:
                {
                    Savelanguage(2);
                    TmpMessage.text = "LANGUES";
                }
                break;
        }
    }
}
