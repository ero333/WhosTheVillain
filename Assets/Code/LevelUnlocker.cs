using UnityEngine;
using UnityEngine.UI;

public class LevelUnlocker : MonoBehaviour
{
    public static LevelUnlocker Instance { get; private set; }

    public Button[] detectiveLevelButtons;
    public Button[] villainLevelButtons;

    void Start()
    {
        // Actualizar el estado de los botones según el progreso guardado
        UpdateLevelButtons();
    }

    public void UnlockLevels(int detectiveLevel, int villainLevel)
    {
        if (detectiveLevel == 1)
        {
            PlayerPrefs.SetInt("DetectiveLevel2Unlocked", 1);
            PlayerPrefs.SetInt("VillainLevel1Unlocked", 1);
        }
        else if (detectiveLevel == 2)
        {
            PlayerPrefs.SetInt("DetectiveLevel3Unlocked", 1);
        }

        if (villainLevel == 1)
        {
            if (PlayerPrefs.GetInt("DetectiveLevel2Unlocked", 0) == 0)
            {
                PlayerPrefs.SetInt("DetectiveLevel2Unlocked", 1);
            }
            else
            {
                PlayerPrefs.SetInt("VillainLevel2Unlocked", 1);
            }
        }
        else if (villainLevel == 2)
        {
            PlayerPrefs.SetInt("VillainLevel3Unlocked", 1);
        }

        PlayerPrefs.Save();
        UpdateLevelButtons();
    }

    public bool IsLevelUnlocked(string levelKey)
    {
        return PlayerPrefs.GetInt(levelKey, 0) == 1;
    }

    private void UpdateLevelButtons()
    {
        Debug.Log("Actualizando botones de nivel");

        if (detectiveLevelButtons.Length > 1)
        {
            detectiveLevelButtons[1].interactable = IsLevelUnlocked("DetectiveLevel2Unlocked");
            Debug.Log($"DetectiveLevel2Unlocked: {IsLevelUnlocked("DetectiveLevel2Unlocked")}");
        }
        if (detectiveLevelButtons.Length > 2)
        {
            detectiveLevelButtons[2].interactable = IsLevelUnlocked("DetectiveLevel3Unlocked");
            Debug.Log($"DetectiveLevel3Unlocked: {IsLevelUnlocked("DetectiveLevel3Unlocked")}");
        }
        if (villainLevelButtons.Length > 0)
        {
            villainLevelButtons[0].interactable = IsLevelUnlocked("VillainLevel1Unlocked");
            Debug.Log($"VillainLevel1Unlocked: {IsLevelUnlocked("VillainLevel1Unlocked")}");
        }
        if (villainLevelButtons.Length > 1)
        {
            villainLevelButtons[1].interactable = IsLevelUnlocked("VillainLevel2Unlocked");
            Debug.Log($"VillainLevel2Unlocked: {IsLevelUnlocked("VillainLevel2Unlocked")}");
        }
        if (villainLevelButtons.Length > 2)
        {
            villainLevelButtons[2].interactable = IsLevelUnlocked("VillainLevel3Unlocked");
            Debug.Log($"VillainLevel3Unlocked: {IsLevelUnlocked("VillainLevel3Unlocked")}");
        }
    }
}
