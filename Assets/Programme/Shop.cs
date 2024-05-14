using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    private BuildManager buildManager;
    public TurretBlueprint machineGun;
    public TurretBlueprint missileLauncher;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {SelectStandardTurret(); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { SelectMissileLauncher(); }
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Machine gun select");
        buildManager.SelectTurretToBuild(machineGun);
    }
    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher select");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
}
