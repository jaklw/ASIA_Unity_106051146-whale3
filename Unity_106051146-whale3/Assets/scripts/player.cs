using UnityEngine;

public class player : MonoBehaviour
{
    public Transform tran;
    public Rigidbody rig;
    public float speed;
    public float turn;
    public Animator ani;

    public Rigidbody cat_rig;

    void OnTriggerStay(Collider other)
    {
        print(other);
        if (other.name == "劍" &&ani.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            
            Physics.IgnoreCollision(other, GetComponent<Collider>());
            other.GetComponent<HingeJoint>().connectedBody = cat_rig;
        }
    }
    private void Update()
    {
        walk();
        run();
        attack();
    }
    
    private void walk()
    {
        float v = Input.GetAxis("Vertical");
        rig.AddForce(tran.forward * speed *v* Time.deltaTime);
        float h = Input.GetAxis("Horizontal");
        tran.Rotate(0, turn * h * Time.deltaTime, 0);

        ani.SetBool("走路開關", v != 0);
    }
    private void run()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ani.SetBool("跑步開關", true);
        }
        else
        {
            ani.SetBool("跑步開關", false);
        }
    }
    private void attack()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            ani.SetTrigger("攻擊觸發");
        }
    }

}
