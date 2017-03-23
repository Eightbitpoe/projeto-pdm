using UnityEngine;

public class Arma : MonoBehaviour {

    [SerializeField] Transform saidaDaBala;
    [SerializeField] GameObject projetil;
    [SerializeField] int rof;


    void Awake() {
        GameMaster.disparaArma += atiraArma;
    }
	
	void atiraArma (float time) {
        if (time % rof == 0)
            Instantiate(projetil, saidaDaBala.position, saidaDaBala.rotation);
	}
}
