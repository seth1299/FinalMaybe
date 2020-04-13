using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInverse : MonoBehaviour
{

    public GameController gameController;

    private GameObject gameControllerObject;

    private bool gameOver;

    private bool gameOverHappenedAlready;

    public GameObject otherStarfield;

    void Start()
    {
        gameOverHappenedAlready = false;

        gameObject.SetActive(true);

        gameOver = false;

        gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();
        else if (gameControllerObject == null)
            Debug.Log("Cannot find 'GameController' script");

    }

    void Update()
    {
        gameOver = gameController.GetGameOver();

        if (gameOver && !gameOverHappenedAlready)
        {
            otherStarfield.SetActive(true);
            gameObject.SetActive(false);
            gameOverHappenedAlready = true;
        }
    }
}
