using UnityEngine;
using UnityEngine.InputSystem;

public class keyboard_Input : MonoBehaviour
{
  public Corgi corgi;
  public PoopPlacer PoopPlacer;

  public void Update()
  {
    //get the buttons pressed
    Keyboard keyboard = Keyboard.current;

    if (keyboard.wKey.wasPressedThisFrame) //ispressed this frame? - make a variable cus its red when i do that
    {
      corgi.MoveManually(Vector2.up);
    }
    else if (keyboard.sKey.wasPressedThisFrame)
    {
      corgi.MoveManually(Vector2.down);
    }
    else if (keyboard.aKey.wasPressedThisFrame)
    {
      corgi.MoveManually(Vector2.left);
    }
    else if (keyboard.dKey.wasPressedThisFrame)
    {
      corgi.MoveManually(Vector2.right);
    }

    if (keyboard.spaceKey.wasPressedThisFrame)
    {
      PoopPlacer.Place(corgi.GetPosition());
    }
    
  }
}
