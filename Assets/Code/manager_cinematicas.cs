using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector timeline0;
    public PlayableDirector timeline1;
    public PlayableDirector timeline2;

    void Start()
    {
        // Inicia la primera timeline
        timeline0.Play();
        timeline0.stopped += OnTimeline0Finished; // Suscribirse al evento
    }

    private void OnTimeline0Finished(PlayableDirector director)
    {
        timeline1.Play();
        timeline1.stopped += OnTimeline1Finished; // Suscribirse al evento
    }

    private void OnTimeline1Finished(PlayableDirector director)
    {
        timeline2.Play();
        // No es necesario suscribirse aquí a menos que necesites más lógica.
    }
}
