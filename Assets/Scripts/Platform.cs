using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    void Update()
    {
        transform.Translate(-1 * _moveSpeed * Time.deltaTime, 0, 0);
    }
}
