using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMenu : MonoBehaviour
{
    [SerializeField] private string gameSceneName;
    public GameObject stats;


    private void Start()
    {
        Instantiate(stats);
    }

    public void Play()
    {
        SceneManager.LoadScene(gameSceneName);
        
    }

    public void Quit()
    {
        Application.Quit();
    }
}
