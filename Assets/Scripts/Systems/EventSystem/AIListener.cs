using System;
using UnityEngine;

namespace EventCallback
{
public class AIListener : MonoBehaviour
{
 //The actions that can be called filled for he input return
 public event Action<float, float> Move;
public event Action<Vector3[]> GetTouchPositions;
public event Action<Vector3> GetMousePos;
public event Action<bool> EscPressed;
public event Action<bool> SpacePressed;
public event Action<bool> LeftMBPressed;
public event Action<bool> RightMBPressed;
public event Action<bool> MidMBPressed;

void Start()
{
//Register the input listener
AIEvent.RegisterListener(OnAIEvent);
}
void OnDestroy()
{ 
//Unregister the input listener
AIEvent.UnregisterListener(OnAIEvent);
}
void OnAIEvent(AIEvent aiEvent) 
{ 
//Run the actions if the are not equal to null
if (inputEvent.escPressed && EscPressed != null) EscPressed(inputEvent.escPressed);
if (inputEvent.spacePressed && SpacePressed != null) SpacePressed(inputEvent.spacePressed);
if (inputEvent.leftMBPressed && LeftMBPressed != null) LeftMBPressed(inputEvent.leftMBPressed);
if (inputEvent.rightMBPressed && RightMBPressed != null) RightMBPressed(inputEvent.rightMBPressed);
if (inputEvent.midMBPressed && MidMBPressed != null) MidMBPressed(inputEvent.midMBPressed);
if (GetMousePos != null) GetMousePos(inputEvent.mousePos);
if (GetTouchPositions != null) GetTouchPositions(inputEvent.touchPositions); if (GetAxis != null) Move(inputEvent.horizontalAxis, inputEvent.verticalAxis);
}
 }
 }