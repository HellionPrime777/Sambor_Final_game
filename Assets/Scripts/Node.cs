using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    private Color startColor;

    public Vector3 positionOffset;

    private Renderer rend;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private BuildManager buildManager;

    #region
    //    код відповідає за функціональність вузла(Node) гри.Основні функції коду включають наступне:

    //Задаються змінні для кольорів hoverColor(колір при наведенні курсора), notEnoughMoneyColor(колір, коли недостатньо коштів) і startColor(початковий колір).
    //Визначається зміщення позиції побудови(positionOffset) відносно вузла.
    //Отримується посилання на компонент Renderer вузла і зберігається початковий колір в змінну startColor.
    //Встановлюється посилання на екземпляр BuildManager.
    //Визначається позиція для побудови турелі в методі GetBuildPosition(), додаючи positionOffset до позиції вузла.
    //Метод UpgradeTurret() виконує покращення турелі, перевіряючи наявність достатньо коштів, зменшуючи кількість грошей гравця, знищуючи поточну турелю, створюючи покращену турелю на місці побудови і встановлюючи прапорець isUpgraded.
    //Метод BuildTurret() виконує побудову турелі, перевіряючи наявність достатньо коштів, зменшуючи кількість грошей гравця, створюючи турелю на місці побудови і встановлюючи turretBlueprint.
    //Метод SellTurret() виконує продаж турелі, збільшуючи кількість грошей гравця, знищуючи поточну турелю і скидаючи turretBlueprint і прапорець isUpgraded.
    //У методі OnMouseDown() перевіряється, чи натиснута ліва кнопка миші і якщо так, то перевіряється, чи на елементом графічного інтерфейсу необхідної обробки подій (UI), чи наявна туреля на вузлі.Якщо так, вибирається цей вузол через buildManager.SelectNode(), в іншому випадку виконується побудова турелі.
    //Методи OnMouseEnter() та OnMouseExit() змінюють колір вузла при наведенні курсора на нього.Колір змінюється на hoverColor, якщо гравець має достатньо коштів для побудови, або на notEnoughMoneyColor, якщо недостатньо коштів.
    #endregion

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

  

    private void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.money < blueprint.cost)
        {
            Debug.Log("No Money");
            return;
        }

        PlayerStats.money -= blueprint.cost;

        turretBlueprint = blueprint;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1.05f);

    }

  

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.canBuild)
        {
            return;
        }

        BuildTurret(buildManager.getTurretToBuild());
    }

    private void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.canBuild)
        {
            return;
        }

        if(buildManager.hasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
