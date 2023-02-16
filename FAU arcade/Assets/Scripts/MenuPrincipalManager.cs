using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevel;
    [SerializeField] private GameObject painelMenu;
    [SerializeField] private GameObject painelOpcoes;

   public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevel);
    }

    public void AbrirOpcoes ()
    {
        painelMenu.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        painelOpcoes.SetActive(false);
        painelMenu.SetActive(true);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
