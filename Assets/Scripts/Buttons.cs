using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
	public Button boton_billete50;
	public Button boton_billete100;
	public Button boton_billete200;
	public Button boton_billete500;
	public Button boton_atras;
	public Button boton_reverse;
	public Image imagenBillete;
	public GameObject panelCarusel;
	public GameObject panelBillete;
	
    // Start is called before the first frame update
    void Start()
    {
	    boton_billete50.onClick.AddListener(carga_billete50);
	    boton_billete100.onClick.AddListener(carga_billete100);
	    boton_billete200.onClick.AddListener(carga_billete200);
	    boton_billete500.onClick.AddListener(carga_billete500);
	    boton_atras.onClick.AddListener(atras);
	    carga_panel(panelCarusel);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
	void carga_panel(GameObject estado)
	{
		panelCarusel.SetActive(false);
		panelBillete.SetActive(false);


		estado.SetActive(true);

	}
	void carga_billete50()
	{
		carga_panel(panelBillete);
		imagenBillete.sprite = Resources.Load<Sprite>("50_a");

	}
	void carga_billete100()
	{
		carga_panel(panelBillete);
		imagenBillete.sprite = Resources.Load<Sprite>("100_a");
	}
	
	void carga_billete200()
	{
		carga_panel(panelBillete);
		imagenBillete.sprite = Resources.Load<Sprite>("200_a");

	}
	void carga_billete500()
	{
		carga_panel(panelBillete);
		imagenBillete.sprite = Resources.Load<Sprite>("500_a");
	}
	
	void atras()
	{
		carga_panel(panelCarusel);
	}
}
