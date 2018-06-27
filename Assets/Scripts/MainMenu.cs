using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    

    public void CallScene(string SceneName) {
        SceneManager.LoadScene(SceneName);
    }

    public void Exit(){
        Application.Quit();
    }
}
