using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

public class ForegroundToImage : MonoBehaviour 
{

	void Update () 
	{
		BackgroundRemovalManager backManager = BackgroundRemovalManager.Instance;

		if(backManager && backManager.IsBackgroundRemovalInitialized())
		{
			Image guiTexture = GetComponent<Image>();

			if(guiTexture != null && guiTexture.image == null)
			{
				guiTexture.image = backManager.GetForegroundTex();
			}
		}
	}

}
