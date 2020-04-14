using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float twoTimesOriginalSpeed;
    public float tilt;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    public AudioSource audioSource;
    public AudioClip shotSFX;
    public AudioSource audioSource2;
    public AudioClip audioClip2;

    private Rigidbody rb;

    private void Start()
    {
        twoTimesOriginalSpeed = speed * 2;
        rb = GetComponent<Rigidbody>();
        audioSource.clip = shotSFX;
        audioSource2.clip = audioClip2;
    }

    void Update()
    {
        if ( ( Input.GetButton("Fire1") || Input.GetButton("Jump") ) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audioSource.Play();
        }
            
    }

    public void DestroyPlayer()
    {
        Destroy(this);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
             Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
             0.0f,
             Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public float GetTwoSpeed()
    {
        return twoTimesOriginalSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedPowerup"))
        {
            audioSource2.Play();
            other.gameObject.SetActive(false);
        }
    }

    }