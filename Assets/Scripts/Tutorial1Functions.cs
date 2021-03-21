using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial1Functions : MonoBehaviour
{
    //Game audio
    public AudioSource source;
    public AudioSource buttonSource;
    public AudioClip menuSelect;
    public AudioClip menuBack;

    //Tutorial Panels for level 1
    public GameObject[] tutorialPanelsLevel1;
    int index1 = 0;

    public void ScrollTutorial1()
    {
        if (index1 < tutorialPanelsLevel1.Length - 1)
        {
            tutorialPanelsLevel1[index1].SetActive(false);
            index1++;
            tutorialPanelsLevel1[index1].SetActive(true);
            buttonSource.PlayOneShot(menuSelect);
        }
        else if(index1 == tutorialPanelsLevel1.Length - 1)
        {
            tutorialPanelsLevel1[index1].SetActive(false);
            index1 = 0;
            buttonSource.PlayOneShot(menuSelect);
        }
    }

    public void ScrollBackTutorial1()
    {
        if (index1 > 0)
        {
            tutorialPanelsLevel1[index1].SetActive(false);
            index1--;
            tutorialPanelsLevel1[index1].SetActive(true);
            buttonSource.PlayOneShot(menuBack);
        }
    }
}
