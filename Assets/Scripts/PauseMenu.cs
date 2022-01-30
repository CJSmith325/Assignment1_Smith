using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject exitUI;
    bool isPaused = false;              //bool = true or false

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            //unpause
            Time.timeScale = 1.0f;

            //isPaused = false;
            //When isPaused is true, this line will set it to false


            //When ispaused is true, this line will set it to false.
            pauseUI.SetActive(false);
            exitUI.SetActive(false);
        }

        else
        {
            //pause
            Time.timeScale = 0.0f;

            //isPause = true;
            //When isPause os false, this line will set it to true.

            //Shows the button when the pame is pause
            pauseUI.SetActive(true);
            exitUI.SetActive(true);
        }

        isPaused = !isPaused;            //! means not/no

        //Sets isPaused to the opposite of what it is right now
        //isPaused = !isPause;
    }

    public void Quit()
    {
        Application.Quit();
    }

}
