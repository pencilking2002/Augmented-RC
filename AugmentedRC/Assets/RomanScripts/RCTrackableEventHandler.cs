using UnityEngine;
using System.Collections;

// Roman's event handler for tracking objects
public class RCTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
	// Colors for fading in / out
	private Color colorStart = new Color (1f, 1f, 1f, 0.0f);
	private Color colorEnd = Color.white;
	private float duration = 10.0f;
	private bool canFadeIn = false;
	
	private Renderer[] rendererComponents;
	
	private TrackableBehaviour mTrackableBehaviour;
	
	void Start()
	{
		rendererComponents = GetComponentsInChildren<Renderer>(true);
		
//		foreach (Renderer rend in rendererComponents)
//			rend.material.color = colorStart;
		
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}
	
	void Update ()
	{
		if (canFadeIn == true)
		{
			rendererComponents = GetComponentsInChildren<Renderer>(true);
			
			foreach (Renderer rend in rendererComponents)
			{	
			
			}
		}
	}
	
	// When the target's state changes, this function runs
	public void OnTrackableStateChanged (TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
	{
//		if (newStatus == TrackableBehaviour.Status.DETECTED)
//		{
//			print ("color is supposed to fade in");
//			OnTrackingDetected ();
//		}
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED ||
		    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			print ("ROMAN: Object has been tracked. The status is:" + newStatus);
			canFadeIn = true;
			//OnTrackingFound();
			//FadeIn ();
		}
		else
		{
			//OnTrackingLost();
		}
	}
	
	// Access all the game Objects attached to the Target
	// and fade in the color
	private void FadeIn ()
	{
		
		rendererComponents = GetComponentsInChildren<Renderer>(true);
		
		foreach (Renderer rend in rendererComponents)
		{	
			print (rend.material.color);
			for (float i = 0.0f; i < duration; i+= 0.01f)
			{
				print ("Fading color in");
				rend.material.color = Color.Lerp (colorStart, colorEnd, i/duration);
			}
		}
	}
	
	private void OnTrackingFound ()
	{
		Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
		Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
		
		// Enable rendering:
		foreach (Renderer component in rendererComponents)
		{
			component.enabled = true;
		}
		
		// Enable colliders:
		foreach (Collider component in colliderComponents)
		{
			component.enabled = true;
		}
		
		Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
	}
	
	
	private void OnTrackingLost()
	{
		rendererComponents = GetComponentsInChildren<Renderer>(true);
		Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
		
		// Disable rendering:
		foreach (Renderer component in rendererComponents)
		{
			component.enabled = false;
		}
		
		// Disable colliders:
		foreach (Collider component in colliderComponents)
		{
			component.enabled = false;
		}
		
		Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
	}
	
}
