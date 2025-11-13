using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
///Esse é o script que faz o jogo parar é importante que toda cena que estiver gameplay tenha ele
/// Que ele chama o menu de pausa também
/// </summary>
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [Header("UI / Objetos visuais")]
    [SerializeField] private GameObject[] objetosParaAtivarAoPausar;
    [SerializeField] private GameObject[] objetosParaDesativarAoPausar;

    [Header("Controle do Jogador")]
    [SerializeField] private PlayerInput playerInput;

    [Header("Troca de Action Map")]
    [SerializeField] private string actionMapDuranteOJogo = "Player";
    [SerializeField] private string actionMapDuranteOPause = "UI";

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        foreach (GameObject go in objetosParaAtivarAoPausar)
            if (go != null) go.SetActive(false);

        foreach (GameObject go in objetosParaDesativarAoPausar)
            if (go != null) go.SetActive(true);

        if (playerInput != null && !string.IsNullOrEmpty(actionMapDuranteOJogo))
            playerInput.SwitchCurrentActionMap(actionMapDuranteOJogo);

        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        foreach (GameObject go in objetosParaAtivarAoPausar)
            if (go != null) go.SetActive(true);

        foreach (GameObject go in objetosParaDesativarAoPausar)
            if (go != null) go.SetActive(false);

        if (playerInput != null && !string.IsNullOrEmpty(actionMapDuranteOPause))
            playerInput.SwitchCurrentActionMap(actionMapDuranteOPause);

        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
