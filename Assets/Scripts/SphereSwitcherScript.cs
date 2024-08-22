using UnityEngine;

public class SphereSwitcher : MonoBehaviour
{
    public GameObject[] spheres;  // Tableau contenant toutes les sphères
    public Transform cameraTransform;  // Référence à la caméra
    private int currentSphereIndex = 0;  // Index de la sphère actuellement active

    public void SwitchSphere(int sphereIndex)
    {
        if (sphereIndex >= 0 && sphereIndex < spheres.Length)
        {
            // Désactiver la sphère actuelle
            spheres[currentSphereIndex].SetActive(false);

            // Activer la nouvelle sphère
            spheres[sphereIndex].SetActive(true);

            // Déplacer la caméra au centre de la nouvelle sphère active
            cameraTransform.position = spheres[sphereIndex].transform.position;

            // Mettre à jour l'index courant
            currentSphereIndex = sphereIndex;
        }
    }
}
