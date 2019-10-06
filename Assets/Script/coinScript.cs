using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour {
	private float speed = 5.0f;

	void Update () {
		transform.Rotate (Vector3.down * 90 * speed* Time.deltaTime);
	}
}
