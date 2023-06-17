using UnityEngine;
using UnityEngine.UI;

public class SoundGeral : MonoBehaviour
{
    public Slider slider;
    public Button guardarButton;
    private float volume;

    private void Start()
    {
        // Verifica se a chave "Volume" existe no PlayerPrefs
        if (PlayerPrefs.HasKey("Volume"))
        {
            // Recupera o valor salvo no PlayerPrefs
            volume = GetVolume();
            slider.value = volume; // Define o valor do slider com o valor guardado
        }
        else
        {
            // Define um valor padrão caso a chave não exista
            volume = 0.5f;
            slider.value = volume; // Define o valor padrão no slider
        }

        // Registra o método para ser chamado quando o valor do slider mudar
        slider.onValueChanged.AddListener(AtualizarVolume);

        // Registra o método para ser chamado quando o botão "Guardar" for pressionado
        guardarButton.onClick.AddListener(GuardarVolume);
    }

    private void OnDisable()
    {
        // Salva o valor do volume no PlayerPrefs ao desativar o objeto
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }

    public float GetVolume() => PlayerPrefs.GetFloat("Volume");

    private void AtualizarVolume(float novoValor)
    {
        volume = novoValor;
        // Aplica o novo volume geral para todos os elementos de áudio do jogo
        AudioListener.volume = volume;
    }

    private void GuardarVolume()
    {
        // Salva o valor do volume no PlayerPrefs
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }
}
