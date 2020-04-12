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
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
            return;

        if ( explosion != null )
            Instantiate(explosion, transform.position, transform.rotation);

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    private void Update()
    {
        /*
        boo = obj.GetComponent<GameController>().GetGameOver();
        if ( boo )
            DestroyByGameOver();
            */
    }
    
    /*
    private void DestroyByGameOver()
    {
            Debug.Log("Game over happened");
            Destroy(gameObject);
    }
    */
}
