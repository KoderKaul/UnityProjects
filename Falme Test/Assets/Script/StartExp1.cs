using UnityEngine;
using UnityEngine.UI;

public class StartExp1 : MonoBehaviour
{
        public Animator Animation;

        public ParticleSystem Flame;

        public Button NaCl;
        public Button KI;
        public Button CuSO4;
        public Button BaCl2;

        private enum ButtonType
        {
                Completed,
                Copper,
                Na,
                Ba,
                Pottasium
        }

        private ButtonType Clicked;
        private Color c;
        private Gradient gradient;
        private float time = 0;

        private void Start()
        {
                Flame.Stop();

                c = Flame.main.startColor.color;
                gradient = Flame.colorOverLifetime.color.gradient;

                NaCl.onClick.AddListener(() => ButtonClick(ButtonType.Na));
                BaCl2.onClick.AddListener(() => ButtonClick(ButtonType.Ba));
                CuSO4.onClick.AddListener(() => ButtonClick(ButtonType.Copper));
                KI.onClick.AddListener(() => ButtonClick(ButtonType.Pottasium));
        }

        private void Update()
        {
                time += Time.deltaTime;

                Input.simulateMouseWithTouches = true;

                if (Input.GetMouseButtonDown(0))
                {
                        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        if (Physics.Raycast(ray, out RaycastHit hit))
                        {
                                if (hit.transform.CompareTag("Selectable"))
                                {
                                        Flame.Play();
                                }
                        }
                }


                if (time >= 0.85f && Clicked != ButtonType.Completed)
                {
                        switch (Clicked)
                        {
                                case ButtonType.Copper:
                                        SetFlame(new Color(0, 1, 0, 1));

                                        goto default;

                                case ButtonType.Ba:
                                        SetFlame(new Color(1, 1, 0, 1));

                                        goto default;

                                case ButtonType.Pottasium:
                                        SetFlame(new Color(1f, 0f, 0.399f, 1));

                                        goto default;

                                case ButtonType.Na:

                                        SetFlame(
                                            new Color(1f, 0.9559f, 0f, 1),
                                            new Gradient
                                            {
                                                    colorKeys = new GradientColorKey[]
                                                {
                                new GradientColorKey(new Color(0, 0.1769555f, 0.7169812f), 0f),
                                new GradientColorKey(new Color(0.5471698f, 0f, 0.08362977f), 0.412f)
                                                },
                                                    alphaKeys = new GradientAlphaKey[]
                                                {
                                new GradientAlphaKey(1.0f, 0.0f),
                                new GradientAlphaKey(1.0f, 0.0f)
                                                }
                                            });

                                        goto default;

                                default:
                                        Clicked = ButtonType.Completed;
                                        break;
                        }
                }
        }

        private void ButtonClick(ButtonType type)
        {
                Animation.enabled = true;

                Animation.Play("Translation", -1, 0f);

                time = 0;

                SetFlame(c, gradient);
                Flame.Play();

                Clicked = type;
        }

        void SetFlame(Color color, Gradient g = null)
        {
                var main = Flame.main;
                main.startColor = color;

                var col = Flame.colorOverLifetime;
                col.color = g ?? col.color;
        }
}