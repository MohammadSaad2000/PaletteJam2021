using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public enum GameColor {
        Blue,
        Red,
        Purple,
        None
    }

    public static Color UniversalBlue = new Color(0, 0, 1, 1);
    public static Color UniversalRed = new Color(1, 0, 0, 1);
    public static Color UniversalPurple = new Color(1, 0, 1, 1);
    public GameColor gameColor = GameColor.None;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static bool isOpposite(GameColor color1, GameColor color2)
    {
        return (color1 == GameColor.Red && color2 == GameColor.Blue) || (color1 == GameColor.Blue && color2 == GameColor.Red);
    }

    public static bool isSame(GameColor color1, GameColor color2)
    {
        return color1 == color2;
    }


    public static Color getRenderColor(GameColor gameColor)
    {
        if (gameColor == GameColor.Blue)
        {
            return UniversalBlue;
        }
        else if (gameColor == GameColor.Red)
        {
            return UniversalRed;
        }
        else if (gameColor == GameColor.Purple)
        {
            return UniversalPurple;
        }
        else
            return new Color(1, 1, 1, 1);
    }

}
