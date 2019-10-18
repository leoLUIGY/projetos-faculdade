using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoAtira : MonoBehaviour
{
    public GameObject canoInimigo;
    public GameObject balaInimigo;
    public Transform linhaInicio, linhaFim;

    public bool linha;

    private Animator atiraPara;
    // Start is called before the first frame update
    void Start()
    {
        atiraPara = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(linhaInicio.position, linhaFim.position, Color.green);
        linha = Physics2D.Linecast(linhaInicio.position, linhaFim.position, 1 << LayerMask.NameToLayer("jogador"));

        if (linha == true)
        {
            atiraPara.SetBool("playerNaMira", true);

            Instantiate(balaInimigo, new Vector3(canoInimigo.transform.position.x, canoInimigo.transform.position.y,
            canoInimigo.transform.position.z), canoInimigo.transform.rotation);
        } else {
            atiraPara.SetBool("playerNaMira", false);
        }


    }
}
