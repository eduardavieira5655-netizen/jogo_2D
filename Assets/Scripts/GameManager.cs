using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public string nomeDoMenuInicial;
    public string nomeDaProximaFase;
    
    public float tempoParaRecarregarAFase;

    public void GameOver()
    {
        RodarCoroutineRecarregarFase();
    }
    public void RodarCoroutineRecarregarFase()
    {
        StartCoroutine(RecarregarFase());
    }
    private IEnumerator RecarregarFase()
    {
        yield return new WaitForSeconds(tempoParaRecarregarAFase);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
