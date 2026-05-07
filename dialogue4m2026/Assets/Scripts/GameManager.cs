using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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
    
    }
    private void Update() {
        switch(CurrentState) {
            case GameState.Iniciando:
                if(SceneManager.GetActiveScene().name != "Splash") {
                    MudarCena("Splash");
                }
            break;
            
            case GameState.MenuPrincipal:

            break;

            default: break;
        }
    }
    public void MudarCena(string nomeDaCena)
    {
        SceneManager.LoadScene(nomeDaCena);
        Debug.Log($"Indo para: {nomeDaCena} | Estado: {CurrentState}");

        if(nomeDaCena == "Splash") {
            CurrentState = GameState.Iniciando;
        }
        
        if(nomeDaCena == "MenuPrincipal") {
            CurrentState = GameState.MenuPrincipal;
        }

        if(nomeDaCena == "SampleScene") {
            CurrentState = GameState.Gameplay;
        }
    }

    public void checarCena() {
        if(SceneManager.GetActiveScene().name == "Splash") {
            CurrentState = GameState.Iniciando;
        }
        
        if(SceneManager.GetActiveScene().name == "MenuPrincipal") {
            CurrentState = GameState.MenuPrincipal;
        }

        if(SceneManager.GetActiveScene().name == "SampleScene") {
            CurrentState = GameState.Gameplay;
        }
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