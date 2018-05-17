using UnityEngine;
using System.Collections;

public class AlphaManager : MonoBehaviour
{
	void Update ()
	{
		Vector3 cordinates = Manager.instance.GameCamera.WorldToViewportPoint (transform.position);
		//Debug.Log (Manager.instance.GameCamera.WorldToScreenPoint (transform.position));
		if (cordinates.x > 1 || cordinates.x < 0 || cordinates.y < 0) {
			Destroy (this.gameObject);
		}
	}
}
