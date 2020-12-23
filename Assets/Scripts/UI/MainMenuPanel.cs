using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPanel : MonoBehaviour
{
	[SerializeField] private AudioSource musicSoure;

    public void StartLevel()
	{
		SceneManager.LoadScene(1);
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void SetMusicVolume(float volume)
	{
		musicSoure.volume = volume;
		PlayerPrefs.SetFloat("musicVolume", volume);
	}

	public void SetSfxVolume(float volume)
	{
		PlayerPrefs.SetFloat("sfxVolume", volume);
	}
}
