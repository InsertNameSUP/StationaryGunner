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
    };
    public Upgrade[] gunUpgrades;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
