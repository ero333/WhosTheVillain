using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public void SaveProgress(int detectiveLevel, int villainLevel)
    {
        PlayerPrefs.SetInt("DetectiveLevel", detectiveLevel);
        PlayerPrefs.SetInt("VillainLevel", villainLevel);
        PlayerPrefs.Save();
    }

    public (int, int) LoadProgress()
    {
        int detectiveLevel = PlayerPrefs.GetInt("DetectiveLevel", 0);
        int villainLevel = PlayerPrefs.GetInt("VillainLevel", 0);
        return (detectiveLevel, villainLevel);
    }
    public void BorrarProgreso()
    {
        PlayerPrefs.DeleteAll();
    }
}