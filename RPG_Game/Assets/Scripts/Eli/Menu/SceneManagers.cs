using UnityEngine;
using UnityEngine.SceneManagement; //required to manage scenes for things like Loading, unloading and switching between scenes.

public class SceneManagers : MonoBehaviour
{
    //Load the next scene in the build settings scene index.
    public void LoadNextScene()
    {
        //moves to the next build index by 1 to load the next scene  
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //reloads the current scene in the build index.
    public void ReloadCurrentScene()
    {
        //finds the current scene in the build index and reloads it.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    //Load the last scene in the build settings scene index.
    public void LoadLastScene()
    {
        //decreases the build index by 1 to load the last scene  
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
