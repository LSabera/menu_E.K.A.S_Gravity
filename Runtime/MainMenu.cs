using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using SmallHedge.SoundManager;
/// <summary>
/// Este é o menu aliásEste é o script para o menu a que define a música que vai tocar 
/// que define também para que cena você vai depois que aperta ou confirma para outro lugar
/// </summary>
public class MainMenu : MonoBehaviour
{
    private void Start()
    {

    }
    [SerializeField] private string nomeDaCena; // Nome da cena a carregar

    /// <summary>
    /// Chamado automaticamente pelo PlayerInput quando a ação PlayGame for executada (via teclado, ex: Enter)
    /// </summary>
    public void OnPlayGame(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            CarregarCena();
        }
    }

    /// <summary>
    /// Chamado pelo botão da UI (através do evento OnClick)
    /// </summary>
    public void StartGamePorBotao()
    {
        CarregarCena();
    }

    /// <summary>
    /// Carrega a cena configurada no campo nomeDaCena
    /// </summary>
    private void CarregarCena()
    {
        if (!string.IsNullOrEmpty(nomeDaCena))
        {
            SceneManager.LoadScene(nomeDaCena);
        }
        else
        {
            Debug.LogWarning("nomeDaCena não foi definido no inspetor.");
        }
    }
}
