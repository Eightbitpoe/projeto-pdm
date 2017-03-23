using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class MunicaoSimples : MonoBehaviour {

    [SerializeField] float velDaBala;
    [SerializeField] float danoDaBala;

    Rigidbody2D corpoDaBala;

    // Use this for initialization
    void Start () {
        corpoDaBala = GetComponent<Rigidbody2D>();
        corpoDaBala.AddForce(new Vector2(velDaBala, 0), ForceMode2D.Impulse);
        
    }

}
