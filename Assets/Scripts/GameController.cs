using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text restartText;
    public Text gameOverText;
    public Text ScoreText;
    private bool gameOver;
    private bool restart;
    private int score;

    public AudioClip background;
    public AudioClip victory;
    public AudioClip loss;
    public AudioSource audioSource;

    void Start()
    {
        audioSource.volume = .4f;
        audioSource.Stop();
        audioSource.clip = background;
        audioSource.Play();
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                if (gameOver)
                {
                    restartText.text = "Press any key EXCEPT 'R', movement keys, or spacebar to Restart.";
                    restart = true;
                    break;
                }
                yield return new WaitForSeconds(spawnWait);
            }

            if (gameOver)
            {
                restartText.text = "Press any key EXCEPT 'R', movement keys, or spacebar to Restart.";
                restart = true;
                break;
            }

            yield return new WaitForSeconds(waveWait);
            
            if (gameOver)
            {
                restartText.text = "Press any key EXCEPT 'R', movement keys, or spacebar to Restart.";
                restart = true;
                break;
            }
            
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 100)
        {
            gameOverText.text = "You win! Game Created by Seth Grimes!";
            audioSource.Stop();
            audioSource.volume = 0.25f;
            audioSource.clip = victory;
            audioSource.Play();
            gameOver = true;
            restart = true;
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void GameOver()
    {
        if ( score < 100 )
        {
            audioSource.Stop();
            audioSource.volume = 1.0f;
            audioSource.clip = loss;
            audioSource.Play();
        }
        gameOverText.text = "Game Over";
        gameOver = true;
    }

    private void Update()
    {
        if (restart)
        {
            if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Main");
            }
        }

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    public bool GetGameOver()
    {
        return gameOver;
    }

}