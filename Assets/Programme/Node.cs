using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Color hoverColor = Color.cyan;
    public Color notEnoughMoneyColor = Color.red;
    public Vector3 positionOffset;
    private Color startColor;
    public GameObject turret;
    private Renderer rend;

    private BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    private void OnMouseDown()
    {
        if(!buildManager.canBuild)
        {
            return;
        }

        if (turret != null)
        {
            return;
        }
        buildManager.BuildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        if (buildManager.hasMoney)
        {
            rend.material.color = notEnoughMoneyColor;
        }
        if (!buildManager.canBuild)
        {
            return;
        }
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
