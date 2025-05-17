using UnityEngine;

public class HelpPopup : MonoBehaviour
{
  public GameObject HelpPopUp; // The popup panel

    public void OpenPopup()
    {
        HelpPopUp.SetActive(true);
    }

    public void ClosePopup()
    {
        HelpPopUp.SetActive(false);
    }
}
