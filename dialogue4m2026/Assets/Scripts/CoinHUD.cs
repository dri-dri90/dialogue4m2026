using UnityEngine;
using TMPro;

public class CoinHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText; 

    // Mudamos para Awake para garantir que a inscrição aconteça ANTES do jogo começar a rodar
    private void Awake()
    {
        // Limpa qualquer inscrição antiga para evitar duplicados
        PlayerObserverManager.OnCoinCollected -= UpdateCoinDisplay;
        // Se inscreve de forma segura
        PlayerObserverManager.OnCoinCollected += UpdateCoinDisplay;
    }

    private void OnDestroy()
    {
        // Se desinscreve quando a cena for fechada
        PlayerObserverManager.OnCoinCollected -= UpdateCoinDisplay;
    }

    private void Start()
    {
        UpdateCoinDisplay(0);
    }

    private void UpdateCoinDisplay(int currentCoins)
    {
        if (coinText != null)
        {
            coinText.text = $"Moedas: {currentCoins}";
        }
    }
}