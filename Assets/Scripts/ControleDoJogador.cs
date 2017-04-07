using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ControleDoPersonagem))]

public class ControleDoJogador : MonoBehaviour {

    ControleDoPersonagem personagem;
    bool pulo;
    bool irParaDireita;
    float velAndroid = 0.1f;

	void Awake () {
        personagem = GetComponent<ControleDoPersonagem>();
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR
        pulo = Input.GetButtonDown("Jump");
#endif

#if UNITY_ANDROID
        PulaAndroid();
        AndarAndroid();
#endif
    }

    void FixedUpdate() {
#if UNITY_EDITOR
        float h = Input.GetAxis("Horizontal");
        personagem.Andar(h);
#endif

#if UNITY_ANDROID
        if (irParaDireita)
            personagem.Andar(velAndroid);
#endif
    }

    void AndarAndroid() {

        foreach (Touch toque in Input.touches) {
                if (toque.position.x < Screen.width / 2) {
                    irParaDireita = false;
                }
                else if (toque.position.x > Screen.width / 2) {
                    irParaDireita = true;
                }
        }

    }

    void PulaAndroid() {
        float inicioDoToque=0, fimDoToque=0;

        foreach (Touch toque in Input.touches) {

            if (toque.phase == TouchPhase.Began) {
                inicioDoToque = toque.position.y;
            }
            else if (toque.phase == TouchPhase.Ended) {
                fimDoToque = toque.position.y;
                if (fimDoToque > inicioDoToque) {
                    pulo = true;
                }
            }

        }
    }
}
