using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExecuteRay : MonoBehaviour
{

	public Camera myCamera;
	// Use this for initialization
	void Start()
	{
		Ray ray = this.myCamera.ScreenPointToRay(Input.mousePosition);
		if (EventSystem.current.IsPointerOverGameObject())
		{

		}

		RaycastHit rcHit;
		if (Physics.Raycast(ray, out rcHit))
		{

		}

		PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
		pointerEventData.position = Input.mousePosition;
		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(pointerEventData, results);
		if (results.Count > 0){
			
		}

		Canvas canvas = null;
		canvas.GetComponent<GraphicRaycaster>().Raycast(pointerEventData, results);
		//(pointerEventData, results);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
