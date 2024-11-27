using UnityEngine;
using TMPro;

namespace LevelUP.Dial
{
    public class DialRotationDisplay : MonoBehaviour, IDial
    {
        [SerializeField] TextMeshProUGUI textBox;
        public GameObject DialManagerHolder;
        public AudioSource DialAudio;
        DialManager manager => DialManagerHolder.GetComponent<DialManager>();

        public void DialChanged(float dialValue)
        {
            Debug.Log("Dial changed: " + dialValue);
            dialValue = normalize(dialValue);
            DialAudio.Play();
            switch (dialValue)
            {
                case (0):
                    textBox.text = "1";
                    break;
                case (45):
                    textBox.text = "2";
                    break;
                case (90):
                    textBox.text = "3";
                    break;
                case (135):
                    textBox.text = "4";
                    break;
                case (180):
                    textBox.text = "5";
                    break;
                case (225):
                    textBox.text = "6";
                    break;
                case (270):
                    textBox.text = "7";
                    break;
                case (315):
                    textBox.text = "8";
                    break;
            }
            manager.OpenDial();
        }

        public float normalize(float dialValue)
        {
            if (dialValue > -10 && dialValue < 10)
            {
                dialValue = 0;
            }

            if (dialValue > 35 && dialValue < 55)
            {
                dialValue = 45;
            }

            if (dialValue > 80 && dialValue < 100)
            {
                dialValue = 90;
            }

            if (dialValue > 125 && dialValue < 145)
            {
                dialValue = 135;
            }

            if (dialValue > 170 && dialValue < 190)
            {
                dialValue = 180;
            }
            
            if (dialValue > 215 && dialValue < 235)
            {
                dialValue = 225;
            }
            
            if (dialValue > 260 && dialValue < 280)
            {
                dialValue = 270;
            }
            
            if (dialValue > 305 && dialValue < 325)
            {
                dialValue = 315;
            }
            
            return dialValue;
        }
    }
}
