using System;

public static class PlayerObserverManager
{
    // O canal por onde a quantidade de moedas vai passar
    public static event Action<int> OnCoinCollected;

    // O método chamado pelo Player para transmitir a mensagem
    public static void SendCoinCollected(int totalCoins)
    {
        OnCoinCollected?.Invoke(totalCoins);
    }
}