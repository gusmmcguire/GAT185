using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    Material material;
    float alpha;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        alpha = 0;
        StartCoroutine(Timer(2));
        StartCoroutine(UpdateAI(0.01f));
    }

    // Update is called once per frame
    void Update()
    {
        //FadeIn();
        StartCoroutine(FadeInRoutine());
    }

    void FadeIn()
    {
        alpha += Time.deltaTime / 5;
        alpha = Mathf.Min(alpha, 1);

        Color color = material.color;
        color.a = alpha;
        material.color = color;
    }

    IEnumerator FadeInRoutine()
    {
        while(alpha < 1)
        {
            alpha += Time.deltaTime / 20;
            alpha = Mathf.Min(alpha, 1);

            Color color = material.color;
            color.a = alpha;
            material.color = color;
            yield return null;

        }
    }

    IEnumerator Timer(float time)
    {
        print("hello");
        yield return new WaitForSeconds(time);

        print("world");
        yield return new WaitForSeconds(time);

        print("goodbye");

    }

    IEnumerator UpdateAI(float time)
    {
        for(;;)
        {
            print("thinking...");
            yield return new WaitForSeconds(time);
        }
    }
}
