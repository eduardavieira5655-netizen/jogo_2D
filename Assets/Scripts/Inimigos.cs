using UnityEngine;

public class Inimigos : MonoBehaviour
{
    public Transform [] pontosDoCaminho;
    public int pontoAtual;
    public float velocidadeDoInimigo;
    public float ultimaPosicaoX;

    void Start()
    {
        pontoAtual = 0;
        transform.position = pontosDoCaminho[0].position;
    }
    void Update()
    {
        MoverInimigo();
        EspelharInimigo();
    }
    private void MoverInimigo()
    {
         transform.position = Vector2.MoveTowards(transform.position, pontosDoCaminho[pontoAtual].position, velocidadeDoInimigo * Time.deltaTime);

        if (transform.position == pontosDoCaminho[pontoAtual].position)
        {
            pontoAtual++;
            ultimaPosicaoX = transform.localPosition.x;

            if (pontoAtual >= pontosDoCaminho.Length)
            {
                pontoAtual = 0;
            }
        }
    }
    private void EspelharInimigo()
    {
     if(transform.localPosition.x < ultimaPosicaoX)
     {
        GetComponent<SpriteRenderer>().flipX = false;
     }
     else if(transform.localPosition.x > ultimaPosicaoX)
     {
        GetComponent<SpriteRenderer>().flipX = true;
     }
    }
}
