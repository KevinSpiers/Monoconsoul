using UnityEngine;
using System.Collections;

public class HealthExpUpdate {

    private GameObject HealthBar = null;
    private GameObject ExperienceBar = null;
    private Player player = null;

    public void UpdateHealthBar()
    {
        if (HealthBar == null)
        {
            HealthBar = GameObject.Find("Health");
        }
        if (player == null)
        {
            player = GameObject.Find("Character").GetComponent<Player>();
        }
        RectTransform hpRect = HealthBar.GetComponent<RectTransform>();
        HealthBar.transform.localScale = new Vector3(HealthBar.transform.localScale.x, (player.stats.Health * 1.0f) / player.stats.MaxHealth, HealthBar.transform.localScale.z);
        HealthBar.transform.localPosition = new Vector3(HealthBar.transform.localPosition.x, -hpRect.rect.height/2 * (1 - (player.stats.Health * 1.0f) / player.stats.MaxHealth), HealthBar.transform.localPosition.z);
    }

    public void UpdateExperienceBar()
    {
        if (ExperienceBar == null)
        {
            ExperienceBar = GameObject.Find("Exp");
        }
        if (player == null)
        {
            player = GameObject.Find("Character").GetComponent<Player>();
        }
        RectTransform expRect = ExperienceBar.GetComponent<RectTransform>();
        ExperienceBar.transform.localScale = new Vector3(ExperienceBar.transform.localScale.x, (player.stats.Experience * 1.0f) / player.stats.MaxExperience, ExperienceBar.transform.localScale.z);
        ExperienceBar.transform.localPosition = new Vector3(ExperienceBar.transform.localPosition.x, -expRect.rect.height / 2 * (1 - (player.stats.Experience * 1.0f) / player.stats.MaxExperience), ExperienceBar.transform.localPosition.z);
    }
}
