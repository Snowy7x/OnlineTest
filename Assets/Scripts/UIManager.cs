using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject loginMenu;
    [SerializeField] private GameObject loadingMenu;

    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
        loginMenu.SetActive(false);
        loadingMenu.SetActive(false);
    }

    public void OpenLoginMenu()
    {
        mainMenu.SetActive(false);
        loginMenu.SetActive(true);
        loadingMenu.SetActive(false);
    }

    public void OpenLoading()
    {
        mainMenu.SetActive(false);
        loginMenu.SetActive(false);
        loadingMenu.SetActive(true);
    }
}