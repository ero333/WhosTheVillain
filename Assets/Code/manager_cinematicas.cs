using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector timeline1; // Arrastra aqu� tu primera timeline
    public PlayableDirector timeline2; // Arrastra aqu� tu segunda timeline

    void Start()
    {
        // Inicia la primera timeline
        timeline1.Play();
    }

    void Update()
    {
        // Verifica si la primera timeline ha terminado
        if (timeline1.state == PlayState.Paused)
        {
            // Reproduce la segunda timeline
            timeline2.Play();
        }
    }
}