using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public Slider timeSlider;
    public TMP_Dropdown colorDropdown;

    public PlayerMovement player;

    private void Start()
    {
        settingsPanel.SetActive(false);

        timeSlider.value = GameManager.Instance.timeToWin;

        colorDropdown.value = 0;
        colorDropdown.RefreshShownValue();

        timeSlider.onValueChanged.AddListener(OnTimeChanged);
        colorDropdown.onValueChanged.AddListener(OnColorChanged);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    private void OnTimeChanged(float newValue)
    {
        GameManager.Instance.timeToWin = newValue;
    }

    private void OnColorChanged(int index)
    {
        Color newColor = Color.magenta;

        switch (index)
        {
            case 0: newColor = Color.magenta; break;
            case 1: newColor = Color.red; break;
            case 2: newColor = Color.black; break;
            case 3: newColor = Color.springGreen; break;
        }

        player.GetComponent<SpriteRenderer>().color = newColor;
    }
}
