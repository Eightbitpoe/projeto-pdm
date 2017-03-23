using UnityEngine;
using UnityEngine.UI;

public class DialogoPink : MonoBehaviour {
    [SerializeField] TextAsset arqTxt;
    [SerializeField] string[] linhas;

    bool colisao;

    int linhaFinal;
    int linhaCorrente;
    // Use this for initialization
    void Start () {
        if (arqTxt != null)
            linhas = (arqTxt.text.Split('\n'));
        linhaFinal = linhas.Length;
        linhaCorrente = 0;
        colisao = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (colisao) return; colisao = true;

        if (other.gameObject.tag == "Player")
            GameMaster.escreveDialogo += MensagemPink;
        //print(other.gameObject.tag + "in");
    }

    void OnTriggerExit2D(Collider2D other) {
        if (!colisao) return; colisao = false;

        if (other.gameObject.tag == "Player")
            GameMaster.escreveDialogo -= MensagemPink;
        //print(other.gameObject.tag + "out");
    }

    void MensagemPink(Text texto) {
        texto.text = linhas[linhaCorrente];
        //print(linhas[linhaCorrente]);
        linhaCorrente++;
        //print(linhaCorrente);
        if (linhaCorrente == linhaFinal)
            linhaCorrente = 0;
    }
}
