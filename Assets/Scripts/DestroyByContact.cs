using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;
    //private bool boo = false;
    //public GameObject obj;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();
        else if (gameControllerObject == null)
            Debug.Log("Cannot find 'GameController' script");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("ShieldPowerup") || other.CompareTag("SpeedPowerup"))
            return;

        if ( explosion != null && other.CompareTag("Shield"))
            Instantiate(explosion, transform.position, transform.rotation);

        if (explosion != null && !other.CompareTag("Shield"))
            Instantiate(explosion, transform.position, transform.rotation);
        
        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        
        if (!other.CompareTag("Player"))
            gameController.AddScore(scoreValue);

        if ( !other.CompareTag("Shield") && !other.CompareTag("ShieldPowerup"))
            Destroy(other.gameObject);

        if (other.CompareTag("Shield") || other.CompareTag("ShieldPowerup"))
        {
            other.gameObject.SetActive(false);
        }

        Destroy(gameObject);
    }

    private void Update()
    {

    }
    
}
