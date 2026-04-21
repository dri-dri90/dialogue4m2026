using UnityEngine;
using System.Collections;

public class SplashController : MonoBehaviour
{
    void Start()
    {
        // Se houver erros no console, esta linha nunca será lida!
        StartCoroutine(ContagemSplash());
    }

    IEnumerator ContagemSplash()
    {
        Debug.Log("Splash iniciada...");
        yield return new WaitForSeconds(2f); // Aguarda os 2 segundos exigidos

        if (GameManager.Instance != null)
        {
            GameManager.Instance.MudarCena("MenuPrincipal", GameManager.GameState.MenuPrincipal);
        }
    }
}