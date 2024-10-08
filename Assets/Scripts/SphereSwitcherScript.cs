using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public Animator fadeAnim;

    public void ChangeSphere(GameObject destination)
    {
        GameObject currentSphere = FindObjectOfType<VideoPlayer>().gameObject;
        StartCoroutine(StartNextVideo(currentSphere, destination));
    }

    /* Coroutine to load the next video during the transition animation. */
    private IEnumerator StartNextVideo(GameObject currentSphere, GameObject destination)
    {
        VideoPlayer videoPlayer = destination.GetComponentInChildren<VideoPlayer>();

        fadeAnim.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        destination.SetActive(true);
        transform.position = destination.transform.position;
        while (!videoPlayer.isPlaying)
            yield return null;
        ActivateCanvas(currentSphere, destination.GetComponentInChildren<Canvas>());
    }

    /* Activates the canvas of the current sphere. */
    private void ActivateCanvas(GameObject currentSphere, Canvas destinationCanvas)
    {
        GameObject[] informations = GameObject.FindGameObjectsWithTag("Informations");

        currentSphere.SetActive(false);

        foreach (GameObject infoBubble in informations)
            infoBubble.SetActive(false);

        destinationCanvas.enabled = true;
    }
}
