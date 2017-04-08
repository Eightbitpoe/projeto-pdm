using UnityEngine;

[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(Rigidbody2D))]

public class ControleDoPersonagem : MonoBehaviour {

    [SerializeField] float velocidadeMaxima = 10f;
    [SerializeField] float forcaPulo = 400f;
    [SerializeField] LayerMask definirChao;

    Transform checaChao;
    const float raioDoChao = .2f;
    Transform checaTeto;
    const float raioDoTeto = .01f;

    SpriteRenderer sprite;

    bool aterrado;
    bool olhandoDireita = true;

    Animator animacao;
    Rigidbody2D corpoRigido;


	// Use this for initialization
	void Awake () {
        checaChao = transform.Find("ChecaChao");
        checaTeto = transform.Find("ChecaTeto");
        animacao = GetComponent<Animator>();
        corpoRigido = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        aterrado = false;

        //Verifica se há colisão com o chão. definirChao define o que é definido como chão
        Collider2D[] chaos = Physics2D.OverlapCircleAll(checaChao.position, raioDoChao, definirChao);
        for (int i = 0; i < chaos.Length; i++) {
            if (chaos[i].gameObject != gameObject)
                aterrado = true;
        }
        animacao.SetBool("chao", aterrado);

        animacao.SetFloat("velocidadeY", corpoRigido.velocity.y);
    }

    public void Pular(bool pulo) {
        if (aterrado && pulo && animacao.GetBool("chao")) {

            aterrado = false;
            animacao.SetBool("chao", false);
            corpoRigido.AddForce(new Vector2(0f, forcaPulo));
        }
    }

    public void Andar(float andar) {
        if (aterrado) {
            //print("vel no cdp pre-mathf " + andar);
            //print("vel no cdp pos-mathf " + Mathf.Abs(andar));
            animacao.SetFloat("velocidade", Mathf.Abs(andar));

            corpoRigido.velocity = new Vector2(andar * velocidadeMaxima, corpoRigido.velocity.y);

            if (andar > 0 && !olhandoDireita)
                Flipar();
            else if (andar < 0 && olhandoDireita)
                Flipar();
        }
    }

    void Flipar() {
        olhandoDireita = !olhandoDireita;

        //sprite.flipX = true;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}
