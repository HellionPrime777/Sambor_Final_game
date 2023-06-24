using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region Singleton
    public static BuildManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError(" [BuildManager] ");
            return;
        }
        instance = this;
    }
    #endregion
    #region
    //    код відповідає за керування побудовою веж у грі.Основні функції, які він виконує:

    //Забезпечує існування лише одного екземпляра класу BuildManager (Singleton pattern).
    //Зберігає посилання на об'єкт, який представляє візуальний ефект побудови вежі.
    //Зберігає посилання на компонент NodeUI, який відповідає за інтерфейс користувача для взаємодії з вузлами.
    //Зберігає обраний користувачем блупрінт (конфігурацію) для вежі, яку він хоче побудувати.
    //Зберігає посилання на вузол, який обрано для побудови вежі.
    //Надає можливість вибрати блупрінт для побудови вежі.
    //Надає можливість вибрати вузол для побудови вежі.
    //Надає можливість скасувати вибір вузла або блупрінта.
    //Перевіряє, чи можна побудувати вежу (тобто чи вибраний блупрінт не є порожнім).
    //Перевіряє, чи у гравця достатньо коштів для побудови вежі.
    #endregion

    public GameObject buildEffect;

    public NodeUI nodeUI;

    [HideInInspector]
    public TurretBlueprint turretToBuild;
    private Node selectedNode;

    public bool canBuild { get { return turretToBuild != null; } }
    public bool hasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBlueprint getTurretToBuild()
    {
        return turretToBuild;
    }

    public void SelectNode(Node node)
    {
        if(node == selectedNode)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
}
