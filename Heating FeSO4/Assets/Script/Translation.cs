using UnityEngine;

public class Translation : MonoBehaviour
{
        public Animator animation;
        public heatitup obj;

        // Update is called once per frame
        void Update()
        {
                if (obj.begin)
                {
                        animation.enabled = true;
                }
        }
}
