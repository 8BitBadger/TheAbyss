using UnityEngine;

namespace FlexibleUI
{
    public class FlexibleUI : MonoBehaviour
    {

        public FlexibleUIData skinData;

        protected virtual void OnSkinUI()
        {

        }

        public virtual void Awake()
        {
            OnSkinUI();
        }
    }
}