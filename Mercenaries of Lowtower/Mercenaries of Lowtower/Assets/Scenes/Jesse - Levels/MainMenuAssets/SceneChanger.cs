using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour {

	public Animator Anim;
	public Image Img;

	public void StartMenu()
	{
		//SceneManager.LoadScene ("Scene2");
		StartCoroutine(Fade());

	}


	IEnumerator Fade()
	{
		Anim.SetBool ("Fade", true);
		yield return new WaitUntil(()=>Img.color.a==1);
		SceneManager.LoadScene ("Jesse_Tutorial_Level");
	}


}
