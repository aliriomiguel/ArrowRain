using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private PlayerMovement _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Spartan").GetComponent<PlayerMovement>();
        if (_player == null)
        {
            Debug.LogError("Player is null");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement() 
    {
        //transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -7f)
        {
            float randomX = Random.Range(-8, 8f);
            transform.position = new Vector3(randomX, 7, 0);
        }    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player") 
        {
            PlayerMovement player = other.transform.GetComponent<PlayerMovement>();

            if (player != null)
            {
                player.Damage();
            }
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject);
        }

        if (other.tag == "Coin")
        {
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject);
        }
    }
}
