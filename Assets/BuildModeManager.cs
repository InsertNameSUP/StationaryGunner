using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildModeManager : MonoBehaviour
{
    GameObject hoverUpgrade;
    public static BuildModeManager instance;
    bool inBuildMode;
    bool gunSlotAvailable;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if(hoverUpgrade != null && inBuildMode)
        {

            // Sexy ass phasing effect
            hoverUpgrade.GetComponent<SpriteRenderer>().color = new Color(hoverUpgrade.GetComponent<SpriteRenderer>().color.r, hoverUpgrade.GetComponent<SpriteRenderer>().color.g, hoverUpgrade.GetComponent<SpriteRenderer>().color.b, Mathf.PingPong(Time.time * 15, 1));

            Transform closestGunSlot = null;
            foreach(Transform s in Gunner.instance.gunSlots) // Find closest gun slot
            {
                if(closestGunSlot == null || Vector3.Distance(s.position, Util.TwoD.Mouse.GetMouseWorldPos()) < Vector3.Distance(closestGunSlot.position, Util.TwoD.Mouse.GetMouseWorldPos()))
                {
                    closestGunSlot = s;
                }
            }
            if(closestGunSlot != null)
            {
                gunSlotAvailable = true;
                // Display the soon to be built gun in the set location
                hoverUpgrade.transform.position = closestGunSlot.position;
                hoverUpgrade.transform.rotation = closestGunSlot.rotation;
            } else
            {
                gunSlotAvailable = false;
                hoverUpgrade.transform.position = Util.TwoD.Mouse.GetMouseWorldPos();
            }

            if(Input.GetMouseButtonDown(0))
            {
                hoverUpgrade.GetComponent<Collider2D>().enabled = true;
                hoverUpgrade.GetComponent<GunBase>().enabled = true;
                hoverUpgrade.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                hoverUpgrade.transform.parent = closestGunSlot;
                Gunner.instance.gunSlots.Remove(closestGunSlot);
                hoverUpgrade = null;
                GameStateManager.SetGameState(GameStateManager.GameState.Playing);
            }

        }
    }
    public void EnterBuildMode(ShopManager.Upgrade upgrade)
    {
        inBuildMode = true;
        hoverUpgrade = Instantiate(upgrade.prefab);
        hoverUpgrade.GetComponent<Collider2D>().enabled = false;
        hoverUpgrade.GetComponent<GunBase>().enabled = false;
    }
    public void ExitBuildMode()
    {
        inBuildMode = false;
    }
}
