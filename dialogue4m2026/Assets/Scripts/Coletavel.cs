using UnityEngine;

public partial class Coletavel : MonoBehaviour
{
    [SerializeField] private float velocidadeRotacao = 100f;
    [SerializeField] private int valorMoeda = 1;

    // Criamos uma variável estática interna para acumular o total de moedas do jogo todo
    private static int totalMoedasColetadas = 0;

    void Update()
    {
        transform.Rotate(Vector3.up * velocidadeRotacao * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se quem encostou foi o Jogador usando a Tag
        if (other.CompareTag("Player"))
        {
            Coletar();
        }
    }

    void Coletar()
    {
        // 1. Incrementa o total geral de moedas baseado no valor desta moeda
        totalMoedasColetadas += valorMoeda;

        // 2. DISPARA O EVENTO: Envia o valor atualizado para o PlayerObserverManager avisar a GUI
        PlayerObserverManager.SendCoinCollected(totalMoedasColetadas);

        // Mensagem no console para você acompanhar
        Debug.Log($"Moeda coletada! Total acumulado: {totalMoedasColetadas}");
        
        // Destrói a moeda
        Destroy(gameObject);
    }
}