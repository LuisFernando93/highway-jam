using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GasItem : Item
{
    [SerializeField] private int gas = 20;
    public override void Effect()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().FillGas(gas);
    }
}
