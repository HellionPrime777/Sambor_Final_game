using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    private Node target;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;
    #region
    //    код відповідає за керування інтерфейсом користувача(UI) вузла(Node). Основні функції коду включають наступне:

    //Задається змінна для посилання на графічний елемент(GameObject) ui, який представляє собою інтерфейс вузла.
    //Задається змінна для посилання на вузол(Node) target, з яким пов'язаний цей інтерфейс.
    //Задаються змінні для текстових полів upgradeCost(вартість покращення турелі) і sellAmount(сума продажу турелі).
    //Задається метод SetTarget(), який встановлює вузол, до якого прив'язаний цей інтерфейс. В методі встановлюються позиція інтерфейсу на основі позиції вузла. В залежності від того, чи покращена туреля на вузлі, встановлюються значення текстових полів upgradeCost і sellAmount. Також відображається інтерфейс.
    //Задається метод Hide(), який приховує інтерфейс вузла.
    //Задаються методи Upgrade() і Sell(), які виконують покращення турелі і продаж турелі відповідно. Після виконання операцій вузол вибирається за допомогою метода DeselectNode() з класу BuildManager.
    //Отже, цей код управляє відображенням та функціональністю інтерфейсу вузла, включаючи покращення турелі та продаж.
    #endregion

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "-" + target.turretBlueprint.upgradeCost + "$";
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "[]";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "+" + target.turretBlueprint.GetSellAmount() + "$";

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
