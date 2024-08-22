using UnityEngine;
using UnityEngine.Video;

public class VideoActivation : MonoBehaviour
{
    public Transform cameraTransform;  // Référence à la caméra principale
    public VideoPlayer videoPlayer;    // Référence au VideoPlayer attaché à la sphère
    public float sphereRadius = 5f;    // Le rayon de la sphère (ajustez en fonction de la taille réelle de votre sphère)

    private Vector3 sphereCenter;      // Centre de la sphère

    void Start()
    {
        // Calculer le centre de la sphère (utilisez la position de l'objet auquel ce script est attaché)
        sphereCenter = transform.position;

        // Assurez-vous que la vidéo est désactivée au départ
        videoPlayer.Pause();
        videoPlayer.enabled = false;
    }

    void Update()
    {
        // Calculer la distance entre la caméra et le centre de la sphère
        float distanceToCenter = Vector3.Distance(cameraTransform.position, sphereCenter);

        // Vérifier si la caméra est à l'intérieur de la sphère
        if (distanceToCenter <= sphereRadius)
        {
            if (!videoPlayer.isPlaying)
            {
                videoPlayer.enabled = true;
                videoPlayer.Play();
            }
        }
        else
        {
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Pause();
                videoPlayer.enabled = false;
            }
        }
    }
}
