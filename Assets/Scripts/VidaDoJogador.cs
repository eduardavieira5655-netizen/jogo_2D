using UnityEngine;
using System.Collections;

public class VidaDoJogador : MonoBehaviour
{
    [Header("Referências")]
    public GameObject efeitoDeExplosao;
    private Rigidbody2D oRigidbody2D;
    private Animator oAnimator;

    [Header("Valores")]
    public float tempoParaDestruirJogador;

    void Awake()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
        oAnimator = GetComponent<Animator>();
    }

    public void MachucarJogador()
    {
        MovimentoDoJogador jogador = FindFirstObjectByType<MovimentoDoJogador>();
        if (jogador != null)
        {
            jogador.jogadorEstaVivo = false;
        }

        oRigidbody2D.linearVelocity = Vector2.zero;

        oAnimator.Play("jogador-levando-dano");

        StartCoroutine(DestruirJogador());
    }

    private IEnumerator DestruirJogador()
    {
        yield return new WaitForSeconds(tempoParaDestruirJogador);

        GameManager gameManager = FindFirstObjectByType<GameManager>();
        if (gameManager != null)
        {
            gameManager.GameOver();
        }

        if (efeitoDeExplosao != null)
        {
            Instantiate(efeitoDeExplosao, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
}