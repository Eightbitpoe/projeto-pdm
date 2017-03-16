using UnityEngine;
using UnityEngine.UI;

public class ColliderDialogue : MonoBehaviour {
    [SerializeField] KeyCode key;
    [SerializeField] GameObject textBox;
    [SerializeField] Text texto;
    [SerializeField] TextAsset arqTxt;
    [SerializeField] string[] linhas;

    int linhaCorrente = 0;
    int linhaFinal;

    bool entrei;

    void Start() {
        if (arqTxt != null)
            linhas = (arqTxt.text.Split('\n'));
        linhaFinal = linhas.Length;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
            entrei = true;
            
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
            entrei = false;
    }

    void Update() {
        if (Input.GetKeyDown(key) && entrei)
            textBox.SetActive(true);

        if (textBox.activeSelf) {
            texto.text = linhas[linhaCorrente];
            if (Input.GetKeyDown(KeyCode.Return) && linhaCorrente < linhaFinal-1)
                linhaCorrente += 1;
        }
    }
}
