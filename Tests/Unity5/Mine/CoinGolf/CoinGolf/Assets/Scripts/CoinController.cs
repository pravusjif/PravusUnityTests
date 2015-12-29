using UnityEngine;
using System.Collections.Generic;

public class CoinController : MonoBehaviour
{
    public Vector3 shootingDirection = Vector3.zero;
    public float shootingForce = 0f;
    public float maxShootingForce = 20f;

    Vector2 currentTouchPosition;
    Vector2 lastTouchPosition;
    Vector2 initialTouchPosition;
    bool startedAiming = false;

    Rigidbody objectRigidBody = null;
    List<Touch> touchesList = new List<Touch>();

    void Start()
    {
        objectRigidBody = GetComponent<Rigidbody>();
    }

	void Update ()
	{
	    touchesList = InputHelper.GetTouches();

        if (touchesList.Count > 0)
	    {
            #if UNITY_EDITOR
            Ray touchRay = Camera.main.ScreenPointToRay(touchesList[0].position);
            Debug.DrawRay(touchRay.origin, touchRay.direction * 30, Color.magenta);
            #endif

            currentTouchPosition = touchesList[0].position;

	        if (startedAiming)
	        {
	            if (touchesList[0].phase == TouchPhase.Ended || touchesList[0].phase == TouchPhase.Canceled)
	                ShootCoin();
	            else
	            {
	                CalculateShootingForce();
                    CalculateShootingDirection();
	            }
	        }

	        lastTouchPosition = currentTouchPosition;
	    }
	}

    void CalculateShootingForce()
    {
        if (Vector2.Distance(lastTouchPosition, initialTouchPosition) < Vector2.Distance(currentTouchPosition, initialTouchPosition))
            shootingForce += touchesList[0].deltaPosition.magnitude;
        else
            shootingForce -= touchesList[0].deltaPosition.magnitude;

        if (shootingForce > maxShootingForce)
            shootingForce = maxShootingForce;
        else if (shootingForce < 0)
            shootingForce = 0;
    }

    void CalculateShootingDirection()
    {
        shootingDirection.x = (currentTouchPosition - initialTouchPosition).x;
        shootingDirection.z = (currentTouchPosition - initialTouchPosition).y;
    }

    void OnMouseDown()
    {
        startedAiming = true;
        initialTouchPosition = InputHelper.GetTouches()[0].position;
    }

    void ShootCoin()
    {
        startedAiming = false;

        shootingDirection.y = 0;
        objectRigidBody.AddForce(shootingDirection.normalized * shootingForce, ForceMode.Impulse);

        shootingForce = 0;
    }
}
