using UnityEngine;
using System.Collections;

public class OpenElement : MonoBehaviour {

	
	private Animator Opening;
	
	void Start () {
		Opening = GetComponent<Animator>();
	}

	
	void Update () {
     
		
	}

	public void OpenOrClose()
    {
		Opening.SetBool("isOpen", !Opening.GetBool("isOpen"));
	}
}
