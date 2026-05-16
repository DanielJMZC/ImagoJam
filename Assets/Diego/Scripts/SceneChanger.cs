using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instance;



    void Awake()
    {
        Instance = this;
    }

    public void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

}
