using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("빌드매니저가 두 개 이상 씬에 있습니다.");
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject missileTurretPrefab;

    public GameObject buildEffect;

    private TurretManager turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HaveMoney { get { return PlayerStat.Money >= turretToBuild.cost; } }

    public void BuildTurret (Tile tile)
    {
        if (PlayerStat.Money < turretToBuild.cost)
        {
            Debug.Log("돈이 충분하지 않습니다");
            return;
        }

        PlayerStat.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, tile.GetBuildPosition(), Quaternion.identity);
        tile.curTurret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, tile.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("터렛 건설 완료! 남은돈 :" + PlayerStat.Money);
    }

    public void SelectTurretToBuild (TurretManager turret)
    {
        turretToBuild = turret;
    }
}
