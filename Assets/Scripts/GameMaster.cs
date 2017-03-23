using UnityEngine.UI;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    [SerializeField] KeyCode key;
    [SerializeField] GameObject textBox;
    [SerializeField] Text texto;

    public delegate void EscreveDialogo(Text texto);
        public static EscreveDialogo escreveDialogo;

    public delegate void DisparaArma(float time);
        public static DisparaArma disparaArma;

    bool bloquearArma = false;
	
	// Update is called once per frame
	void Update () {
        ativaDialogo();
    }

    void FixedUpdate () {
        atiraArma(Time.time);
    }

    void ativaDialogo() {
        if (Input.GetKeyDown(key)) {
            textBox.SetActive(true);
            print("ativando");
        }

        if (textBox.activeSelf) {
            if (Input.GetKeyDown(KeyCode.Return)) {
                if (escreveDialogo != null)
                    escreveDialogo(texto);
                print("trocando texto");
            }
        }
    }

    void atiraArma(float time) {
        if (!bloquearArma && disparaArma != null)
            disparaArma(time);
    }
}
