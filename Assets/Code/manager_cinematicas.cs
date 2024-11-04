using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector timeline0;
    public PlayableDirector timeline1; 
    public PlayableDirector timeline2;


    private bool timeline0Finished = false;
    private bool timeline1Finished = false;
    private bool timeline2Started = false;
    

    void Start()
    {
        // Inicia la primera timeline
        timeline0.Play();
    }

    void Update()
    {
        if (timeline0.state == PlayState.Paused && !timeline0Finished)
        {
            timeline0Finished = true; // Marca que la segunda timeline ha terminado
            timeline1.Play();
        }
        // Verifica si la primera timeline ha terminado
        if (timeline1.state == PlayState.Paused && !timeline1Finished)
        {
            timeline1Finished = true; // Marca que la primera timeline ha terminado
            timeline2.Play(); // Reproduce la segunda timeline
        }

        // Verifica si la segunda timeline ha terminado
        if (timeline2.state == PlayState.Paused && !timeline2Started)
        {
            timeline2Started = true; // Marca que la segunda timeline ha terminado
            
        }

        // Verifica si la segunda timeline ha terminado
      
    }
}