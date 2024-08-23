using UnityEngine;

public class InformationsManager : MonoBehaviour
{
    public void ManageInformations(GameObject information) => information.SetActive(!information.activeSelf);
}
