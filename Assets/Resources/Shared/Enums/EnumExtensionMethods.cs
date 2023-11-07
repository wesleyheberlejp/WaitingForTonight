using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class EnumExtensionMethods
{
    public static string GetDescription(this Enum GenericEnum)
    {
        Type genericEnumType = GenericEnum.GetType();
        MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
        if ((memberInfo != null && memberInfo.Length > 0))
        {
            var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
            if ((_Attribs != null && _Attribs.Count() > 0))
            {
                return ((System.ComponentModel.DescriptionAttribute)_Attribs.ElementAt(0)).Description;
            }
        }
        return GenericEnum.ToString();
    }

    public static Dictionary<int, string> GetEnumDictionary<T>() where T : Enum
    {
        if (!typeof(T).IsEnum)
        {
            throw new ArgumentException("Type parameter must be an enum");
        }

        Dictionary<int, string> enumDictionary = new Dictionary<int, string>();

        foreach (T value in Enum.GetValues(typeof(T)))
        {
            int key = (int)Enum.Parse(typeof(T), value.ToString());
            string description = GetDescription(value);
            enumDictionary[key] = description;
        }

        return enumDictionary;
    }
}
