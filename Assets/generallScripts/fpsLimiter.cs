using UnityEngine;

public class fpsLimiter : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
    }
}