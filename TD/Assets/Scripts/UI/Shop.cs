using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretManager standardTurret;
    public TurretManager missileTurret;
    public TurretManager laserTurret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("기본 터렛을 샀습니다.");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileTurret()
    {
        Debug.Log("미사일 터렛을 샀습니다.");
        buildManager.SelectTurretToBuild(missileTurret);
    }
    public void SelectLaserTurret()
    {
        Debug.Log("미사일 터렛을 샀습니다.");
        buildManager.SelectTurretToBuild(laserTurret);
    }
}
