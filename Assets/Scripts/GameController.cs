using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool isGameStarted = false;
    [SerializeField] private PlatformSpawner _spawner
        ;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        _spawner.StartSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        Time.timeScale = 1;
        isGameStarted = true;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isGameStarted = false;
    }
}
