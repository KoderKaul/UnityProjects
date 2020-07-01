using UnityEngine;
using UnityEngine.UI;

public class StartExp : MonoBehaviour
{
        enum ButtonType
        {
                Completed,
                Copper,
                Na,
                Ba,
                Pottasium

        }
        ButtonType _clicked;
        ButtonType clicked
        {
                get => _clicked;
                set
                {
                        Debug.Log(_clicked.ToString());
                        _clicked = value;
                        Debug.Log(_clicked.ToString());
                }
        }
        public Button button;

        // public heatitup obj;
        public Animator anim;
        Color c;
        Gradient gradient;
        public ParticleSystem flame;
        float time = 0;
        public Rigidbody Rigidbody;
        bool IsResetCompleted = true, karan = false;
        void Start()
        {
                flame.Stop();
                var main = flame.main;
                c = main.startColor.color;
                var col = flame.colorOverLifetime;
                gradient = col.color.gradient;
        }
        bool IsAlreadyReset = false;
        public void Reset()
        {
                IsResetCompleted = false;
                time = 0;
                Debug.Log("Reset Start");
                //changes the color back to normal
                flame.Stop();

                var main = flame.main;
                main.startColor = c;
                var col = flame.colorOverLifetime;
                col.color = gradient;
                flame.Play();
                Debug.Log("Reset Completed");
                IsResetCompleted = true;
        }
        void Update()
        {
                if (!IsResetCompleted)
                        return;
                time += Time.fixedDeltaTime;
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
                        }
                }
                //Touch starts the flame
                // if (flame.isStopped && Input.GetMouseButtonDown(0))
                // {
                //         flame.Play();
                // }
                var main = flame.main;
                if (Rigidbody.transform.position.x < -0.45)
                {
                        karan = true;
                        print("pod");
                }
                //when the spatula reaches the flame
                if (karan && Rigidbody.transform.position.x > -0.17)
                {
                        //startColor and ColoroverLiftime are changed according to the boolean
                        if (clicked == ButtonType.Copper)
                        {
                                Debug.Log("Start at : " + time);
                                main.startColor = new Color(0f, 1f, 0f, 1);
                                Debug.Log("time " + time + " ends.");
                                clicked = ButtonType.Completed;
                        }
                        if (clicked == ButtonType.Ba)
                        {
                                Debug.Log("Start at : " + time);
                                main.startColor = new Color(1f, 1f, 0f, 1);
                                Debug.Log("time " + time + " ends.");
                                clicked = ButtonType.Completed;
                        }
                        if (clicked == ButtonType.Pottasium)
                        {
                                Debug.Log("Start at : " + time);
                                main.startColor = new Color(1f, 0f, 0.399f, 1);
                                Debug.Log("time " + time + " ends.");
                                clicked = ButtonType.Completed;
                        }

                        if (clicked == ButtonType.Na)
                        {
                                Debug.Log("Start at : " + time);
                                main.startColor = new Color(1f, 0.9559f, 0f, 1);
                                Gradient grad = new Gradient();
                                grad.SetKeys(new GradientColorKey[] { new GradientColorKey(new Color(0, 0.1769555f, 0.7169812f), 0f), new GradientColorKey(new Color(0.5471698f, 0f, 0.08362977f), 0.412f) },
                                                        new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 0.0f) });

                                var col = flame.colorOverLifetime;
                                col.color = grad;
                                Debug.Log("time " + time + " ends.");
                                clicked = ButtonType.Completed;
                        }
                        karan = false;
                }
        }


        //4 functions that replay the translation and change colors
        public void KI() => ButtonClick(ButtonType.Pottasium);
        public void BaCl2() => ButtonClick(ButtonType.Ba);
        public void NaCl() => ButtonClick(ButtonType.Na);
        public void CuSO4() => ButtonClick(ButtonType.Copper);

        private void ButtonClick(ButtonType type)
        {
                anim.enabled = true;

                anim.Play("Translation", -1, 0f);
                Reset();
                clicked = type;
        }

}
