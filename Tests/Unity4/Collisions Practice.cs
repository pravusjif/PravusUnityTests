-----------------------------------------------------------
public bool CheckCollision(GameObject obj1, GameObject obj2) // Spheric Collision Check
{
	Vector3 actualDistance = obj1.transform.position - obj2.transform.position
	float minDistance = obj1.Radius + obj2.Radius;
	
	if( actualDistance.sqrMagnitude < Math.Pow(minDistance, 2)) // There's Collision
	{
		float penetration = minDistance - actualDistance.magnitude;
	
		obj1.OnCollision(obj2, penetration);
		obj2.OnCollision(obj1, penetration);
	}	
}

---------------------------------------------------------------
private void OnCollision( GameObject collisionObject, float penetration )
{
	// Check from which direction the collisionObject collided and move this object in the other direction.
	Vector3 position = transform.position;
	
	if(position.x < collisionObject.transform.position.x) // collisionObject comes from the RIGHT
	{
		position.x -= penetration;
	}
	else // collisionObject comes from the LEFT
	{
		position.x += penetration;
	}
	
	if(position.y < collisionObject.transform.position.y) // collisionObject comes ABOVE
	{
		position.y -= penetration;
	}
	else // collisionObject comes from BELOW
	{
		position.y += penetration;
	}
	
	speed *= -1;
	
	transform.position = position;
}

-------------------------------------------------------------------

// Box collision
public bool CheckCollision(GameObject obj1,GameObject obj2)
{
	minYDistance = (obj1.transform.localScale.y + obj1.height / 2) + (obj2.transform.localScale.y + obj2.height / 2) ;
	minXDistance = (obj1.transform.localScale.x + obj1.width / 2) + (obj2.transform.localScale.x + obj2.width / 2) ;
	
	actualYDistance = Math.Abs(obj1.transform.position.y - obj2.transform.position.y);
	actualXDistance = Math.Abs(obj1.transform.position.x - obj2.transform.position.x);
	
	if( actualXDistance < minXDistance &&  actualYDistance < minYDistance )
	{
		// THEY COLLIDE
		
		xPenetration = minXdistance - actualXDistance;
		yPenetration = minYdistance - actualYDistance;
		
		obj1.OnCollide(obj2, xPenetration, yPenetration);
		obj2.OnCollide(obj2, xPenetration, yPenetration);
	}
}
