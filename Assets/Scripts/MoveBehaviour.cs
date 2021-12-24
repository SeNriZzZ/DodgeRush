using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 5f;
    [SerializeField] private GameObject _player;
    private Renderer _renderer;
    [SerializeField] private int _lives = 3;
    private UIManager _uiManager;
    private float _cubeSize = 0.6f;
    private bool isLevelPassed = false;
    private void Start()
    {
        
        _renderer = _player.GetComponent<Renderer>();
        _uiManager = FindObjectOfType<UIManager>();
        _renderer.material.SetColor("_Color", Color.green);
    }

    private void Update()
    {
        Movement();
        Death();
    }

    private void Death()
    {
        if (_lives == 0)
        {
            Camera.main.transform.parent = null;
            Destroy(this.gameObject);
            for (int x = 0; x < 8; x++)
            {
                Pieces();
            }
        }
    }
    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.right * horizontalInput * _playerSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * verticalInput * _playerSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            _renderer.material.SetColor("_Color", Color.yellow);
            StartCoroutine(OnWinPanel());
            isLevelPassed = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            _lives -= 1;
            _uiManager.UpdateLives(_lives);
            StartCoroutine(HitBehaviour());
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            _lives -= 1;
            _uiManager.UpdateLives(_lives);
            StartCoroutine(HitBehaviour());
        }
    }


    IEnumerator HitBehaviour()
    {
        _renderer.material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(0.5f);
        _renderer.material.SetColor("_Color", Color.green);
    }

    private void Pieces()
    {
            GameObject piece;
            piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

            piece.transform.position = transform.position;
            piece.transform.localScale = new Vector3(_cubeSize,_cubeSize,_cubeSize);

            piece.AddComponent<Rigidbody>();
            piece.GetComponent<Rigidbody>().mass = 4f;
            piece.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }

    IEnumerator OnWinPanel()
    {
        yield return new WaitForSeconds(1f);
        _uiManager.ActivateWinPanel(_lives);
        Time.timeScale = 0;
    }

    public bool GetResult(bool IsPassed)
    {
        IsPassed = isLevelPassed;
        return IsPassed;
    }
}
