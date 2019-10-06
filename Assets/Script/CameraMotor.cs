using UnityEngine;

public class CameraMotor : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	public float smoothSpeed = 0.125f;

	private void LateUpdate()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed);

		transform.position = smoothPosition;
		transform.LookAt (target);
	}
}
