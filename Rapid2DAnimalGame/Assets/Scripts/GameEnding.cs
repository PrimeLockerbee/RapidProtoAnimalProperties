using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _endingScreen;
    [SerializeField] GameObject _endCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _player.SetActive(false);
            _endingScreen.SetActive(true);
        }
    }
}
