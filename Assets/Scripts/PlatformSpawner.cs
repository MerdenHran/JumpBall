using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _platformTemplate;
    [SerializeField] private bool _startGame = true;
    private Coroutine _spawnCoroutine;

    // Platform spawn values
    private float _spawnYPosition = 10f; // Spawn Y position
    private float _spawnXPostion = 3f; // Distance from center in both direction (horizontal axis)
    private float _spawnPauseTime = 1f; // Pause between spawns
    private float _platformLifeTime = 3f; // Time before platform will be destroyed
    
    // Platform length range
    private float _minPlatformLength = 2f;
    private float _maxPlatformLength = 8f;

    public void StartSpawn() {
        _spawnCoroutine = StartCoroutine(SpawnPlatforms());
    }

    public void StopSpawn() {
        StopCoroutine(_spawnCoroutine);
    }

    private IEnumerator SpawnPlatforms() {
        while (true)
        {
            SpawnObject(_spawnXPostion);
            SpawnObject(-1 * _spawnXPostion);
            yield return new WaitForSeconds(_spawnPauseTime);
        }
    }

    private void SpawnObject(float x_position) {
        _platformTemplate.transform.position = new Vector3(_spawnYPosition, x_position, 0f);
        _platformTemplate.transform.localScale = new Vector3(Random.Range(_minPlatformLength, _maxPlatformLength), 1f, 0.5f);
        GameObject newPlatform = Instantiate(_platformTemplate);
        Destroy(newPlatform, _platformLifeTime);
    }
}
