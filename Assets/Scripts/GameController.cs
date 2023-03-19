using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private bool _startGame = false;
    [SerializeField] private PlatformSpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner.StartSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
