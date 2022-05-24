using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.UI.GetComponent<UIScript>().SetSaveActive();
        }
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.UI.GetComponent<UIScript>().SetSaveDisable();
<<<<<<< Updated upstream
<<<<<<< Updated upstream

        }

=======
        }
>>>>>>> Stashed changes
=======
        }
>>>>>>> Stashed changes
    }
}
