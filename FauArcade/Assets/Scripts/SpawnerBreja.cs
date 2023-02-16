using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBreja : MonoBehaviour
{
    public GameObject brejaPrefab;

    public float brejaYMin = -1;

    public float brejaYMax = 1;

    public float delayInicial;

    public float delayEntreBrejas;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnarBreja", delayInicial, delayEntreBrejas);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnarBreja()
    {
        var posicaoYAleatoria = Random.Range(brejaYMin, brejaYMax);

        var posicao = new Vector3(
                       transform.position.x,
                       transform.position.y + posicaoYAleatoria,
                       transform.position.z
                       );

        Instantiate(brejaPrefab, posicao, Quaternion.identity);



    }
}
