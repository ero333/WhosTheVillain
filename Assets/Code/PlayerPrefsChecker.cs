using UnityEngine;

public class PlayerPrefsChecker : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Verificando PlayerPrefs...");
        Debug.Log("DetectiveLevel2Unlocked: " + PlayerPrefs.GetInt("DetectiveLevel2Unlocked", 0));
        Debug.Log("DetectiveLevel3Unlocked: " + PlayerPrefs.GetInt("DetectiveLevel3Unlocked", 0));
        Debug.Log("VillainLevel1Unlocked: " + PlayerPrefs.GetInt("VillainLevel1Unlocked", 0));
        Debug.Log("VillainLevel2Unlocked: " + PlayerPrefs.GetInt("VillainLevel2Unlocked", 0));
        Debug.Log("VillainLevel3Unlocked: " + PlayerPrefs.GetInt("VillainLevel3Unlocked", 0));
    }
}
