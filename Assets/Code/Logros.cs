using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public List<Achievement> achievements = new List<Achievement>();
    public AchievementManager achievementManager;

    private void Start()
    {
        LoadAchievements();
    }

    public void UnlockAchievement(string title)
    {
        Achievement achievement = achievements.Find(a => a.title == title);
        if (achievement != null && !achievement.isUnlocked)
        {
            achievement.isUnlocked = true;
            // Aquí puedes agregar un método para mostrar una notificación de logro desbloqueado
            Debug.Log($"Logro desbloqueado: {achievement.title}");
            // Guarda el progreso, si es necesario
        }
    }

    private void LoadAchievements()
    {
        // Aquí puedes cargar logros de un archivo o base de datos, si es necesario
    }


    public class Achievement
    {
        public string title;
        public string description;
        public bool isUnlocked;


    }


private void SomeAction()
{
    // Supongamos que el jugador recoge un ítem
    achievementManager.UnlockAchievement("Recolector");
}

}
