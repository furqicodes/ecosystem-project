using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_World_Stats : MonoBehaviour
{
    private Text text;
    private World world;
    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
        world = GameObject.Find("gameManager").GetComponent<World>();
    }

    // Update is called once per frame
    void Update()
    {
        string state = (world.getDay()) ? "Day  " : "Night";
        text.text = "World Preset: " + world.getYearLengthInSeasons() + " Season/ " + world.getSeasonLengthInDays() + " Day/ " + world.getDayLengthInSeconds() + " Seconds/ " + world.getWorldScale() + "\n" +
        world.getDayCounter() + ". " + state + " Time of day: " + world.getCurrentTimeOfDay() + "\nTime Multiplier: " + world.getTimeMultiplier();
    }
}
