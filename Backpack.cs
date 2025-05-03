using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Backpack : MonoBehaviour
{
    public static int apple = 0;
    public static int bread = 0;
    public static int potato = 0;
    public static int carrot = 0;
    public static int hotdog = 0;
    public static int soda = 0;
    public static int aomthung = 0;
    public static int healka = 0;
    public static int appleSandwich = 0;
    public static int butterSandwich = 0;
    public static int butter = 0;
    public static int sasuge = 0;

    public static int desk = 0;
    public static int tree = 0;
    public static int glass = 0;

    public TMP_Text[] toolText;

    void Start()
    {
        
    }

    void Update()
    {
        if (Wkladki.nowBut == 1)
        {
            toolText[0].text = apple.ToString();
            toolText[1].text = bread.ToString();
            toolText[2].text = potato.ToString();
            toolText[3].text = carrot.ToString();
            toolText[4].text = aomthung.ToString();
            toolText[5].text = hotdog.ToString();
            toolText[6].text = healka.ToString();
            toolText[7].text = soda.ToString();
            toolText[0].text = butter.ToString();
            toolText[0].text = butterSandwich.ToString();
            toolText[0].text = appleSandwich.ToString();
            toolText[0].text = sasuge.ToString();
        }
    }
}
