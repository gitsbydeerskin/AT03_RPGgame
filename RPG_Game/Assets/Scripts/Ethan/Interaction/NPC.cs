using UnityEngine;

public class NPC : MonoBehaviour
{
    #region variables
    private string toolTip = "";
    [SerializeField] string[] _lines;
    [SerializeField] string _name;
    [SerializeField] Sprite _face;
    #endregion
    #region Unity Callback
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
            {
                toolTip = $"Press {KeybindManager.Keys["Interact"].ToString()} to interact";
            }
    #endregion
    #region functions
    public void OnInteraction()
    {
        //activates the lines, name and face dialogue from the dialogue manager script
        DialogueManager.instance.OnActive(_lines, _name, _face);
    }

    public string ToolTip()
    {
        //displays the tooltip
        return toolTip;
    }
    #endregion
}
