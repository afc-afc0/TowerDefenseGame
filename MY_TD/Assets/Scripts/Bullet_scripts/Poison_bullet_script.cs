using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison_bullet_script : MonoBehaviour
{
    
        private Transform target;
        public float speed = 1.5f;
        public float damage = 30f;
        private bool hit = false;

        public void Ara(Transform _target)
        {
            target = _target;
        }

        void Update()
        {
            
            if(target == null)
            {
            Destroy(gameObject);
            return;
            }
    
            

            Vector3 dir = target.position - transform.position;
            float distance_this_frame = speed * Time.deltaTime;

            if (dir.magnitude <= distance_this_frame && hit != true)
            {
                Hit_target();
                target.GetComponent<Enemy_script>().is_poisened = true;
                hit = true;
                return;
            }

            transform.Translate(dir.normalized * distance_this_frame, Space.World);
        }

        void Hit_target()
        {
        StartCoroutine(Hit());
        Destroy(gameObject.GetComponent<MeshRenderer>());
            return;
        }

        IEnumerator Hit()
        {
        for (int i = 0;i < 4; i++)
        {
            target.GetComponent<Enemy_script>().GetDamage(damage);
            yield return new WaitForSeconds(1f);
        }
        }
    
}
