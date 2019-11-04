using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuppressInvalidAttributeErrorExample : MonoBehaviour
{
    [Range(0, 10)]
    public string InvalidAttributeError = "This field will have an error box for the Range attribute on a string field.";

    [Range(0, 10), SuppressInvalidAttributeError]
    public string SuppressedError = "The error has been suppressed on this field, and thus no error box will appear.";
}
