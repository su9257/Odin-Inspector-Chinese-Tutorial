using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InlineButtonAttributeExample : MonoBehaviour
{
    // Inline Buttons:
    [InlineButton("A")]
    public int InlineButton;

    [InlineButton("A")]
    [InlineButton("B", "Custom Button Name")]
    public int ChainedButtons;

    private void A()
    {
        Debug.Log("A");
    }

    private void B()
    {
        Debug.Log("B");
    }
}
