using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

/// <summary>
/// Background depth image is component that displays the depth camera image on GUI texture, usually the scene background.
/// </summary>
public class BackgroundDepthImage : MonoBehaviour 
{
	[Tooltip("GUI-texture used to display the depth image.")]
	public Image backgroundImage;

	[Tooltip("Camera that will be used to display the background image.")]
	public Camera backgroundCamera;


	void Update () 
	{
		KinectManager manager = KinectManager.Instance;

		if (manager && manager.IsInitialized()) 
		{
			if (backgroundImage != null && (backgroundImage.image == null)) 
			{
				backgroundImage.image = manager.GetUsersLblTex();

				KinectInterop.SensorData sensorData = manager.GetSensorData();
				if (sensorData != null && sensorData.sensorInterface != null && backgroundCamera != null) 
				{
					// get depth image size
					int depthImageWidth = sensorData.depthImageWidth;
					int depthImageHeight = sensorData.depthImageHeight;

					// calculate insets
					Rect cameraRect = backgroundCamera.pixelRect;
					float rectHeight = cameraRect.height;
					float rectWidth = cameraRect.width;

					if (rectWidth > rectHeight)
						rectWidth = rectHeight * depthImageWidth / depthImageHeight;
					else
						rectHeight = rectWidth * depthImageHeight / depthImageWidth;

					float deltaWidth = cameraRect.width - rectWidth;
					float deltaHeight = cameraRect.height - rectHeight;

					float leftX = deltaWidth / 2;
					float rightX = -deltaWidth;
					float bottomY = -deltaHeight / 2;
					float topY = deltaHeight;

					backgroundImage.contentRect.Set(leftX, bottomY, rightX, topY); //(x,y, width,height) = new Rect(leftX, bottomY, rightX, topY);
				}
			}
		}	
	}
}
