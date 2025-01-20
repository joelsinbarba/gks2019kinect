using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

/// <summary>
/// Background color image is component that displays the color camera feed on GUI texture, usually the scene background.
/// </summary>
public class BackgroundColorImage : MonoBehaviour 
{
	[Tooltip("GUI-texture used to display the color camera feed.")]
	public Image backgroundImage;


	void Update () 
	{
		KinectManager manager = KinectManager.Instance;

		if (manager && manager.IsInitialized()) 
		{
			if (backgroundImage != null && (backgroundImage.image == null)) 
			{
				backgroundImage.image = manager.GetUsersClrTex();
			}
		}	
	}
}
