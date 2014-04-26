using UnityEngine;

public class FadeIn : MonoBehaviour {
	
	public float duration = 1f;
	public float transparent = 0f;
	public float opaque = 1f;
	
	void Start ()
	{
	
	}
	void OnMouseDown ()
	{
		FadeObjectIn ();
	}
	
	void FadeObjectIn ()
	{
		print ("Fading color in");
		
		// Fade GO in from 0 to 1, but it doesn't work?
		LeanTween.alpha(gameObject, opaque, duration);
	}
	
}