using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoalScript2 : MonoBehaviour
{
    public AudioClip GoalGet;
    AudioSource audio;
    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audio.PlayOneShot(GoalGet, 1F);
            SceneManager.LoadScene("SceneLevel2Complete");

        }
    }
}
