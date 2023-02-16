using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogo : MonoBehaviour
{

    public float modificadorVel = 1f;

    public float vel = 6f;

    public float maxVel = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vel = Mathf.Clamp(
            vel + modificadorVel * Time.deltaTime,
            0,
            maxVel
        );
    }

    public void ReiniciarJogo()
    {
        SceneManager.LoadScene("Jogo");

        Time.timeScale = 1;
    }

    public void IrParaMenu()
    {
        SceneManager.LoadScene("Menu");

        Time.timeScale = 1;
    }
}
