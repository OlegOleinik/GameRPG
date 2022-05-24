using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ANPC : AEnemy
{
    public int nPCid;
    protected Color interactionColor;
    [SerializeField] protected string[] usualPhrases;
    [SerializeField] protected string[] battlePhrases;
    [SerializeField] protected string[] usualNervousnessPhrases;
    [SerializeField] protected SpriteRenderer bodySpriteRenderer;
    [SerializeField] protected SpriteRenderer legSpriteRenderer;
    public bool isAngryToPlayer = false;
    protected State currentState;
    [SerializeField] protected AIPath aIPath;
    [SerializeField] protected GameObject targerForPathfinder;
    private InteractionController interactionController;
    [SerializeField] protected Animator bodyAnimator;
    [SerializeField] private Rigidbody rb3D;
    protected InteractionController.Interaction npcInteraction;
    protected Action stopInteraction;
    [SerializeField] protected Text text;
    protected float textTimer;
    protected bool isTextActive;
    [SerializeField] private AudioSource stepAudio;

    public override void Start()
    {
        transform.position = spawnPosition;
        base.Start();
        interactionController = GameManager.player.GetComponent<InteractionController>();
        aIPath.maxSpeed = speed;
        npcInteraction = StartTalk;
        stopInteraction = StopTalk;
        interactionColor = new Color(1, 0.98f, 0.32f, 1);
    }
    public virtual void SetAngryToPlayer()
    {
        isAngryToPlayer = true;
    }

    protected override void FixedUpdate()
    {
        currentState.onState();
    }

    public override void GetForce(Vector2 force)
    {
        StartCoroutine(SetPosWhileForce(force));
    }

    protected override void SetFlip(float x)
    {
        base.SetFlip(x);
        text.gameObject.transform.localScale = transform.localScale;
    }

    protected virtual void StartTalk()
    {
        if (isAngryToPlayer)
        {
            Talk(battlePhrases[UnityEngine.Random.Range(0, battlePhrases.Length)]);
        }
        else if (GameManager.player.GetComponent<AttackController>().isWeaponInHand)
        {
            Talk(usualNervousnessPhrases[UnityEngine.Random.Range(0, usualNervousnessPhrases.Length)]);
        }
        else
        {
            Talk(usualPhrases[UnityEngine.Random.Range(0, usualPhrases.Length)]);
        }
    }

    protected virtual void StopTalk()
    {

    }
    protected virtual void Talk(string txt)
    {
        text.gameObject.SetActive(true);
        text.color = new Color(0.196f, 0.196f, 0.196f, 1);
        text.text = txt;
        textTimer = Time.time + 5;
        if (!isTextActive)
        {
            StartCoroutine(DisappearText());
        }
    }

    private IEnumerator DisappearText()
    {
        isTextActive = true;
        while (textTimer > Time.time)
        {
            text.color -= new Color(0, 0, 0, 0.2f * Time.deltaTime);
            yield return null;
        }
        isTextActive = false;
        text.gameObject.SetActive(false);
    }

    public override void Disappear()
    {
        base.Disappear();
        GameManager.player.GetComponent<NPCController>().nPCs[nPCid].isDead = true;
    }

    //AStart поиск пути ломает физику 2D, этот костыль исправляет
    private IEnumerator SetPosWhileForce(Vector2 force)
    {
        rb3D.isKinematic = false;
        rb3D.AddForce(force * transform.localScale.x, ForceMode.Impulse);
        float startScale = transform.localScale.x;
        GameObject rbObject = rb3D.gameObject;
        float timer = Time.time + 1.5f;
        while (timer > Time.time)
        {
            transform.position += rbObject.transform.localPosition * startScale * transform.localScale.x;
            rbObject.transform.localPosition = Vector3.zero;
            yield return null;
        }
        rb3D.isKinematic = true;
        rbObject.transform.localPosition = Vector3.zero;
    }

    protected override void MoveToPos(Vector2 position)
    {
        targerForPathfinder.transform.position = new Vector3(position.x, position.y, 0);
    }

    public virtual void OnInteractionTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (interactionController.AddInteraction(npcInteraction, transform.position))
            {
                InteracrionColorChange();
            }
            else
            {
                StopInteracrionColorChange();
            }
        }
    }

    protected virtual void InteracrionColorChange()
    {
        bodySpriteRenderer.color = interactionColor;
        legSpriteRenderer.color = interactionColor;
    }

    protected virtual void StopInteracrionColorChange()
    {
        bodySpriteRenderer.color = Color.white;
        legSpriteRenderer.color = Color.white;
    }

    public virtual void OnInteractionTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StopInteracrionColorChange();
            interactionController.RemoveInteraction(npcInteraction);
            stopInteraction();
        }
    }

    protected virtual void NPCInteraction()
    {

    }

    public void GetAttackedByPlayer()
    {
        GetComponentInParent<NPSSpawner>().SetNPCsAngry();
    }

    protected void IdleAudio()
    {
        if (stepAudio.isPlaying == true)
        {
            stepAudio.loop = false;
            stepAudio.pitch = 1;
        }
    }
    protected void WalkAudio()
    {
        if (stepAudio.isPlaying == false || stepAudio.pitch != 1)
        {
            stepAudio.pitch = 1;
            stepAudio.Play();
            stepAudio.loop = true;
        }
    }
    protected void RunAudio()
    {
        if (stepAudio.pitch != 1.5f)
        {
            stepAudio.pitch = 1.5f;
            stepAudio.Play();
            stepAudio.loop = true;
        }
    }
}

public class State
{
    public Action onState;
    public State(Action func)
    {
        this.onState = func;
    }
}
