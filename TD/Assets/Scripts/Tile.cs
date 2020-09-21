using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject curTurret;

    private Renderer rend;
    private Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (curTurret != null)
        {
            Debug.Log("그곳에는 건설할수 없습니다");
            return;
        }

        GameObject turretTobuild = BuildManager.instance.GetTurretToBuild();
        curTurret = (GameObject)Instantiate(turretTobuild, transform.position + positionOffset, transform.rotation);
    }
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
