using UnityEngine;
public class rotation : MonoBehaviour
{
        public ParticleSystem bubbles;
        public MeshRenderer liquid;
        public Animator animator, animator2;
        Color c;
        public bool opaque = false, start = false;
        void Update()
        {
                if (start)
                {
                        Input.simulateMouseWithTouches = true;
                        if (Input.GetMouseButtonDown(0))
                        {
                                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                                RaycastHit hit;
                                if (Physics.Raycast(ray, out hit))
                                {
                                        if (hit.transform.CompareTag("Selectable"))
                                        {
                                                animator2.enabled = true;
                                                start = false;
                                        }
                                }
                        }
                }
                if (opaque || bubbles.particleCount > 9)
                {
                        c = liquid.material.color;
                        float i = c.r, j = c.b, k = c.g;
                        if (i < 1.0f)
                        {
                                i += 0.005f;
                        }
                        if (j < 1.0f)
                        {
                                j += 0.005f;
                        }
                        if (k < 1.0f)
                        {
                                k += 0.005f;
                        }
                        if (i > 0.3749998f)
                                opaque = true;
                        c.r = i;
                        c.b = j;
                        c.g = k;
                        liquid.material.color = c;
                }
                if (opaque)
                {
                        animator.enabled = true;
                        bubbles.Stop();
                }
        }
}
