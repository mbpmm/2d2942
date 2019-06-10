using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Slider energyBar;
    public GameObject player;
    public RawImage missile1;
    public RawImage missile2;
    public RawImage missile3;
    private Ship ship;
    // Start is called before the first frame update
    void Start()
    {
        ship = player.GetComponent<Ship>();
    }

    // Update is called once per frame
    void Update()
    {
        energyBar.value = ship.energy;
        if (energyBar.value == 0)
        {
            energyBar.fillRect.gameObject.SetActive(false);
        }

        switch (ship.cantMissiles)
        {
            case 0:
                missile1.gameObject.SetActive(false);
                missile2.gameObject.SetActive(false);
                missile3.gameObject.SetActive(false);
                break;
            case 1:
                missile1.gameObject.SetActive(true);
                missile2.gameObject.SetActive(false);
                missile3.gameObject.SetActive(false);
                break;
            case 2:
                missile1.gameObject.SetActive(true);
                missile2.gameObject.SetActive(true);
                missile3.gameObject.SetActive(false);
                break;
            case 3:
                missile1.gameObject.SetActive(true);
                missile2.gameObject.SetActive(true);
                missile3.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }
}
