using UnityEngine;
using UnityEngine.UI;

public class LockOnUI : MonoBehaviour
{
    public EnemyDetector detector;
    public Image crosshair;

    void Update()
    {
        if (detector.currentTarget != null)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
        }
    }
}