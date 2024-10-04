using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchievementManager : MonoBehaviour
{
    public TextMeshProUGUI achievementText;
    public List<Achievement> achievements = new List<Achievement>();
    public static AchievementManager instance;


    private void Start()
    {
        //  PlayerPrefs.DeleteAll(); 
        // LoadAchievements();




        // Actualizar el texto para logros desbloqueados al iniciar
        foreach (var achievement in achievements)
        {
            if (achievement.isUnlocked)
            {
                UnlockAchievement(achievement.title);
            }
        }
    }




    public void UnlockAchievement(string title)
    {
        Achievement achievement = achievements.Find(a => a.title == title);
        if (achievement != null && !achievement.isUnlocked)
        {
            achievement.isUnlocked = true;
            Debug.Log($"Logro desbloqueado: {achievement.title}");
            SaveAchievements();




        }


    }

    public void SaveAchievements()
    {
        foreach (var achievement in achievements)
        {
            PlayerPrefs.SetInt(achievement.title, achievement.isUnlocked ? 1 : 0); // Guardar en PlayerPrefs
        }
        PlayerPrefs.Save();
    }

    private void LoadAchievements()
    {
        foreach (var achievement in achievements)
        {
            achievement.isUnlocked = PlayerPrefs.GetInt(achievement.title, 0) == 1; // Cargar estado
            Debug.Log($"Logro: {achievement.title}, Desbloqueado: {achievement.isUnlocked}"); // Verifica que esto se imprima
        }
    }


}
