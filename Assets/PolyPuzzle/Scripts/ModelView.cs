using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelView : MonoBehaviour
{
	[SerializeField] Transform[] children;

	Quaternion correctRotation;
	[SerializeField] Camera cam;
	[SerializeField] float scaler;
	[SerializeField] Vector2 range;
	
	float[] randomArray;
	
	void Start()
	{
		Vector3 dir = transform.position - cam.transform.position;
		correctRotation = Quaternion.Euler(-dir.normalized * scaler);
		randomArray = new float[children.Length];
		
		for (int i = 0; i < children.Length; i++)
		{
			randomArray[i] = Random.Range(range.x, range.y);
		}
		
	}
	
	void Update()
	{
		Vector3 dir = transform.position - cam.transform.position;
		Quaternion currentRotation = Quaternion.Euler(-dir.normalized * scaler);
		
		float angle = Quaternion.Angle(currentRotation, correctRotation) / 180f;
		
		if (transform.rotation != correctRotation)
		{
			for(int i = 0; i < children.Length; i++)
			{
				children[i].localRotation = Quaternion.Inverse(currentRotation * Quaternion.Euler(0,angle * randomArray[i], 0)) * correctRotation;
			}
		}
		
		// transform.LookAt(cam.transform.position, Vector3.up);
	}
}
