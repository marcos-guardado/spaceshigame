using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Asteroid : MonoBehaviour
{

    public Rigidbody rb;
    public float speed;
    public Slider healthSlider;
    public int health;
    public Collider collider; 
    public GameObject asteroid, canvas, explosion;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    void Start()
    {
        this.healthSlider.maxValue = health;
        this.healthSlider.minValue = 0;
        this.healthSlider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x - speed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlasmaBullet"))
        {
            health -= 10;
            healthSlider.value = health;
        }

        if(health <= 0)
        {
            health = 0;
            collider.enabled = false;
            Explode();
        }

        if(other.CompareTag("Player"))
        {
            Explode();
        }
    }

    void Explode()
    {
        asteroid.SetActive(false);
        canvas.SetActive(false);
        explosion.SetActive(true);
        Destroy(asteroid, 0.5f);
    }
}
