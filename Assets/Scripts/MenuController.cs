using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("GameScene");
        //Application.LoadLevel("GameScene");
        //SceneManager.LoadScene(0);
    }


    public void Quit()
    {
        Debug.Log("Exciting...");
        Application.Quit();
    }
}
