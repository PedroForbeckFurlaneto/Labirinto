using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cronometro : MonoBehaviour
{
    public float time;
    private float intervalo = 0.1f;
    public TMP_Text tempoText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0.0f)
        {
            return;
        }
        time -= Time.deltaTime;
        if (time < 0)
        {
            time = 0.0f;
        }

        int min = Mathf.FloorToInt(time / 60);
        float sec = time - (min * 60);

        tempoText.text = $"{min.ToString("#00")}:{sec.ToString("#00.0")}";

    }
}
