using System.Collections;
using System.Collections.Generic;
using Plane;
using TreeEditor;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private Vector3 inputMovement;

    [SerializeField] private VirtualJoystick joystick;
    [SerializeField] private PlayerStats stats;
    

    private const float MinAxis = 0.3f;
    private const float MaxPositionX = 10;

    private float inputMult;

    private MeshRenderer meshRenderer;

    private float currentDebuffTime;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        joystick = GameObject.Find("VirtualJoystick").GetComponent<VirtualJoystick>();
        stats = GetComponent<PlayerStats>();
        GameManager.Instance.currentPlayerController = this;
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        InitPlane();
    }

    void InitPlane()
    {
        Color tempColor;
        Debug.Log(GameManager.Instance.myColor);
        if (ColorUtility.TryParseHtmlString("#" + GameManager.Instance.myColor, out tempColor))
        {
            meshRenderer.materials[0].SetColor("_Color", tempColor);
        }

        inputMult = 1;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
        UpdateLateralSpeed();
        UpdateBoost();
        UpdateDebuffTimers();
        if (currentDebuffTime > 0)
        {
            UpdateDebuffTimers();
        }
    }

    void UpdateDebuffTimers()
    {
        currentDebuffTime -= Time.deltaTime;
        if (currentDebuffTime <= 0)
        {
            currentDebuffTime = 0;
            inputMult = 1;
            //lo que sea de la visibildad
        }
    }

    void UpdateInput()
    {
        inputMovement = joystick.InputDirection * inputMult;
    }

    void UpdateLateralSpeed()
    {
        rb.velocity = Vector3.right * inputMovement.x * stats.lateralSpeed;
        if (transform.position.x < -MaxPositionX)
        {
            transform.position = new Vector3(-MaxPositionX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > MaxPositionX)
        {
            transform.position = new Vector3(MaxPositionX, transform.position.y, transform.position.z);
        }
    }

    void UpdateBoost()
    {
        if (inputMovement.y >= MinAxis)
        {
            BoostUp();
        }
        else if (inputMovement.y <= -MinAxis)
        {
            BoostDown();
        }
    }

    void BoostUp()
    {
        if (GameManager.Instance.playerStats.speed < GameManager.Instance.playerStats.maxSpeed)
        {
            GameManager.Instance.playerStats.speed += 10f * Time.deltaTime * inputMovement.y;
            if (GameManager.Instance.playerStats.speed > GameManager.Instance.playerStats.maxSpeed)
            {
                GameManager.Instance.playerStats.speed = GameManager.Instance.playerStats.maxSpeed;
            }
        }
    }

    void BoostDown()
    {
        if (GameManager.Instance.playerStats.speed > 0)
        {
            GameManager.Instance.playerStats.speed += 10f * Time.deltaTime * inputMovement.y;
            if (GameManager.Instance.playerStats.speed < 0)
            {
                GameManager.Instance.playerStats.speed = 0;
            }
        }
    }

    public void InvertControllsDebuff()
    {
        if (currentDebuffTime > 0) return;
        inputMult = -1;
        currentDebuffTime = 10;
    }

    public void SpeedDebuff()
    {
        if (currentDebuffTime > 0) return;
        inputMult = 0.5f;
        currentDebuffTime = 10;
    }

    public void VisibilityDebuff()
    {
        if (currentDebuffTime > 0) return;
        currentDebuffTime = 10;
    }
}
