using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	public float lookY;
	public float lookZ;
	public Vector2 margin, smoothing;
	public BoxCollider2D bounds;
	private Vector3 _min, _max;

	public bool IsFollowing { get; set; }
		
	// Use this for initialization
	private void Start ()
	{
		_min = bounds.bounds.min;
		_max = bounds.bounds.max;
		IsFollowing = true;
	}
		
		
	// Update is called once per frame
	private void Update ()
	{
		var x = transform.position.x;
		var y = transform.position.y;

		if (target != null)
			if (IsFollowing) {
				//Bound X, select target position x
				if (Mathf.Abs (x - target.position.x) > margin.x) {
					//x = Mathf.Lerp(x, target.position.x, smoothing.x * Time.deltaTime);
					//x = Mathf.Lerp(x, target.position.x, smoothing.x);
					x = target.position.x + 5f;
				}

				//Bound Y select target position y
				if(Mathf.Abs (y - target.position.y) > margin.y) {
					//y = Mathf.Lerp(y, target.position.y, smoothing.y * Time.deltaTime);
					y = target.position.y;
				}
			}

		var cameraHalfWidth = Camera.main.orthographicSize * ((float)Screen.width / Screen.height);

		x = Mathf.Clamp (x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
		y = Mathf.Clamp (x, _min.y + Camera.main.orthographicSize, _max.y - Camera.main.orthographicSize);

		transform.position = new Vector3 (x, y, lookZ);
		//transform.position = new Vector3(target.transform.position.x + 4, lookY, lookZ);
	}
}