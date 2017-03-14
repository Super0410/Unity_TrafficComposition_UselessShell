using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(BoxCollider))]
public class CarMovement : MonoBehaviour
{
	public bool isHorizontal = false;
	public float preSpeed = 60f;
	public float curMoveSpeed = 60f;
	public float curAcceleration = 10f;

	public LayerMask carWontStopLayer;

	Rigidbody rb;

	bool isToStop;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();	

		curMoveSpeed = preSpeed;

		LightController._instance.OnMoveHandler += onResetSpeed;
	}

	void FixedUpdate ()
	{
//		rb.AddForce (transform.forward * Time.deltaTime * curMoveSpeed * 10);
		rb.velocity = transform.forward * Time.deltaTime * curMoveSpeed * 10;

		if (isHitFrontCar)
			return;

		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;
		Physics.Raycast (ray, out hit, 10f);
		if (hit.collider != null) {
			CarMovement frontCarMovement = hit.collider.GetComponent<CarMovement> ();
			if (frontCarMovement != null && frontCarMovement.isHorizontal == this.isHorizontal) {
//				curMoveSpeed = frontCarMovement.curMoveSpeed;
				isToStop = true;
			}
		}
	}

	bool isHitFrontCar = false;

	void Update ()
	{
//		if (isHitFrontCar)
//			return;

		if (isToStop && curMoveSpeed > 0)
			curMoveSpeed -= curAcceleration * Time.deltaTime;
		else if (!isToStop && curMoveSpeed < preSpeed)
			curMoveSpeed += curAcceleration * Time.deltaTime;

		curMoveSpeed = Mathf.Clamp (curMoveSpeed, 0, preSpeed);
	}

	void onResetSpeed (bool isHorizontal)
	{
		if (isHorizontal == this.isHorizontal) {
			isToStop = false;//curMoveSpeed = preSpeed;

			isHitFrontCar = true;
		}
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "CarEnd")
			Destroy (gameObject);

		if (collider.tag == "CarWait")
			isToStop = true;//curMoveSpeed = 0f;

		if (collider.tag == "Player") {
			gameObject.layer = 9;
		}
	}


	void OnDestroy ()
	{
		LightController._instance.OnMoveHandler -= onResetSpeed;
	}
}
