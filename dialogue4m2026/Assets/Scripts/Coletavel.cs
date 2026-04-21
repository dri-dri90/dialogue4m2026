using UnityEngine;

public partial class Coletavel : MonoBehaviour
{
    [SerializeField] private float velocidadeRotacao = 100f;
    [SerializeField] private int valorMoeda = 1;

    void Update()
    {
        // Faz a moeda girar para ficar bonitona
        transform.Rotate(Vector3.up * velocidadeRotacao * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se quem encostou foi o Jogador
        if (other.CompareTag("Player"))
        {
            Coletar();
        }
    }

    void Coletar()
    {
        // Aqui você pode adicionar som ou partículas no futuro
        Debug.Log("Moeda coletada!");
        Destroy(gameObject);
    }
}