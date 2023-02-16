using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    public float delayPowerUp = 3;

    public float shieldHP = 1;

    public PlayerMovement playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Inimigo"))
        {
            // Diminuir a HP do escudo
            shieldHP -= 2;
            if (shieldHP <= 0)
            {
                // Desativar escudo
                playerScript.escudo.SetActive(false);
                playerScript.canCollectShield = true;
                Invoke("Morrer", 3);

            }
        }
    }

    private void Morrer()
    {
        playerScript.canDie = true;
    }

}
