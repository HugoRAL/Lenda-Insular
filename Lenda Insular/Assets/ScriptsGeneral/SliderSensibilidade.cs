using UnityEngine;
using UnityEngine.UI;

public class SliderSensibilidade : MonoBehaviour
{
    public Slider slider;
    public Button guardarButton;
    private float sensibilidade;

    private void Start()
    {
        // Verifica se a chave "Sensibilidade" existe no PlayerPrefs
        if (PlayerPrefs.HasKey("Sensibilidade"))
        {
            // Recupera o valor salvo no PlayerPrefs
            sensibilidade = GetSens();
        }
        else
        {
            // Define um valor padrão caso a chave não exista
            sensibilidade = 0.5f;
        }

        // Define o valor inicial do slider
        slider.value = sensibilidade;

        // Registra o método para ser chamado quando o valor do slider mudar
        slider.onValueChanged.AddListener(AtualizarSensibilidade);

        // Registra o método para ser chamado quando o botão "Guardar" for pressionado
        guardarButton.onClick.AddListener(GuardarSensibilidade);
    }

    public float GetSens() => PlayerPrefs.GetFloat("Sensibilidade");

    private void AtualizarSensibilidade(float novoValor)
    {
        sensibilidade = novoValor;
    }

    private void GuardarSensibilidade()
    {
        // Salva o valor da sensibilidade no PlayerPrefs
        PlayerPrefs.SetFloat("Sensibilidade", sensibilidade);
        // Salva as alterações no PlayerPrefs
        PlayerPrefs.Save();
    }
}
