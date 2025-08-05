using UnityEngine;
using UnityEngine.SceneManagement;

public class NoticeUI : MonoBehaviour
{
    [SerializeField] GameObject ui;

    public void LoadUI()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Menu()
    {
        LoadUI();
        SceneManager.LoadScene("Menu");
    }
}
