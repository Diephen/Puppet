﻿using UnityEngine;
using System.Collections;

namespace Util{
	public class PuppetDrag : MonoBehaviour {
		private bool dragging = false;
		private float distance;

		void OnMouseDown()
		{
			distance = Vector3.Distance(transform.position, Camera.main.transform.position);
			dragging = true;
		}

		void OnMouseUp()
		{
			dragging = false;
		}

		void Update()
		{
			if (dragging)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				Vector3 rayPoint = ray.GetPoint(distance);
                rayPoint.z = transform.position.z;
				transform.position = rayPoint;
			}
		}
	}

	
}

