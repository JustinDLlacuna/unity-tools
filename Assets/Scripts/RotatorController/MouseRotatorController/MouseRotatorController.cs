using UnityEngine;

class MouseRotatorController : RotatorController
{
    protected override void ChangeVertRot()
    {
        vertRot += -Input.GetAxis("Mouse Y") * vertSens * Time.deltaTime;
    }

    protected override void ChangeHorizRot()
    {
        horizRot += Input.GetAxis("Mouse X") * horizSens * Time.deltaTime;
    }
}
