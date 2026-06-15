using UnityEngine;
using TMPro; // IMPORTANTE: Dá acesso aos componentes do TextMeshPro

public class CoinHUD : MonoBehaviour
{
    // Esta variável vai guardar a referência do texto que criamos na tela
    [SerializeField] private TextMeshProUGUI coinText; 

    // O OnEnable roda assim que a cena é carregada e o objeto fica ativo
    private void OnEnable()
    {
        // A GUI se inscreve no "canal" de moedas. 
        // Significa: "Quando o evento OnCoinCollected acontecer, rode o meu método UpdateCoinDisplay"
        PlayerObserverManager.OnCoinCollected += UpdateCoinDisplay;
    }

    // O OnDisable roda se o objeto for destruído ou a cena descarregada
    private void OnDisable()
    {
        // IMPORTANTE: Sempre se desinscreva para evitar bugs de memória e referências nulas
        PlayerObserverManager.OnCoinCollected -= UpdateCoinDisplay;
    }

    private void Start()
    {
        // Quando o jogo começa, força a interface a mostrar 0
        UpdateCoinDisplay(0);
    }

    // Este é o método "ouvinte". Toda vez que o Player mandar o sinal, este método recebe 
    // a quantidade atual de moedas e atualiza o texto na tela de forma automática.
    private void UpdateCoinDisplay(int currentCoins)
    {
        coinText.text = $"Moedas: {currentCoins}";
    }
}