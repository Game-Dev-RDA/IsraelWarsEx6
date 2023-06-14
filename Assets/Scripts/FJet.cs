using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FJet : MonoBehaviour {

	[SerializeField] string triggeringTag;
	public GameObject explosion;

	public float speed = 1f;
	public float rotateSpeed = 200f;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		Vector3 mousePosition = Input.mousePosition;
		//2D
		mousePosition.z = 0;
		Vector3 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
		mousePosition.x -= objectPosition.x;
		mousePosition.y -= objectPosition.y;

		float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotateSpeed));

		Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		targetPosition.z = 0; //2D
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
	}

	    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag && enabled) {
			Instantiate (explosion, rb.position, Quaternion.identity);
            Destroy(this.gameObject);
			SceneManager.LoadScene("Restart");
			
        }
	// 	void OnTriggerEnter2D ()
	// {
	// 	Instantiate (explosion, rb.position, Quaternion.identity);
	// 	Destroy(gameObject);
	// }
		}
}