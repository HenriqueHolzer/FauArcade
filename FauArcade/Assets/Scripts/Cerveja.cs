using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerveja : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Ativar escudo do jogador e desativar o power-up
            gameObject.SetActive(false);
        }
    }


}
