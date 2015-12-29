using System.ComponentModel;
using UnityEngine;

public class CoinHoleController : MonoBehaviour
{
    SceneUIController UIController;

    void Start()
    {
        UIController = GameObject.FindObjectOfType<SceneUIController>();
    }

    void OnTriggerEnter(Collider collider)
    {
        UIController.DisplayWinningImage();
    }
}
