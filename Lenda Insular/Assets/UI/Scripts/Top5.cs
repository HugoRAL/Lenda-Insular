using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Top5 : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public Crons con;
    // Start is called before the first frame update
    void Start()
    {
        // Acessa o componente TextMeshProUGUI do objeto
        textMeshPro = GetComponent<TextMeshProUGUI>();

        // Atualiza o texto
        textMeshPro.text = "Novo texto";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
