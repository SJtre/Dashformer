using UnityEngine;
using System.Collections;

public class DeathCollision : MonoBehaviour {

    private Vector3 originalPos;
    public AudioSource deathSound;
    // Use this for initialization
    void Start () {
        originalPos = transform.position;
        AudioSource[] audios = GetComponents<AudioSource>();
        deathSound = audios[2];
     }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Hazard")
        {
            Debug.Log("You Died");
            deathSound.Play();
            transform.position = originalPos;
            this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("You Died");
            deathSound.Play();
            transform.position = originalPos;
            this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }

    }
}
