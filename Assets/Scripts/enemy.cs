using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy :MonoBehaviour
{
   public enum Color
    {
        RED,
        BLUE
    }
    public string getColorCode(Color color)
    {
        string colorCode;
        switch (color)
        {
            case Color.BLUE:
                colorCode = "FF0000" ;
                return colorCode;
            case Color.RED:
                colorCode = "2626FF";
                return colorCode;
        }
        return "FFFFFF";
    }
}
