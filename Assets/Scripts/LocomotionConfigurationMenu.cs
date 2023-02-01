using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocomotionConfigurationMenu : MonoBehaviour
{
    [SerializeField]
    private LocomotionManager locomotionManager;
    [SerializeField]
    private Toggle continuousMoveToggle;
    [SerializeField]
    private Toggle continuousTurnToggle;


    void Start()
    {
        SubscribeToContinuousMove(continuousMoveToggle);
        SubscribeToContinuousTurn(continuousTurnToggle);
    }

    private void SubscribeToContinuousMove(Toggle toggle)
    {
        var continuousMove = locomotionManager.moveScheme == MoveScheme.Continuous;
        toggle.isOn = continuousMove;
        toggle.onValueChanged.AddListener(OnContinuousMoveToggleValueChanged);
    }
    
    private void OnContinuousMoveToggleValueChanged(bool value)
    {
        locomotionManager.moveScheme = value ? MoveScheme.Continuous : MoveScheme.Noncontinuous;
    }
    private void SubscribeToContinuousTurn(Toggle toggle)
    {
        var continuousTurn = locomotionManager.turnStyle == TurnStyle.Continuous;
        toggle.isOn = continuousTurn;
        toggle.onValueChanged.AddListener(OnContinuousTurnToggleValueChanged);
    }

    private void OnContinuousTurnToggleValueChanged(bool value)
    {
        locomotionManager.turnStyle = value ? TurnStyle.Continuous : TurnStyle.Snap;
    }

}
