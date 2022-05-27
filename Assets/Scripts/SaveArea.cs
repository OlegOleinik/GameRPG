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
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
>>>>>>> Stashed changes
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.UI.GetComponent<UIScript>().SetSaveDisable();
<<<<<<< Updated upstream
<<<<<<< HEAD
        }
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

        }

=======
        }
>>>>>>> Stashed changes
=======
        }
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
        }
>>>>>>> Stashed changes
    }
}
