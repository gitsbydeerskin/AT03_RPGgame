using UnityEngine;
#region Unity Callback
public interface IInteractable
{
  void OnInteraction();
  string ToolTip();
}
#endregion
