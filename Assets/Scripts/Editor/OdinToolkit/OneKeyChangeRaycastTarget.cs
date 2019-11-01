using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[TypeInfoBox("批量选中或者取消对应UI上的Raycast")]
public class OneKeyChangeRaycastTarget : SerializedScriptableObject
    {

    private bool selectRaycastComplete;
    private bool cancelRaycastComplete;

    [PreviewField(50)]
    [OnValueChanged("SelectRaycastListValueChangeCallBack")]
    [HorizontalGroup("Raycast")]
    [PropertySpace(10,10)]
    [BoxGroup("Raycast/Left", false)]
    [LabelText("需要选中Raycast拖入进来")]
    public List<GameObject> SelectRaycastList = new List<GameObject>();

    public void SelectRaycastListValueChangeCallBack()
    {
        selectRaycastComplete = false;
    }


    [PreviewField(50)]
    [OnValueChanged("CancelRaycastListValueChangeCallBack")]
    [PropertySpace(10, 10)]
    [BoxGroup("Raycast/Right",false)]
    [LabelText("需要取消Raycast拖入进来")]
    public List<GameObject> CancelRaycastList = new List<GameObject>();

    public void CancelRaycastListValueChangeCallBack()
    {
        cancelRaycastComplete = false;
    }

    [HideIf("@selectRaycastComplete==true||SelectRaycastList.Count==0")]
    [BoxGroup("Raycast/Left")]
    [Button("勾选所有射线检测", ButtonSizes.Large, ButtonStyle.FoldoutButton)]
    public void SelectRaycast()
    {
        for (int i = 0; i < SelectRaycastList.Count; i++)
        {
            if (SelectRaycastList[i] == null)
            {
                continue;
            }
            Graphic[] graphicArray = SelectRaycastList[i].GetComponentsInChildren<Graphic>();
            for (int k = 0; k < graphicArray.Length; k++)
            {
                graphicArray[k].raycastTarget = true;
                EditorUtility.SetDirty(graphicArray[k]);
            }

            if (!AssetDatabase.Contains(SelectRaycastList[i]) &&PrefabUtility.IsPartOfPrefabInstance(SelectRaycastList[i]))//如果物体在场景中（Hierarchy中）而且还是预制体
            {
                PrefabUtility.ApplyPrefabInstance(SelectRaycastList[i], InteractionMode.UserAction);
            }
        }
        selectRaycastComplete = true;
        AssetDatabase.Refresh();
    }


    [HideIf("@cancelRaycastComplete==true||CancelRaycastList.Count==0")]
    [BoxGroup("Raycast/Right")]
    [Button("取消所有射线检测", ButtonSizes.Large, ButtonStyle.FoldoutButton)]
    public void CancelRaycast()
    {
        for (int i = 0; i < CancelRaycastList.Count; i++)
        {
            if (CancelRaycastList[i] == null)
            {
                continue;
            }
            Graphic[] graphicArray = CancelRaycastList[i].GetComponentsInChildren<Graphic>();
            for (int k = 0; k < graphicArray.Length; k++)
            {
                graphicArray[k].raycastTarget = false;
                EditorUtility.SetDirty(graphicArray[k]);
            }

            if (!AssetDatabase.Contains(CancelRaycastList[i]) && PrefabUtility.IsPartOfPrefabInstance(CancelRaycastList[i]))//如果物体在场景中（Hierarchy中）而且还是预制体
            {
                PrefabUtility.ApplyPrefabInstance(CancelRaycastList[i], InteractionMode.UserAction);
            }
        }
        cancelRaycastComplete = true;
        AssetDatabase.Refresh();
    }
}