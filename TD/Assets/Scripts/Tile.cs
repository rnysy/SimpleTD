using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject curTurret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {   
        if(buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        if (curTurret != null)
        {
            Debug.Log("그곳에는 건설할수 없습니다");
            return;
        }

        GameObject turretTobuild = buildManager.GetTurretToBuild();
        curTurret = (GameObject)Instantiate(turretTobuild, transform.position + positionOffset, transform.rotation);
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (buildManager.GetTurretToBuild() == null)
            return;
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
