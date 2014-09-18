using UnityEngine;
using System.Collections;

public class AutoTypeText : MonoBehaviour {
	
	private string text;
  	public float letterPause = 0.2f;
	public AudioSource sound;
	
	// Use this for initialization
	void Start () {
		text = guiText.text;
		guiText.text = "";
		StartCoroutine(TypeText());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
  
	private IEnumerator TypeText() {
		foreach(char letter in text)
		{
			guiText.text += letter;
			if(sound)
			{
				sound.Play();
			}
			
			yield return new WaitForSeconds(letterPause);
		}			
	}
}
