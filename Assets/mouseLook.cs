using UnityEngine;

public class mouseLook : MonoBehaviour
{
    //Vector2 curMousePos;
    [SerializeField] float mousePitch;
    [SerializeField] float mouseYaw;
    [SerializeField] float lookSpeed = 2f;

    enum cube { blue, green, yellow, red}
    cube lookingAtCube;

    // Start is called before the first frame update
    void Start()
    {
        // set the cube to start looking
        LookAtCube(lookingAtCube = cube.blue);
    }

    // Update is called once per frame
    void Update()
    {
        // get user input every frame
        GetPlayerInput();
    }

    private void GetPlayerInput()
    {
        if(Input.GetKey(KeyCode.L))
        {
            // calling mouse look if the L key is down
            MouseLook();
        }
        if(!Input.GetKey(KeyCode.L))
        {   
           // if the L key is NOT down set the camera back to the cube we were looking at.
           // there may be a better way to do this.
            LookAtCube(lookingAtCube);
        }
        // set the cube we want to look at
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            // look at blue cube
            LookAtCube(lookingAtCube = cube.blue);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // look at green cube
            LookAtCube(lookingAtCube = cube.green);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // look at yellow cube
            LookAtCube(lookingAtCube = cube.yellow);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // look at red cube
            LookAtCube(lookingAtCube = cube.red);
        }
    }

    private void LookAtCube(cube lookingAtCube)
    {
        // look at cube according to the enum lookingAtCube
        // maybe should have done this with a switch statement

        if(lookingAtCube == cube.blue)
        {
            mouseYaw = 0f; //reset camera for mouse look if you don't do this the camera will pop/rotate back to the last rotation before you let off the L key
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (lookingAtCube == cube.green)
        {
            mouseYaw = -90f; //reset camera for mouse look if you don't do this the camera will pop/rotate back to the last rotation before you let off the L key
            transform.rotation = Quaternion.Euler(0f, 270f, 0f);
        }
        if (lookingAtCube == cube.yellow)
        {
            mouseYaw = 180f; //reset camera for mouse look if you don't do this the camera will pop/rotate back to the last rotation before you let off the L key
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        if (lookingAtCube == cube.red)
        {
            mouseYaw = 90f; //reset camera for mouse look if you don't do this the camera will pop/rotate back to the last rotation before you let off the L key
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        mousePitch = 0f; // reset the cameras pitch after mouse look
    }

    private void MouseLook()
    {
        mouseYaw += Input.GetAxis("Mouse X") * lookSpeed; // do the math.  
        mousePitch += -Input.GetAxis("Mouse Y") * lookSpeed; // this is pretty much striate from the unity page for GetAxis
        https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
        transform.rotation = Quaternion.Euler(mousePitch, mouseYaw, 0f); // rotate the camera.
    }
}
