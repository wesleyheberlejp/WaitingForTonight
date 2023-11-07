using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

public class UtilitarioConvert
{
    public static Vector3 StringToVector3(string vectorString)
    {
        string[] values = vectorString.Split(',');
        if (values.Length == 3)
        {
            CultureInfo culture = new CultureInfo("en-US");

            float x = float.Parse(values[0], culture);
            float y = float.Parse(values[1], culture);
            float z = float.Parse(values[2], culture);
            return new Vector3(x, y, z);
        }
        else
        {
            Debug.LogError("String de vetor inválida: " + vectorString);
            return Vector3.zero;
        }
    }

    public static Texture2D Base64ToTexture2D(string base64)
    {
        byte[] imageBytes = Convert.FromBase64String(base64);
        var MaterialAtual = new Texture2D(1, 1);
        MaterialAtual.LoadImage(imageBytes);
        return MaterialAtual;
    }

    public static string Vector3ToString(Vector3 vector)
    {
        CultureInfo culture = new CultureInfo("en-US");

        return $"{vector.x.ToString(culture)},{vector.y.ToString(culture)},{vector.z.ToString(culture)}";
    }

    public static string QuaternionToString(Quaternion quaternion)
    {
        CultureInfo culture = new CultureInfo("en-US");
        return quaternion.x.ToString(culture) + "," + quaternion.y.ToString(culture) + "," + quaternion.z.ToString(culture);
    }

    public static Quaternion StringToQuaternion(string quaternionString)
    {
        var quaternionVector = StringToVector3(quaternionString);
        return Quaternion.Euler(quaternionVector);
    }

    public static bool StringToBool(string valor)
    {
        return valor == "T" ? true : false;
    }

    public static string BoolToString(bool valor)
    {
        var letra = valor.ToString().ToUpper()[0];
        return letra.ToString();

    }

    public static Sprite Base64ToSprite(string base64)
    {
        byte[] imageBytes = Convert.FromBase64String(base64);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(imageBytes);

        Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);

        return sprite;
    }

    public static void  ENumToListInt()
    {

    }

    public static Dictionary<int, string> EnumToDictionary<T>() where T : Enum
    {
       return EnumExtensionMethods.GetEnumDictionary<T>();
    }
}
