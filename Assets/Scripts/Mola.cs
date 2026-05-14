using UnityEngine;

public class Mola : MonoBehaviour
{
    private Animator oAnimator;
    public float forcaDaMola;

    void Awake()
    {
        oAnimator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            oAnimator.Play("animacao-da-mola-subindo");
            other.gameObject.GetComponent<MovimentoDoJogador>().ImpulsionarJogador(forcaDaMola);
        }
    }
}
