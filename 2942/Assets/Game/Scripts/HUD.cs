using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Slider energyBar;
    public GameObject player;
    public RawImage[] missiles;
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

        for (int i = 0; i < missiles.Length; i++)
        {
            missiles[i].gameObject.SetActive(i < ship.cantMissiles);
        }
    }
}
