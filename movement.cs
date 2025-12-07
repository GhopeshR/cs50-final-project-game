using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class movement : MonoBehaviour
{
    public static movement instance;
    public float movespeed,gravityforce,jumpforce,sprintspeed;
    public CharacterController characterController;
    private Vector3 moveinput;
    public Transform cameratransform;
    public float mousesens;
    public Animator animator;
    public GameObject bullet;
    public Transform firepoint;
    public gun activegun;
    public List<gun> allguns=new List<gun>();
    public int currentgun;
    public GameObject muzzleflash;
    private void Awake()
    {
        instance = this;


    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentgun--;
        switchgun();
        //activegun=allguns[currentgun];
        //activegun.gameObject.SetActive(true);
        //ui.instance.ammo.text = "Ammo" + activegun.currentammo;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ui.instance.pausescreen.activeInHierarchy)
        {


            float yvelocity = moveinput.y;

            Vector3 verticalmove = transform.forward * Input.GetAxis("Vertical");
            Vector3 horizontalmove = transform.right * Input.GetAxis("Horizontal");
            moveinput = horizontalmove + verticalmove;
            moveinput.Normalize();
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveinput = moveinput * sprintspeed;
            }
            else
            {
                moveinput = moveinput * movespeed;
            }
            moveinput.y = yvelocity;
            moveinput.y += Physics.gravity.y * gravityforce * Time.deltaTime;
            if (characterController.isGrounded)
            {
                moveinput.y = Physics.gravity.y * gravityforce * Time.deltaTime;

            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveinput.y = jumpforce;

            }


            characterController.Move(moveinput * Time.deltaTime);
            Vector2 mouseinput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mousesens;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseinput.x, transform.rotation.eulerAngles.z);
            cameratransform.rotation = Quaternion.Euler(cameratransform.rotation.eulerAngles + new Vector3(-mouseinput.y, 0f, 0f));
            if (Input.GetMouseButtonDown(0) && activegun.firecounter <= 0)
            {
                RaycastHit hit;
                if (Physics.Raycast(cameratransform.position, cameratransform.forward, out hit, 200f))
                {
                    if (Vector3.Distance(cameratransform.position, hit.point) > 1f)
                    {
                        firepoint.LookAt(hit.point);

                    }
                    else
                    {
                        firepoint.LookAt(cameratransform.position + (cameratransform.forward * 400f));
                    }
                }
                //Instantiate(bullet,firepoint.position, firepoint.rotation);
                fireshot();
            }
            if (Input.GetMouseButton(0) && activegun.canautofire)
            {

                if (activegun.firecounter <= 0)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(cameratransform.position, cameratransform.forward, out hit, 200f))
                    {
                        if (Vector3.Distance(cameratransform.position, hit.point) > 1f)
                        {
                            firepoint.LookAt(hit.point);

                        }
                        else
                        {
                            firepoint.LookAt(cameratransform.position + (cameratransform.forward * 400f));
                        }
                    }
                    fireshot();
                }
            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                switchgun();
            }
        }
    }
    public void fireshot()
    {
        if (activegun.currentammo > 0)
        {
            activegun.currentammo--;
            Instantiate(activegun.bullet, firepoint.position, firepoint.rotation);
            activegun.firecounter = activegun.firerate;
            ui.instance.ammo.text = "Ammo:"+" "+ activegun.currentammo;
            StartCoroutine(WaitAndSetActiveFalse());
        }

    }
    IEnumerator WaitAndSetActiveFalse()
    {
        muzzleflash.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        muzzleflash.SetActive(false);
    }

    public void switchgun()
    {
        activegun.gameObject.SetActive(false);
        currentgun++;
        if (currentgun > allguns.Count)
        {
            currentgun = 0;
        }
        activegun = allguns[currentgun];
        activegun.gameObject.SetActive(true);
        ui.instance.ammo.text = "Ammo:" + " " + activegun.currentammo;
        firepoint.position= activegun.firepoint.position;
    }
    public void gunpickup(gun weapon)
    {
        allguns.Remove(allguns[1]);
        allguns.Append(weapon);
    }

}
