using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//код виконує функції для зберігання інформації про вежу, її вартість, покращення та отримання суми продажу.

[System.Serializable]
public class TurretBlueprint {
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public string name;

    public int GetSellAmount()
    {
        return (int)(cost * 0.45);
    }
}
