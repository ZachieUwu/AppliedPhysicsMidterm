using UnityEngine;

public class Fire : MonoBehaviour
{
    public UIScreen uiscreen;
    public Animator animator;
    public Camera gamCam;
    public LayerMask enemy;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = gamCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 30f, enemy))
        {
            hit.transform.TryGetComponent(out Animator animator);
            animator.enabled = false;
            Destroy(hit.collider.transform.root.gameObject, 2f);
        }
    }
}
