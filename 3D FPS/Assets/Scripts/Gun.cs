using UnityEngine;

public class Gun : MonoBehaviour
{
    //Gun Stats
    public float damage = 10f;
    public float range = 100f;

    public Camera cam;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }


    void shoot()
    {
        RaycastHit hit;
        if(        Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            EnemyScript target = hit.transform.GetComponent<EnemyScript>();

            if(target != null)
            {
                target.takeDamage(damage);
            }
        }
    }
}
