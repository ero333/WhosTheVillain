using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public List<Achievement> achievements = new List<Achievement>(); // Lista de logros

    private void Start()
    {
        LoadAchievements(); // Cargar logros al inicio



        // CON ESTE CODIGO DE ACÁ ABAJO HACE Q SE REINICIE LA INFO DE LOS LOGROS TODAS LA VECES. NO SE GUARDA NADA.

        PlayerPrefs.DeleteAll(); // Reiniciar PlayerPrefs para pruebas
        LoadAchievements();
  
        // AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
    }

    public void UnlockAchievement(string title)
    {
        Achievement achievement = achievements.Find(a => a.title == title); // Buscar el logro
        if (achievement != null && !achievement.isUnlocked)
        {
            achievement.isUnlocked = true; // Desbloquear el logro
            Debug.Log($"Logro desbloqueado: {achievement.title}");
            SaveAchievements(); // Guardar el estado de los logros
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
        }
    }

}
