using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByGameOver : MonoBehaviour
{
    public GameController gameController;

    private GameObject gameControllerObject;

    private int sc;

    private bool gameOver;

    void Start()
    {
        gameOver = false;
        gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();
        else if (gameControllerObject == null)
            Debug.Log("Cannot find 'GameController' script");
    }

    
    void Update()
    {
        sc = gameController.GetScore();

        gameOver = gameController.GetGameOver();

        if ( sc >= 100 || gameOver )
        {
            if (this.CompareTag("SpeedPowerup") || this.CompareTag("ShieldPowerup"))
                gameObject.SetActive(false);

            else
            {
                Destroy(gameObject);
            }
            
        }
    }
}
