using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;

    public float scrollSpeed = 5f;

    public float minY = 20f;
    public float maxY = 95f;

    private Vector3 startPosOfCam = new Vector3(38.6f, 78.4f, -21.6f);
    private Vector3 returnBackPosOfCam = new Vector3(38.6f, 78.4f, -21.6f);

    #region
    //    код відповідає за управління камерою в грі.Основні функції, які він виконує:

    //Визначає швидкість переміщення камери(panSpeed) і швидкість прокрутки(scrollSpeed).
    //Визначає мінімальну(minY) і максимальну(maxY) висоту, на яку можна підняти або опустити камеру.
    //Зберігає початкову позицію камери(startPosOfCam) і позицію для повернення(returnBackPosOfCam).
    //В методі "Update" перевіряє, чи гра завершилася.Якщо так, то вимикає керування камерою.
    //Обробляє натискання клавіш для переміщення камери вперед, назад, вліво та вправо.
    //Обробляє натискання клавіші для повернення камери до початкової позиції(CamOrigin).
    //Обробляє натискання клавіші для повернення камери до останньої збереженої позиції(CamOrigin M).
    //Обробляє прокрутку колесика миші для зміни висоти камери.
    //Обмежує висоту камери у заданих межах (minY та maxY).
    //В загальному, цей клас CameraController забезпечує можливість рухати камеру в грі вперед, назад, вліво, вправо, змінювати її висоту і повертатися до початкової або попередньо збереженої позиції камери.
    #endregion

    void Update()
    {
        if(GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }

        //вперед
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        //Назад
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }


        //ВЛІВО
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        //Вправо
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        //[CamOrigin]
        //Поверніться до початкового положення камери
        if (Input.GetKeyDown(KeyCode.C))
        {
            returnBackPosOfCam = transform.position;
            transform.position = startPosOfCam;
        }

        //Повернутися до останньої збереженої позиції камери, коли використовується [CamOrigin] (за замовчуванням = вихідна позиція)
        if (Input.GetKeyDown(KeyCode.M))
        {
            transform.position = returnBackPosOfCam;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 800 * scrollSpeed * Time.deltaTime;

        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
