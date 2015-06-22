using UnityEngine;
using System.Collections;

public class Creature : MonoBehaviour {
	public int hp = 200;
	private TextMesh hpText;
	private Creature collisionCreature;
	private bool died = false;

	// Use this for initialization
	void Start () {
		hpText = GetComponentInChildren<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		if(hpText)
			hpText.text = hp.ToString();
	}

	void OnCollisionEnter2D(Collision2D col){
		collisionCreature = col.gameObject.GetComponent<Creature>();

		if(collisionCreature && !died){
			collisionCreature.TakeDamage(Random.Range(5, 25));
		}
	}

	public void TakeDamage(int damage){
		hp -= damage;
		if(hp <= 0){
			hp = 0;

			Die();
		}
	}

	private void Die(){
		died = true;
		GetComponent<Animator>().Play("die");
	}
}
