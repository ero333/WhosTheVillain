using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector timeline1; // Arrastra aquí tu primera timeline
    public PlayableDirector timeline2; // Arrastra aquí tu segunda timeline

    private bool timeline1Finished = false;
    private bool timeline2Started = false;

    void Start()
    {
        // Inicia la primera timeline
        timeline1.Play();
    }

    void Update()
    {
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
            // Aquí puedes añadir cualquier lógica adicional que necesites tras finalizar la segunda timeline
        }
    }
}