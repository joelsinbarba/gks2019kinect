﻿using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class SetBackgroundImage : MonoBehaviour 
{
	[Tooltip("GUI-texture used to display the color camera feed on the scene background.")]
	public Image backgroundImage;

	[Tooltip("Camera that will be set-up to display 3D-models in the Kinect FOV.")]
	public Camera foregroundCamera;

	[Tooltip("Use this setting to minimize the offset between the background image and model overlay.")]
	[Range(-0.1f, 0.1f)]
	public float adjustedCameraOffset = 0f;
	

	// variable to track the current camera offset
	private float currentCameraOffset = 0f;
	// initial camera position
	private Vector3 initialCameraPos = Vector3.zero;


	void Start()
	{
		KinectManager manager = KinectManager.Instance;
		
		if(manager && manager.IsInitialized())
		{
			KinectInterop.SensorData sensorData = manager.GetSensorData();

			if(foregroundCamera != null && sensorData != null && sensorData.sensorInterface != null)
			{
				foregroundCamera.fieldOfView = sensorData.colorCameraFOV;

				initialCameraPos = foregroundCamera.transform.position;
				Vector3 fgCameraPos = initialCameraPos;

				fgCameraPos.x += sensorData.faceOverlayOffset + adjustedCameraOffset;
				foregroundCamera.transform.position = fgCameraPos;
				currentCameraOffset = adjustedCameraOffset;
			}
		}
	}

	void Update()
	{
		KinectManager manager = KinectManager.Instance;
		if(manager && manager.IsInitialized())
		{
			if(backgroundImage != null && (backgroundImage.image == null))
			{
				backgroundImage.image = manager.GetUsersClrTex();
			}

			if(currentCameraOffset != adjustedCameraOffset)
			{
				// update the camera automatically, according to the current sensor height and angle
				KinectInterop.SensorData sensorData = manager.GetSensorData();
				
				if(foregroundCamera != null && sensorData != null)
				{
					Vector3 fgCameraPos = initialCameraPos;
					fgCameraPos.x += sensorData.faceOverlayOffset + adjustedCameraOffset;
					foregroundCamera.transform.position = fgCameraPos;
					currentCameraOffset = adjustedCameraOffset;
				}
			}
		}
	}

}
