using System;
using UnityEngine;
using UnityEngine.UI;

public class RolCountdownController : MonoBehaviour
{
    public DayOfWeek rollDay = DayOfWeek.Friday;
    public int rollHour = 22;

    public Text countdownDaysValueText;
    public Text countdownHoursValueText;
    public Text countdownMinutesValueText;

    public static string daysRemaining;
    public static string hoursRemaining;
    public static string minutesRemaining;

    DateTime targetDate;
    DateTime auxiliaryDate;
    TimeSpan deltaDate;

	void Update ()
	{
        GetTargetDate();

        deltaDate = (targetDate - DateTime.Now);

	    daysRemaining = deltaDate.Days.ToString();
        countdownDaysValueText.text = daysRemaining;

	    hoursRemaining = deltaDate.Hours.ToString();
        countdownHoursValueText.text = hoursRemaining;

	    minutesRemaining = deltaDate.Minutes.ToString();
        countdownMinutesValueText.text = minutesRemaining;
	}

    void GetTargetDate()
    {
        if (DateTime.Today.DayOfWeek == rollDay && DateTime.Now.Hour >= rollHour)
            targetDate = GetNextRolday(DateTime.Today.AddDays(1), rollDay, rollHour);
        else
            targetDate = GetNextRolday(DateTime.Today, rollDay, rollHour);
    }

    DateTime GetNextRolday(DateTime start, DayOfWeek day, int hour)
    {
        // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
        int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;

        auxiliaryDate = start.AddDays(daysToAdd);

        return new DateTime(DateTime.Today.Year, auxiliaryDate.Month, auxiliaryDate.Day, hour, 0, 0);
    }
}
