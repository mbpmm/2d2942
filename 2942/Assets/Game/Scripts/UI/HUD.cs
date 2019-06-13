using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Slider energyBar;
    public Text score;
    public GameObject player;
    public GameObject gameManager;
    public RawImage[] missiles;
    private GameManager gameMan;
    private Ship ship;
    // Start is called before the first frame update
    void Start()
    {
        ship = player.GetComponent<Ship>();
        gameMan = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        energyBar.value = ship.energy;
        score.text = "SCORE: " + gameMan.score;

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
