using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpers
{
    public static string ToMinuteSecond(int seconds)
    {
        int minutes = seconds / 60;
        int rSeconds = seconds % 60;
        return string.Format("{0}:{1}", minutes.ToString("00"), rSeconds.ToString("00"));
    }
}
