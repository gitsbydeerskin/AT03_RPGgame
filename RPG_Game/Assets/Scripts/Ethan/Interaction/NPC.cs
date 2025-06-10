using UnityEngine;

public class NPC : MonoBehaviour
{
    private string toolTip = "";
    [SerializeField] string[] _lines;
    [SerializeField] string _name;
    [SerializeField] Sprite _face;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
            {
                toolTip = $"Press {KeybindManager.Keys["Interact"].ToString()} to interact";
            }
    public void OnInteraction()
    {
        DialogueManager.instance.OnActive(_lines, _name, _face);
    }

    public string ToolTip()
    {
        return toolTip;
    }
}
