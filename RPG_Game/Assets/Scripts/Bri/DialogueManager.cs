using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    // Here we are using a Singleton because we want DialogueManager to be the ONLY one of its kind to run
    #region Singleton
    public static DialogueManager instance;
    // It runs at Awake - when the code/game is very first loaded or started
    private void Awake()
    {
        // Now it looks to see if 'instance' is empty, and if it is:
        if (instance == null)
        {
            // it declares instance as 'this'; ie itself
            instance = this;
        }

        // However, if instance DOESN'T = empty OR 'this', meaning instance is a DIFFERENT script
        else if (instance != null && instance != this)
        {
            // It will destroy the duplicate instances of DialogueManager 
            Destroy(this);
        }
    }
    #endregion
    // Here we are connecting the Dialogue Manager to our Unity Canvas elements 
    #region Dialogue GUI Elements
    [SerializeField] GameObject _dialogueBox;
    [SerializeField] Text _dialogueText;
    [SerializeField] Image _displayPicture;
    [SerializeField] Text _name;
    [SerializeField] Text _inputDisplay;
    #endregion

    #region Variables
    // _dialogueLines will contain the lines to be read
    [SerializeField] string[] _dialogueLines;
    // _currentIndex will be used to decide the current line of dialogue 
    [SerializeField] int _currentIndex = 0;
    #endregion
    private void Start()
    {
        OnDeactive();
    }
    public void OnActive(string[] lines, string name, Sprite face)
    { 
        _dialogueBox.SetActive(true);
        _dialogueLines = lines;
        _currentIndex = 0;
        _displayPicture.sprite = face;
        _name.text = name;
        _dialogueText.text = _dialogueLines[_currentIndex];

        if (_currentIndex < _dialogueLines.Length - 1)
        {
            _inputDisplay.text = "Next";
        }
        else
        {
            _inputDisplay.text = "Bye!";
        }
    }

    // This sets up a function that will turn off the dialogue interface when we call it. 
    void OnDeactive()
    {
        _dialogueBox.SetActive(false);
        _inputDisplay.text = "Next";
        _currentIndex = 0;
    }

    public void Input()
    {
        // If there are at least two lines left, this code is followed: 
        if (_currentIndex < _dialogueLines.Length - 2)
        {
            _inputDisplay.text = "Next";
            // _current index ++ means it is 'adding' one to the index - since our dialogue is just a bunch of strings in an index, this is how we update what the NPCs are saying - by updating the index. 
            _currentIndex++;
        }
        // Otherwise if we are on the second to last line, we show "bye" to indicate this is the final line of dialogue: 
        else if (_currentIndex < _dialogueLines.Length - 1)
        {
            _inputDisplay.text = "Bye.";
            _currentIndex++;
        }
        // Finally when we reach the 'end' of the dialogue options, we call the OnDeactivate function, which closes the dialogue window:
        else
        {
            OnDeactive();
        }
        _dialogueText.text = _dialogueLines[_currentIndex]; 
    }
}
