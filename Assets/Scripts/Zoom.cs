using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{

    public GameController gameController;

    private GameObject gameControllerObject;

    private bool gameOver;

    void Start()
    {
        gameObject.SetActive(false);

        /*
        gameOver = false;

        gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();
        else if (gameControllerObject == null)
            Debug.Log("Cannot find 'GameController' script");
            */
    }

    void Update()
    {
        /*
        gameOver = gameController.GetGameOver();
        Debug.Log(gameOver);


        if ( gameOver == true )
        {
            Debug.Log("Setting active now!");
            gameObject.SetActive(true);
        }
        */
    }
}
