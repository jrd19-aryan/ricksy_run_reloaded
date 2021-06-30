using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackRating : MonoBehaviour
{
	public void Rate()
	{
		// "market" works for android
		Application.OpenURL("market://details?id=package_name");
	}

	public void More()
	{
		Application.OpenURL("https://play.google.com/store/apps/developer?id=CGL-IIT%28KGP%29&hl=en&gl=US");
	}

	public void Feedback()
	{
		Application.OpenURL("mailto:cglabiitkgp@gmail.com");
	}
}
