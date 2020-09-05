using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class is for check the bahavior of the objects that collision with the ocean
/// </summary>
public class Ocean : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.otherCollider != null && contact.otherCollider.GetComponentInParent<Player>() != null && contact.otherCollider.GetComponentInParent<Player>().GetType().Name.Equals("Player"))
            {
                contact.otherCollider.GetComponentInParent<Player>().Die();
                Destroy(contact.otherCollider.GetComponentInParent<Player>());
            } else if(contact.otherCollider != null)
            {
                Destroy(contact.otherCollider);
            }
        }
    }
}
