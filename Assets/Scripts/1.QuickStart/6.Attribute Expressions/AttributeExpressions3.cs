using UnityEngine;
using Sirenix.OdinInspector;


namespace D_Game.Demo
{
    public class AttributeExpressions3 : MonoBehaviour
    {
        // Now, anywhere you declare it, myStr will now dynamically know the name of its parent
        [ShowInInspector]
        public Example exampleInstance;
    }

    public class Example
    {
        [InfoBox(@"@""This member's parent property is called "" + $exampleInstance")]
        public string myStr;
    }
}

