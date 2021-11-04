using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public CharacterController2D controller;
    float horizontalMove = 0f;
    [SerializeField]
    private float _runSpeed = 40f;
    private bool _isShieldPowerupActive = false;
    [SerializeField]
    private int _lives;
    
    private SpawnManager _spawnManager;

    public Animator animator;


    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is null");
        }
        else if(_spawnManager != null)
        {
            Debug.Log("SpawnManager existe");
        }
    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * _runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    private void FixedUpdate()
    {
        //Debug.Log("This is a test");
        //Debug.Log(Mathf.Abs(horizontalMove));
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);

    }

    public void Damage() {

        if (_isShieldPowerupActive == true)
        {
            _isShieldPowerupActive = false;
            //_shieldVizualizer.SetActive(false);
            return;

        }

        _lives--;

        //_uiManager.UpdateLives(_lives);

        if (_lives < 1)
        {
            //_spawnManager.OnPlayerDead();
            Destroy(this.gameObject);
        }

    }
}
