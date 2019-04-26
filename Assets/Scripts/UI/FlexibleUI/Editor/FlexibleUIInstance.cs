using UnityEngine;
using UnityEditor;

namespace FlexibleUI
{
    public class FlexibleUIInstance : Editor
    {

        [MenuItem("GameObject/Flexible UI/Button", priority = 0)]
        public static void AddButton()
        {
            Create("button");
        }

        static GameObject clickedObject;

        private static GameObject Create(string objectName)
        {
            GameObject instance = Instantiate(Resources.Load<GameObject>(objectName));
            instance.name = objectName;
            clickedObject = Selection.activeObject as GameObject;
            if (clickedObject != null)
            {
                instance.transform.SetParent(clickedObject.transform, false);
            }
            return instance;
        }
    }
}