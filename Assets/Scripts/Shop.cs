using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncherTurret;
    public TurretBlueprint laserBeamerTurret;

    public TurretBlueprint teslaSecretTower;

    private BuildManager buildManager;
    #region
//    код відповідає за взаємодію з магазином в грі, де гравець може вибрати типи веж, які можна побудувати.

//Основні функції коду включають наступне:

//Оголошуються змінні для кожного типу вежі(стандартна вежа, вежа з ракетним запуском, вежа-лазер).
//Оголошується змінна для секретної вежі "Tesla".
//Оголошується змінна buildManager, яка представляє екземпляр менеджера будівництва.
//У методі Start() отримується посилання на екземпляр менеджера будівництва.
//У методах SelectStandardTurret(), SelectMissileLauncher(), SelectLaserBeamer() вибирається відповідний тип вежі і передається до менеджера будівництва.
//У методі SelectTeslaSecretTower() вибирається секретна вежа "Tesla" і передається до менеджера будівництва.
//Метод IsTesla(TurretBlueprint toTest) перевіряє, чи відповідає переданий параметр toTest типу "Tesla".
//У методі Update() перевіряється, чи введені користувачем відповідні комбінації клавіш для отримання секретної вежі "Tesla". Після введення правильної комбінації вибирається секретна вежа.
//Отже, цей код дозволяє гравцеві вибирати типи веж, які він може будувати в магазині, а також має секретну вежу, яку можна отримати за введення вірної комбінації клавіш.
    #endregion

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missileLauncherTurret);
    }

    public void SelectLaserBeamer()
    {
        buildManager.SelectTurretToBuild(laserBeamerTurret);
    }
}
