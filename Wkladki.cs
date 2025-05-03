using UnityEngine;
using UnityEngine.EventSystems;

public class Wkladki : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private char On = '-';
    public int tipBut;
    public static int nowBut = 1;

    void Start()
    {
        
    }


    void Update()
    {
        if (nowBut == tipBut)
        {
            transform.position = new Vector3(150, (-260 * tipBut) + 1190, 0);
        }
        else if (transform.position.x >= 150 && On == '+')
        {
            transform.position -= new Vector3(3, 0, 0);
        }
        else if (transform.position.x <= 300 && On == '-')
        {
            transform.position += new Vector3(3, 0, 0);
        }
        else
        {
            On = '=';
        }

        if (transform.position.x > 400)
        {
            transform.position = new Vector3(300, (-260 * tipBut) + 1190, 0);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Мышь вошла на UI элемент: " + gameObject.name);
        // Выполните действия при наведении мыши
        On = '+';
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Мышь покинула UI элемент: " + gameObject.name);
        // Выполните действия при уходе мыши
        On = '-';
    }

}
