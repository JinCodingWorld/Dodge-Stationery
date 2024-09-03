using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book: MonoBehaviour
{
    public float speed = 8f;
    Rigidbody rb;

    public GameObject effect;

    public AudioClip sound1; // 사운드 파일 : 폭탄 터지는 거
    //public AudioClip sound2;

    public AudioSource audio; 


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController pc = other.GetComponent<PlayerController>();
            if (pc != null)
            {
                audio.PlayOneShot(sound1);

                Instantiate(effect, transform.position, Quaternion.identity); // Quaternion 회전 값이 없다는 뜻 
                pc.Die();
            }
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

        Destroy(gameObject, 5f);
    }

}
