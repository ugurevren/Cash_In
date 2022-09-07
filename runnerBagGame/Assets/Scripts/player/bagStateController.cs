using System;
using UnityEngine;

public class bagStateController : MonoBehaviour
{
    public int [] upgradePoint;
    public GameObject[] bags;
    public ParticleSystem particles;
    private void Update()
    {
        if (Collectibles.cash <= upgradePoint[0])
        {
            if (bags[0].activeSelf) return;
            particles.Play();
            bags[0].SetActive(true);
            bags[1].SetActive(false);
            bags[2].SetActive(false);
            bags[3].SetActive(false);
        }
        else if (Collectibles.cash <= upgradePoint[1])
        {
            if (bags[1].activeSelf) return;
            particles.Play();
            bags[0].SetActive(false);
            bags[1].SetActive(true);
            bags[2].SetActive(false);
            bags[3].SetActive(false);
        }
        else if (Collectibles.cash <= upgradePoint[2])
        {
            if (bags[2].activeSelf) return;
            particles.Play();
            bags[0].SetActive(false);
            bags[1].SetActive(false);
            bags[2].SetActive(true);
            bags[3].SetActive(false);
        }
        else
        {
            if (bags[3].activeSelf) return;
            particles.Play();
            bags[0].SetActive(false);
            bags[1].SetActive(false);
            bags[2].SetActive(false);
            bags[3].SetActive(true);
        }
    }
}
