using UnityEngine;

public class topdowneditor : MonoBehaviour
{
    #region Variables
    //m_Target needs to be attached to player in Unity, supplies script with information
    public Transform m_Target;
    //these control the camera settings, are updatable in Unity
    public float m_Height = 10f;
    public float m_Distance = 20f;
    public float m_Angle = 45f;
    public float m_smoothingSpeed = .5f;
    private Vector3 refVelocity;
    #endregion

    #region main methods
    void Start()
    {
        HandleCamera();
    }
    //Changed from tutorial, void Update to void FixedUpdate, this stop it from stuttering
    void FixedUpdate()
    {
        HandleCamera();
    }
    #endregion


    #region helper methods
    protected virtual void HandleCamera()
    {

            //Build World Position vector
            Vector3 worldPosition = (Vector3.forward * -m_Distance) + (Vector3.up * m_Height);
            //Debug.DrawLine (m_Target.position, worldPosition, Color.red);

            //Build rotated Vector
            Vector3 rotatedVector = Quaternion.AngleAxis(m_Angle, Vector3.up) * worldPosition;
            //Debug.DrawLine (m_Target.position, worldPosition, Color.green);

            //move camera position
            Vector3 flatTargetPosition = m_Target.position;
            flatTargetPosition.y = 0f;
            Vector3 finalPosition = flatTargetPosition + rotatedVector;
            //Debug.DrawLine(m_Target.position, finalPosition, Color.blue);

            transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, m_smoothingSpeed);
            transform.LookAt(m_Target.position);
        
    }
    #endregion
}
