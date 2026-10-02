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
      corgi.Move(Vector2.up);
    }
    else if (keyboard.sKey.wasPressedThisFrame)
    {
      corgi.Move(Vector2.down);
    }
    else if (keyboard.aKey.wasPressedThisFrame)
    {
      corgi.Move(Vector2.left);
    }
    else if (keyboard.dKey.wasPressedThisFrame)
    {
      corgi.Move(Vector2.right);
    }

    if (keyboard.spaceKey.wasPressedThisFrame)
    {
      PoopPlacer.Place(corgi.GetPosition());
    }
    
  }
}
