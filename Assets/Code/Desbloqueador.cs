using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desbloqueador : MonoBehaviour
{
    // Start is called before the first frame update
    public AchievementManager achievementManager;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Simula recoger un objeto al presionar la barra espaciadora
        {
            achievementManager.UnlockAchievement("Amante de los detalles Caso 1"); 

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            achievementManager.UnlockAchievement("Interrogador nato Caso 1"); 
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            achievementManager.UnlockAchievement("Amante de los detalles Caso 2"); 
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            achievementManager.UnlockAchievement("Interrogador nato Caso 2"); 
        }
    }
}
