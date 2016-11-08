using UnityEngine;
using System;
using System.Collections.Generic;

public class Music : MonoBehaviour
{

    public GameObject display;

    private int m_NumSamples = 1024;
    private float[] m_SamplesL;
    private float translate;
    private float nTranslate;
    private float Slop;
    public ParticleSystem Explo;
    private Vector3 leftwall;
    private Vector3 rightwall;

    List<GameObject> cubes = new List<GameObject>();

    double bassIntensity = 0;


    void Start()
    {
        leftwall = new Vector3(-7, 0, 0);
        rightwall = new Vector3(7, 0, 0);
        if (display == null)
            throw new Exception("Why you didn't assign cube brah'?!");

        m_SamplesL = new float[m_NumSamples];

        int counter = 0;
        for (int i = 0; i < m_NumSamples; i++)
        {
            if (i % 10 == 0)
            {
                cubes.Add(Instantiate(display,leftwall+ Vector3.up * counter++, Quaternion.identity) as GameObject);
                cubes.Add(Instantiate(display, rightwall + Vector3.up * counter++, Quaternion.identity) as GameObject);
                //cubes[cubes.Count - 1].GetComponent<DebugSamples>().sample = i;
            }
        }
    }

    void Update()
    {
        GetComponent<AudioSource>().GetOutputData(m_SamplesL, 0);
        int counter = 0;
        for (int i = 0; i < m_SamplesL.Length; i++)
        {
            if (i % 10 == 0)
            {
                nTranslate = translate;
                //cubes[counter].renderer.material.color = Color.red * (m_SamplesL[counter] * 2 + 0.5f);

                cubes[counter].transform.localScale = new Vector3(m_SamplesL[counter] * 20, 1, 1);
                counter++;

                translate = m_SamplesL[counter] * 10;


                if (translate < 0)
                {
                    translate *= -1;
                }

                Slop = translate - nTranslate;

                if (Slop > 1.7)
                {
                    print(Slop);
                }

            }
        }
    }
}
