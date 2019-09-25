using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableContextMenuAttributeExample : MonoBehaviour
{
    [InfoBox("DisableContextMenu disables all right-click context menus provided by Odin. It does not disable Unity's context menu.", InfoMessageType.Warning)]
    [DisableContextMenu]
    public int[] NoRightClickList = new int[] { 2, 3, 5 };

    [DisableContextMenu(disableForMember: false, disableCollectionElements: true)]
    public int[] NoRightClickListOnListElements = new int[] { 7, 11 };

    [DisableContextMenu(disableForMember: true, disableCollectionElements: true)]
    public int[] DisableRightClickCompletely = new int[] { 13, 17 };



    [DisableContextMenu]
    public int NoRightClickField = 19;

    public int RightClickField = 19;

}
