using UnityEngine;

public class HelpPopup : MonoBehaviour
{
  public GameObject HelpPopUp; // The popup panel
   public GameObject MainMenuPanel;// The main menu panel

    public void OpenPopup()
    {
        HelpPopUp.SetActive(true);
        MainMenuPanel.SetActive(false);
    }

    public void ClosePopup()
    {
        HelpPopUp.SetActive(false);
        MainMenuPanel.SetActive(true);
    }
}
