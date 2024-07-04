using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] RectTransform _clockArrow;
    [SerializeField] int _firstHourAngle;      
    [SerializeField] int _secondHourAngle;      
    [SerializeField] int _thirstHourAngle;      
    [SerializeField] int _fourthHourAngle;      

    private string FirsthHour = TimeConstants.MORNING;
    private string SecondHour = TimeConstants.AFTERNOON;
    private string ThirthHour = TimeConstants.DUSK;
    private string FourthHour = TimeConstants.NIGHT;

    void Start()
    {
        ClockArrowMove(FirsthHour, _firstHourAngle);
    }

    void Update()
    {
        //ClockChange();
    }

    private void ClockArrowMove(string hour, int angle)
    {
        if (hour == TimeConstants.MORNING) { _clockArrow.rotation = Quaternion.Euler(0, 0, angle); }
        if (hour == TimeConstants.AFTERNOON) { _clockArrow.rotation = Quaternion.Euler(0, 0, angle); }
        if (hour == TimeConstants.DUSK) { _clockArrow.rotation = Quaternion.Euler(0, 0, angle); }
        if (hour == TimeConstants.NIGHT) { _clockArrow.rotation = Quaternion.Euler(0, 0, angle); }
    }

    private void ClockChange()
    {
        //if (mission complete) { ClockArrowMove(SecondHour, _secondHourAngle); }
        //if (mission complete) { ClockArrowMove(ThirthHour, _thirstHourAngle); }
        //if (mission complete) { ClockArrowMove(FourthHour, _fourthHourAngle); }
    }
}
