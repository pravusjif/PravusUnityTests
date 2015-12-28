using UnityEngine;
using System.Collections;

public class CharacterJumpController : MonoBehaviour
{
    public float jumpForce = 100f;

    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

	void Update () {
	    if(Input.GetKeyDown(KeyCode.Space))
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
	}
}
