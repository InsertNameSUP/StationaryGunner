using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [System.Serializable]
    public struct Upgrade
    {
        public string name;
        public Sprite icon;
        public int cost;
        public int upgradeExponential;
        public int count;
    };
    public static ShopManager instance;
    public Upgrade[] gunUpgrades;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    public void OnShopBuy(int id) // Called from button press
    {
        UI.instance.CloseShop();
        GameStateManager.SetGameState(GameStateManager.GameState.Building);
        gunUpgrades[id].count += 1;
        print("Bought" + gunUpgrades[id].name + " | Price: " + gunUpgrades[id].cost);
         /* 
         ____________________________
         Handle bought upgrades here!
         ____________________________
         */
        gunUpgrades[id].cost = gunUpgrades[id].cost * gunUpgrades[id].upgradeExponential;

    }
}
