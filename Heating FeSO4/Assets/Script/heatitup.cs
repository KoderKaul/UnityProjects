using UnityEngine;

public class heatitup : MonoBehaviour
{
        Color c;
        public bool begin = false;
        public StartExp start;
        public Animator animator;
        [SerializeField] Material material;
        public ParticleSystem flame;
        public Rigidbody rigidbody1, rigidbody2, rigidbody3, rigidbody4;
        // Update is called once per frame
        void Start()
        {
                flame.Stop();
                material.color = new Color(0.3428266f, 0.6792453f, 0.5722482f, 1f);
        }
        void Update()
        {
                if (start.started)
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
                                                flame.Play();
                                        }
                                        if (hit.transform.CompareTag("Particle"))
                                        {
                                                animator.enabled = true;
                                                rigidbody1.isKinematic = false;
                                                rigidbody2.isKinematic = false;
                                                rigidbody3.isKinematic = false;
                                                rigidbody4.isKinematic = false;
                                        }
                                        if (hit.transform.CompareTag("TestTube"))
                                        {
                                                begin = true;
                                        }
                                }
                        }
                }
                if (flame.isPlaying && transform.position.x > 1.32f)
                {
                        c = material.color;
                        float i = c.r, j = c.b, k = c.g;
                        if (i < 0.3962264f)
                        {
                                i += 0.003f;
                        }
                        if (j > 0.0747597f)
                        {
                                j -= 0.003f;
                        }
                        if (k > 0f)
                        {
                                k -= 0.003f;
                        }
                        c.r = i;
                        c.b = j;
                        c.g = k;
                        material.color = c;
                }
        }
}
