using UnityEngine;

public class MenuUI : MonoBehaviour
{
    // Esta função será chamada pelo botão Iniciar
    public void IniciarJogo()
    {
        if (GameManager.Instance != null)
        {
            // Chama a função do GameManager que muda a cena e o Estado
            GameManager.Instance.MudarCena("SampleScene", GameManager.GameState.Gameplay);
        }
        else
        {
            Debug.LogError("GameManager não encontrado! Você deu Play pela cena _Boot?");
        }
    }

    // Esta função será chamada pelo botão Sair
    public void SairDoJogo()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SairDoJogo();
        }
    }
}