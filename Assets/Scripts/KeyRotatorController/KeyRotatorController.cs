using UnityEngine;

class KeyRotatorController : MouseRotatorController
{
    #region Horizontal Variables
    [SerializeField] private KeyCode horizKeyNeg = KeyCode.Q;
    [SerializeField] private KeyCode horizKeyPos = KeyCode.E;
    #endregion

    #region Vertical Variables
    [SerializeField] private KeyCode vertKeyNeg = KeyCode.F;
    [SerializeField] private KeyCode vertKeyPos = KeyCode.R;
    #endregion

    protected override void ChangeVertRot()
    {
        if (Input.GetKey(vertKeyPos))
        {
            vertRot += -vertSens * Time.deltaTime;
        }
        else if (Input.GetKey(vertKeyNeg))
        {
            vertRot += vertSens * Time.deltaTime;
        }
    }

    protected override void ChangeHorizRot()
    {
        if (Input.GetKey(horizKeyPos))
        {
            horizRot += horizSens * Time.deltaTime;
        }
        else if (Input.GetKey(horizKeyNeg))
        {
            horizRot += -horizSens * Time.deltaTime;
        }
    }
}
