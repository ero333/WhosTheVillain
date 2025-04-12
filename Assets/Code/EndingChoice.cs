using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingChoice : MonoBehaviour
{
    public string endingASceneName = "EndingA";
    public string endingBSceneName = "EndingB";

    public void OnButton1Pressed()
    {
        AnalyticsManager.Instance.SendChoiceEvent(1);
        SceneManager.LoadScene(endingASceneName);
    }

    public void OnButton2Pressed()
    {
        AnalyticsManager.Instance.SendChoiceEvent(2);
        SceneManager.LoadScene(endingBSceneName);
    }
}