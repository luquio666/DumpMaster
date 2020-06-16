using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEditor;
using System.Diagnostics;

public class PropertyValue : MonoBehaviour
{
    public Text LabelTitle, LabelValue;
    public UnityEvent AddEvent, SubEvent;

    public void ButtonAdd()
    {
        AddEvent.Invoke();
    }
    public void ButtonSub()
    {
        SubEvent.Invoke();
    }

}