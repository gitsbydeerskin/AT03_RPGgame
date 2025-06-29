using UnityEngine;
using UnityEngine.UI;

public class QualityManager : MonoBehaviour
{
    [SerializeField] Dropdown _qualityDropdown;

    int _CurrentQualityIndex = 0;

    public int CurrentQualityIndex
    {
        set { _CurrentQualityIndex = value; }
        get { return _CurrentQualityIndex; }
    }

    public void ChangeQuality(int qualityIndex)
    {
        CurrentQualityIndex = qualityIndex;
        QualitySettings.SetQualityLevel(CurrentQualityIndex);
    }

    private void Start()
    {
        _qualityDropdown.value = CurrentQualityIndex;
        QualitySettings.SetQualityLevel(CurrentQualityIndex);
    }
}
