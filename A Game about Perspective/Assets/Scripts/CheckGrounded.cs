using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGrounded : MonoBehaviour {

    public bool IsGrounded = true;

    void OnCollisionStay(Collision col)
    {
        IsGrounded = true;
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag.Equals("Untagged"))
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }

    }

}
