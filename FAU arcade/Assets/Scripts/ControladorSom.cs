using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorSom : MonoBehaviour
{
    [SerializeField] private AudioSource musica;
    [SerializeField] private AudioSource[] efeitos;

    public Slider volumeSlider;

    void Start()
    {
        // Procura todos os objetos de efeito sonoro na cena
        efeitos = FindObjectsOfType<AudioSource>();

        // Define o valor inicial do Slider como o volume atual dos efeitos sonoros
        volumeSlider.value = efeitos[0].volume;
    }

    public void VolumeMusical(float value)
    {
        musica.volume = value;
    }


    void Update()
    {
        // Atualiza o volume de todos os efeitos sonoros de acordo com o valor do Slider
        foreach (AudioSource audioSource in efeitos)
        {
            audioSource.volume = volumeSlider.value;
        }
    }
}
