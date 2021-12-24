using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultHolder : MonoBehaviour
{
    private MoveBehaviour _moveBehaviour;
    public bool levelIsPassed;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _moveBehaviour = FindObjectOfType<MoveBehaviour>();
    }

    public void GetResult()
    {
        levelIsPassed = _moveBehaviour.GetResult(levelIsPassed);
        Debug.Log(levelIsPassed);
    }
}
