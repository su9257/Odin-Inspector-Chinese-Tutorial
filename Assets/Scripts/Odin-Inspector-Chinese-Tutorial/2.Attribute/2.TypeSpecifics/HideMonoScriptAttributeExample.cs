using Sirenix.OdinInspector;
using UnityEngine;



    public class HideMonoScriptAttributeExample : MonoBehaviour
    {
    [InfoBox("Click the pencil icon to open new inspector for these fields.")]
    public HideMonoScript Hidden;

    // The script will also be hidden for the ShowMonoScript object if MonoScripts are hidden globally.
    //如果MonoScripts是全局隐藏的，那么ShowMonoScript对象的脚本也将被隐藏。
    public ShowMonoScript Shown;

        public void Start()
        {
            Hidden = ExampleHelper.GetScriptableObject<HideMonoScript>();
            Shown = ExampleHelper.GetScriptableObject<ShowMonoScript>();
        }
    }


