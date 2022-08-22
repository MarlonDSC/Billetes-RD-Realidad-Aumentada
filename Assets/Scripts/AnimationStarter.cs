using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationStarter : MonoBehaviour
{
	public Animator anim;
	public Button Back;

	// Start is called before the first frame update
	void Start()
	{

		Back.onClick.AddListener(encenderAnimacionBack);

	}

	void encenderAnimacionBack(){
		anim.Play("SmallToBig");
	}
}
