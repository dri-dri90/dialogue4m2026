using UnityEngine;

public class ConfiguracoesJogo : MonoBehaviour
{
    public void FecharJogo()
    {
        // Fecha o aplicativo propriamente dito (funciona no .exe, Android, etc)
        Application.Quit();

        // Linha opcional: Apenas para você ver no Console que o botão funcionou dentro do Editor
        Debug.Log("O botão de sair foi clicado!");

        // Se você estiver testando no Editor da Unity, essa linha para a execução:
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}