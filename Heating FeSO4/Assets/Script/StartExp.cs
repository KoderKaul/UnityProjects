using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartExp : MonoBehaviour
{
        public Button button;
        public Text text;
        public bool started = false;

        // Start is called before the first frame update
        public void StartExperiment()
        {
                if (text.text == "Restart Experiment")
                        Restart();
                text.text = "Restart Experiment";
                started = true;
        }
        public void Restart()
        {
                SceneManager.LoadScene("FeSO4");
        }
}
