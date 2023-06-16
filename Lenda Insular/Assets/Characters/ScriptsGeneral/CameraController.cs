using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SliderSensibilidade : MonoBehaviour
{
    public Slider slider;
    public string sensibilidadeFilePath = "sensibilidade.txt";

    public static event System.Action<float> OnSensibilidadeChanged;

    public static SliderSensibilidade Instance { get; private set; }

    private float sensibilidade;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // Verifica se o arquivo de sensibilidade existe
        if (File.Exists(sensibilidadeFilePath))
        {
            // Carrega o valor do arquivo
            string valorSensibilidade = File.ReadAllText(sensibilidadeFilePath);
            float.TryParse(valorSensibilidade, out sensibilidade);
        }
        else
        {
            // Define um valor padrão caso o arquivo não exista
            sensibilidade = 0.5f;
        }

        // Define o valor inicial do slider
        slider.value = sensibilidade;
        // Registra o método para ser chamado quando o valor do slider mudar
        slider.onValueChanged.AddListener(AtualizarSensibilidade);
    }

    private void AtualizarSensibilidade(float novoValor)
    {
        sensibilidade = novoValor;
        // Salva o valor da sensibilidade no arquivo de texto
        File.WriteAllText(sensibilidadeFilePath, sensibilidade.ToString());

        // Dispara o evento informando a nova sensibilidade
        OnSensibilidadeChanged?.Invoke(sensibilidade);
    }
}
