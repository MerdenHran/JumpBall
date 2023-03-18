using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _platformTemplate;
    [SerializeField] private bool _startGame = true;

    private float _spawnYPosition = 8f;
    private float _spawnPauseTime = 1f;
    private float _minPlatformLength = 2f;
    private float _maxPlatformLength = 8f;

    void Start()
    {
        StartCoroutine(SpawnPlatforms());
    }

    private IEnumerator SpawnPlatforms() {
        while (true)
        {
            SpawnObject(3);
            SpawnObject(-3);
            yield return new WaitForSeconds(_spawnPauseTime);
        }
    }

    private void SpawnObject(float x_position) {
        _platformTemplate.transform.position = new Vector3(_spawnYPosition, x_position, 0f);
        _platformTemplate.transform.localScale = transform.TransformVector(new Vector3(Random.Range(_minPlatformLength, _maxPlatformLength), 1f, 0.5f));
        Instantiate(_platformTemplate);
        Debug.Log($"{_platformTemplate.transform.localScale}");
    }
}
