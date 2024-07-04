using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] RectTransform _clockArrow;
    [SerializeField] int _firstHourAngle;      
    [SerializeField] int _secondHourAngle;      
    [SerializeField] int _thirstHourAngle;      
    [SerializeField] int _fourthHourAngle;      

    private string FirthHour = TimeConstants.MORNING;
    private string SecondHour = TimeConstants.AFTERNOON;
    private string ThirthHour = TimeConstants.DUSK;
    private string FourthHour = TimeConstants.NIGHT;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ClockArrowMove();
    }

    private void ClockArrowMove()
    {
        if (FirthHour == TimeConstants.MORNING) { _clockArrow.rotation = Quaternion.Euler(0, 0, _firstHourAngle); }
        if (SecondHour == TimeConstants.AFTERNOON) { _clockArrow.rotation = Quaternion.Euler(0, 0, _secondHourAngle); }
        if (ThirthHour == TimeConstants.DUSK) { _clockArrow.rotation = Quaternion.Euler(0, 0, _thirstHourAngle); }
        if (FourthHour == TimeConstants.NIGHT) { _clockArrow.rotation = Quaternion.Euler(0, 0, _fourthHourAngle); }
    }
}
