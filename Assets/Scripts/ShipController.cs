 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



[RequireComponent(typeof(Rigidbody))]
public class ShipController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed, minX, maxX, minY, maxY;
    public GameObject bullet;
    public GameObject ship;
    public Transform bulletOrigin;
    public float fireRate;
    private float nextShot;
    AudioSource speaker;
    public AudioClip plasmaSound;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        speaker = GetComponent<AudioSource>();
    }

    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextShot)
        {
            nextShot = Time.time + fireRate;
            speaker.PlayOneShot(plasmaSound);
            Instantiate(bullet, bulletOrigin.position, Quaternion.identity);
        }

        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);
        rb.velocity = movement * speed;
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, minX, maxX), Mathf.Clamp(rb.position.y, minY, maxY), 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(ship,0.1f);
            SceneManager.LoadScene("gameover");
        }
    }
}
