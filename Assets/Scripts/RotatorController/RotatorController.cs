using UnityEngine;

abstract class RotatorController : MonoBehaviour
{
    #region Horizontal Variables
    [SerializeField] protected bool useHorizRot = true;
    [SerializeField] protected float horizSens = 50f;
    [SerializeField] protected bool useHorizClamp = false;
    [SerializeField] protected Vector2 horizClamp = Vector2.zero;
    #endregion

    #region Vertical Variables
    [SerializeField] protected bool useVertRot = true;
    [SerializeField] protected float vertSens = 50f;
    [SerializeField] protected bool useVertClamp = true;
    [SerializeField] protected Vector2 vertClamp = new Vector2(-80f, 80f);
    #endregion

    protected float horizRot;
    protected float vertRot;

    protected void Update()
    {
        #region Vertical Rotation
        if (useVertRot)
        {
            ChangeVertRot();

            //Clamp vertical
            if (useVertClamp)
            {
                vertRot = Mathf.Clamp(vertRot, vertClamp.x, vertClamp.y);
            }
        }
        #endregion

        #region Horizontal Rotation
        //Horizontal rotation
        if (useHorizRot)
        {
            ChangeHorizRot();

            //Clamp horizontal
            if (useHorizClamp)
            {
                horizRot = Mathf.Clamp(horizRot, horizClamp.x, horizClamp.y);
            }
        }
        #endregion

        //Rotate
        transform.localRotation = Quaternion.Euler(vertRot, horizRot, 0f);
    }

    abstract protected void ChangeVertRot();

    abstract protected void ChangeHorizRot();
}

