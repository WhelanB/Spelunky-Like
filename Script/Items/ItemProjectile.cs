using UnityEngine;
using System.Collections;
using UnityEngine.Scripting;

public class ItemProjectile : Item{
    Transform projectile;
    public ItemProjectile( Sprite img, string name, int id, int dmg) : base(img, name, id, dmg)
    {
        projectile = Resources.Load<Transform>("Projectile");
        used = true;
        items.Add(this);
    }

    public override void Use(Transform t)
    {
        Transform fired = (Transform)MonoBehaviour.Instantiate(projectile, t.transform.position + (Vector3.up/2f), Quaternion.identity);
        fired.GetComponent<Rigidbody>().AddForce(t.right * 2f * t.parent.localScale.x, ForceMode.Impulse);

    }
}
