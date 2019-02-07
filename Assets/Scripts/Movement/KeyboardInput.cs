using UnityEngine;

[CreateAssetMenu(fileName = "Keyboard Input", menuName = "Input/KeyboardInput")]
public class KeyboardInput : UnitInput
{
    public Vector2 force { get; private set; }
    public float rotation { get; private set; }

    public override void GetInput()
    {
        force = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}