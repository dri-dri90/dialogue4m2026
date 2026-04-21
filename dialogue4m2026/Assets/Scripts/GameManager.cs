using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState { Iniciando, MenuPrincipal, Gameplay }
    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Se começamos direto no Boot, o estado é Iniciando
        if (SceneManager.GetActiveScene().name == "_Boot")
        {
            AlterarEstado(GameState.Iniciando);
        }
    }

    private void Start()
    {
        // Só muda para a Splash se estivermos no Boot
        if (SceneManager.GetActiveScene().name == "_Boot")
        {
            MudarCena("Splash", GameState.Iniciando);
        }
    }

    public void MudarCena(string nomeDaCena, GameState novoEstado)
    {
        AlterarEstado(novoEstado);
        SceneManager.LoadScene(nomeDaCena);
        Debug.Log($"Indo para: {nomeDaCena} | Estado: {CurrentState}");
    }

    private void AlterarEstado(GameState novoEstado)
    {
        CurrentState = novoEstado;
        // Removi o 'playerInput.enabled' para evitar que o seu player pare de andar
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }
}