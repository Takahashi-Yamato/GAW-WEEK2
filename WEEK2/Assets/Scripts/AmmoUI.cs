using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    public GunShot gun;
    public Text ammoText;

    void Update()
    {
        if (gun.isReloading)
        {
            ammoText.text = "Reloading...";
        }
        else
        {
            ammoText.text = gun.currentAmmo + " / " + gun.maxAmmo;
        }
    }
}