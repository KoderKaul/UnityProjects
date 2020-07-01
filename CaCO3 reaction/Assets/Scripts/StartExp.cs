using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartExp : MonoBehaviour
{
        public Button button;
        public Text text;
        public rotation obj;
        // Start is called before the first frame update
        public void StartExperiment()
        {
                if (text.text == "Restart Experiment")
                        Restart();
                text.text = "Restart Experiment";
                obj.start = true;
        }
        public void Restart()
        {
                SceneManager.LoadScene("SampleScene");
        }
}
