using UnityEngine;

using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;

namespace D_Game.Demo
{
    public class SimpleAttributeExamples4 : MonoBehaviour
    {
        [LabelText("$IAmLabel")]
        public string IAmLabel;

        [ListDrawerSettings(
            CustomAddFunction = "CreateNewGUID",
            CustomRemoveIndexFunction = "RemoveGUID")]
        public List<string> GuidList;

        private string CreateNewGUID()
        {
            return Guid.NewGuid().ToString();
        }

        private void RemoveGUID(int index)
        {
            this.GuidList.RemoveAt(index);
        }
    }
}

