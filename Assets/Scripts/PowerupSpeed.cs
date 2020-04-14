using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpeed : MonoBehaviour
{
    public GameObject player;

    public GameObject gc;

    public GameObject speedPowerup;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedPowerup") && player.GetComponent<PlayerController>().GetSpeed() < player.GetComponent<PlayerController>().GetTwoSpeed())
        {
            StartCoroutine("Speedup");
        }
    }

    IEnumerator Speedup()
    {
        player.GetComponent<PlayerController>().SetSpeed( 2.0f * player.GetComponent<PlayerController>().GetSpeed() );
        yield return new WaitForSeconds(5.0f);
        player.GetComponent<PlayerController>().SetSpeed( 0.5f * player.GetComponent<PlayerController>().GetSpeed() );
    }
}
