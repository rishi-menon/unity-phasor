using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private float m_fAmplitude;
    private float m_fPhase;
    private float m_fAngVel;

    //Public variables
    public float offsetY;
    
    [Space(5)]
    public float m_fAngVelMin;
    public float m_fAngVelMax;
    
    [Space(5)]
    [Range (0, 1)]
    public float percentXLeft = 0;
    [Range (0, 1)]
    public float percentXRight = 1;

    // [Space(5)]
    
    // Start is called before the first frame update
    void Start()
    {
        m_fPhase = 0; 
        m_fAngVel = 0;
        Vector3 bottomLeftPos = Camera.main.ScreenToWorldPoint(new Vector3 (0, 0, 0));
        m_fAmplitude = (-bottomLeftPos.y) - offsetY;
        // Debug.Log(m_fAmplitude);
    }

    // Update is called once per frame
    void Update()
    {
        //calculate angular velocity
        float percentX = (Input.mousePosition.x) / (float)Screen.width;
        percentX = (percentX - percentXLeft) / (percentXRight - percentXLeft); 
        percentX = Mathf.Clamp01 (percentX); 
        m_fAngVel = Mathf.Lerp (m_fAngVelMin, m_fAngVelMax, percentX);
        
        m_fPhase += m_fAngVel * Time.deltaTime;
        if (m_fPhase >= Mathf.PI * 4) { m_fPhase -= Mathf.PI * 4;}

        //Set player position
        Vector3 playerPos = transform.position;
        playerPos.y = Mathf.Sin (m_fPhase) * m_fAmplitude;
        transform.position = playerPos;
    }

    void OnDrawGizmos ()
    {
        Vector3 bottomLeftPos = Camera.main.ScreenToWorldPoint(new Vector3 (0, 0, 0));
        float amplitude = (-bottomLeftPos.y) - offsetY + transform.localScale.y / 2.0f;

        Vector3 size = new Vector3 (transform.localScale.x, 2*(amplitude));
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube (new Vector3(transform.position.x, 0, 0), size);
    }
}
