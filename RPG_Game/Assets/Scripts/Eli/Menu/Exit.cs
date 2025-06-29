using UnityEngine;

public class Exit : MonoBehaviour
{
    public void ExitButton()
    {
        //if ExitButton is ran in unity/Unity Editor it will stop play mode.
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif

        //this will quit the game when it is compiled into a game.
        Application.Quit();
    }
}
