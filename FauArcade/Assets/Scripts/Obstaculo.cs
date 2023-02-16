using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public Vector2 direction;


    private Jogo jogoScript;

    // Start is called before the first frame update
    void Start()
    {
        jogoScript = GameObject.Find("Jogo").GetComponent<Jogo>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * jogoScript.vel * Time.deltaTime);
    }
}
