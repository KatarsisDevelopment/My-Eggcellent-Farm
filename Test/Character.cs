using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float Speed = 5f;
    FixedJoystick Joystick;
    [SerializeField] float DistanceHit,SpeedCollect;
    private void Awake()
    {
        Joystick = FindObjectOfType<FixedJoystick>();
    }
    void Start()
    {
        StartCoroutine(Collect());
    }
    void Update()
    {
        Movment();
    }
    private void LateUpdate()
    {
        CameraFollow();
    }
 
    IEnumerator Collect()
    {
        while (true)
        {
            
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, DistanceHit))
            {
                Producer producer = hit.collider.gameObject.GetComponent<Producer>();
                if (producer != null)
                {
                    if (producer.CountProuduced > 0)
                    { 
                        producer.Produced[producer.CountProuduced].SetActive(false);
                        producer.CountProuduced -= 1;
                    }
                }
            }
            yield return new WaitForSeconds(SpeedCollect);
        }
    }
    void Movment()
    {
        float Hor = Joystick.Horizontal * Speed * Time.deltaTime;
        float Ver = Joystick.Vertical * Speed * Time.deltaTime;
        transform.position += new Vector3(Hor, 0, Ver);
        transform.forward += new Vector3(Hor, 0, Ver).normalized;
    }
    void CameraFollow()
    {
        Camera.main.transform.position = transform.position + new Vector3(-10, 10, -10);
    }
}
