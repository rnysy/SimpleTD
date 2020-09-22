using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret()
    {
        Debug.Log("기본 터렛을 샀습니다.");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseMissileTurret()
    {
        Debug.Log("미사일 터렛을 샀습니다.");
        buildManager.SetTurretToBuild(buildManager.missileTurretPrefab);
    }
}
