using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream

public class GlobalLightController : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
=======
using UnityEngine.Rendering.Universal;

public class GlobalLightController : MonoBehaviour
{
    [SerializeField] private Light2D light2d;
    [SerializeField] private float cycle = 600;
    private float _currentTime = 0;


    private Color nightColor = new Color(0.26f, 0.26f, 0.26f);
    private Color dayColor = Color.white;
    private Color morningColor = new Color(0.56f, 0.51f, 0.44f);
    private Color eveningColor = new Color(0.54f, 0.48f, 0.59f);

    private GameManager.EndCorutine end;


    public Color currentColor
    {
        get
        {
            return light2d.color;
        }
    }

    public float currentTime
    {
        get
        {
            return _currentTime;
        }
    }



    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        Morning1();
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;


    }

    private void Morning1()
    {
        _currentTime = 0;
        end = Morning2;
        StartCoroutine((cycle / 8).Tweeng((u) => light2d.color = u, light2d.color, morningColor, end));
    }

    private void Morning2()
    {
        end = Day;
        StartCoroutine((cycle / 8).Tweeng((u) => light2d.color = u, light2d.color, dayColor, end));
    }

    private void Day()
    {
        end = Evening1;
        StartCoroutine(NoChangeWait(cycle / 4));
    }

    private void Evening1()
    {
        end = Evening2;
        StartCoroutine((cycle / 8).Tweeng((u) => light2d.color = u, light2d.color, eveningColor, end));
    }

    private void Evening2()
    {
        end = Night;
        StartCoroutine((cycle / 8).Tweeng((u) => light2d.color = u, light2d.color, nightColor, end));
    }

    private void Night()
    {

        end = Morning1;
        StartCoroutine(NoChangeWait(cycle / 4));
    }



    public void LoadTime(float time, Color color)
    {
        StopAllCoroutines();
        int stage = 0;
        for (int i = 0; i < 6; i++)
        {
            if ((((cycle / 8) * (i + 1)) / time) > 1)
            {
                stage = i;
                break;
            }
        }

        switch (stage)
        {
            case 0:
                end = Morning2;
                StartCoroutine(((cycle / 8) - time).Tweeng((u) => light2d.color = u, color, morningColor, end));
                break;
            case 1:
                end = Day;
                StartCoroutine(((cycle / 8) - time).Tweeng((u) => light2d.color = u, color, dayColor, end));
                break;
            case 2:
                end = Evening1;
                StartCoroutine(NoChangeWait((cycle / 4) - time));
                break;
            case 3:
                end = Evening2;
                StartCoroutine(((cycle / 8) - time).Tweeng((u) => light2d.color = u, color, eveningColor, end));
                break;
            case 4:
                end = Night;
                StartCoroutine(((cycle / 8) - time).Tweeng((u) => light2d.color = u, color, nightColor, end));
                break;
            case 5:
                end = Morning1;
                StartCoroutine(NoChangeWait((cycle / 4) - time));
                break;
            default:
                break;
        }
        _currentTime = time;
    }


    


    private IEnumerator NoChangeWait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        end();
>>>>>>> Stashed changes
    }
}
