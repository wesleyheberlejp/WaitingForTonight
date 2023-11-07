using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
public class CameraBackgroundComportamento : MonoBehaviour
{
    private Camera cameraPrincipal;

    [SerializeField]
    private Color corBackGroundCamera = Color.black;

 
    private void Start()
    {
        cameraPrincipal = Camera.main;

        if (cameraPrincipal != null)
        {
            cameraPrincipal.backgroundColor = corBackGroundCamera;
        }
    }
}
