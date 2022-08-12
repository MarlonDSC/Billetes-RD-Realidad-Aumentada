using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotacionBilletes : MonoBehaviour
{
	[Header ("Caras de los billetes")]
	public GameObject CaraFrontal;
	public GameObject CaraTrasera;
	
	[Header ("Variables para animacion de giro")]
	public bool  activarRotacion; //Sirve para conocer en cual dirrecion girar
	public int	velocidadRotacion = 3;
	
	[Header ("Boton de Giro")]
	public Button boton_reverse;
	// Start is called before the first frame update
	void Start()
	{
		
		CaraTrasera.SetActive(false);
		boton_reverse.onClick.AddListener(Activargiro);

	}

	// Update is called once per frame
	void Update()
	{
		//Variables para capturar los ejes de los objetos(Billetes)
		int	anguloFrontal = (int)CaraFrontal.transform.rotation.eulerAngles.y;
		int	anguloTrasero = (int)CaraTrasera.transform.rotation.eulerAngles.y;
		Debug.Log(anguloTrasero);
		
		//Giro Frontal
		if (activarRotacion == true && anguloFrontal < 180)
		{
			CaraFrontal.transform.Rotate(0, velocidadRotacion,0);		
		}
		else if (activarRotacion == false && anguloFrontal > 0)
		{
			CaraFrontal.transform.Rotate(0, -velocidadRotacion,0);				
		}
		
		//Giro de la cara Trasera
		if (activarRotacion == true && anguloTrasero < 357)
		{
	
			CaraTrasera.transform.Rotate(0, velocidadRotacion,0);		
		}
		else if (activarRotacion == false && anguloTrasero > 180)
		{
			CaraTrasera.transform.Rotate(0, -velocidadRotacion,0);				
		}
		
		
		if (anguloFrontal == 90)
		{

			switch (activarRotacion)
			{
			case true:
				CaraFrontal.SetActive(false);
				CaraTrasera.SetActive(true);
				break;
			case false:
				CaraTrasera.SetActive(false);
				CaraFrontal.SetActive(true);
				break;
			}
		}
	}
	void Activargiro(){
		
		if (activarRotacion ==true)
		{
			activarRotacion = false;
			
		}
		else{
			activarRotacion = true;
		}
		
	}
}
