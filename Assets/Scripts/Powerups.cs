using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public GameObject shield;

    public GameObject gc;

    public GameObject shieldPowerup;

    private bool isShieldActive;

    void Start()
    {
        isShieldActive = false;
    }

    void Update()
    {
        isShieldActive = !shieldPowerup.activeSelf;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ShieldPowerup") && isShieldActive == false)
        {
            shield.SetActive(true);
            other.gameObject.SetActive(false);
            gc.GetComponent<GameController>().activateShieldPowerup();
        }
    }

}
