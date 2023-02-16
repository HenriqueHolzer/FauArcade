using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject jacarePrefab;

    public float jacaYMin = -1;

    public float jacaYMax = 1;

    public GameObject pipePrefab;

    public float delayInicial;

    public float delayEntreCanos;

    public float jacaMinPontos = 1000;

    public PlayerMovement jogadorScript;

    public float distanciaMin = 4;

    public float distanciaMax = 8;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnEnemys", delayInicial, delayEntreCanos);
        StartCoroutine(SpawnEnemys());
    }

    // Update is called once per frame
    private IEnumerator SpawnEnemys()
    {
        yield return new WaitForSeconds(delayInicial);

        GameObject ultimoInimigoGerado = null;

        var distanciaNecessaria = 0f;

        while (true)
        {

            var geracaoLiberada = ultimoInimigoGerado == null || Vector3.Distance(transform.position, ultimoInimigoGerado.transform.position) >= distanciaNecessaria;

            if (geracaoLiberada)
            {
                var dado = Random.Range(1, 7);

                var posicaoYAleatoria = Random.Range(jacaYMin, jacaYMax);

                if (jogadorScript.points >= jacaMinPontos && dado <= 2)
                {
                    var posicao = new Vector3(
                        transform.position.x,
                        transform.position.y + posicaoYAleatoria,
                        transform.position.z
                        );

                    ultimoInimigoGerado = Instantiate(jacarePrefab, posicao, Quaternion.identity);
                }
                else
                {
                   ultimoInimigoGerado = Instantiate(pipePrefab, transform.position, Quaternion.identity);
                }

                distanciaNecessaria = Random.Range(distanciaMin, distanciaMax);
            }
            yield return null;
            //yield return new WaitForSeconds(delayEntreCanos);
        }



    }
}
