using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject Options;
    public GameObject EndGame;
    bool isPaused;
    public bool isGameOver;
    public ScoreManager scoreManager;
    public SpawnObstacles spawnObstacles;
    public float points;
    public Timer timer;
    public TMP_Text surviveTime;
    public TMP_Text score;
    private FMOD.Studio.EventInstance pauseSnapshot;
    public GameObject[] asteroids;
    public GameObject[] supplies;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        isPaused = false;

        Time.timeScale = 1;
        pauseSnapshot = FMODUnity.RuntimeManager.CreateInstance("event:/PauseSnapshot");
    }

    // Update is called once per frame
    void Update()
    {

        spawnObstacles.spawnRate = 0.5f + timer.minutes * 0.1f;
        if (Input.GetKeyDown(KeyCode.T))
        {
            isPaused = true;
            GameOver();
        }

            if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
           
            if (!Options.active )
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/PauseOpen");
                isPaused = true;
                Options.SetActive(true);
                PauseGame();
            }
            else
            {
                
                isPaused = false;
                Options.SetActive(false);
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        if(isPaused)
        {
            pauseSnapshot.start();
            Time.timeScale = 0;
           
        }
        else
        {
            unPause();

        }
    }
    public void unPause()
    {
        pauseSnapshot.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Time.timeScale = 1;
        isPaused = false;
    }
    public void GameOver()
    {
        isGameOver = true;
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        GameObject.FindGameObjectWithTag("Planet").SetActive(false);
        

        asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (GameObject asteroid in asteroids)
            Destroy(asteroid.gameObject);
        supplies = GameObject.FindGameObjectsWithTag("Supply");
        foreach (GameObject supply in supplies)
            Destroy(supply.gameObject);


        FMODUnity.RuntimeManager.PlayOneShot("event:/PauseOpen");
        isPaused = true;
        EndGame.SetActive(true);
        PauseGame();


        surviveTime.text = string.Format("You survives: {0:00}:{1:00}", timer.minutes, timer.seconds);
        score.text = "Score: " + scoreManager.score + " POINTS";

    }
    public void Restart()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Click");
        isPaused = false;
        EndGame.SetActive(false);
        PauseGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
