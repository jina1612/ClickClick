using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoteGroup : MonoBehaviour
{
    [SerializeField] private int noteMaxNum = 5;
    [SerializeField] private GameObject notePrefab;
    [SerializeField] private GameObject noteSpwan;
    [SerializeField] private float noteGap = 6f;

    [SerializeField] private SpriteRenderer btnSpriteRenderer;
    [SerializeField] private Sprite normalBtnSprite;
    [SerializeField] private Sprite selectBtnSrite;
    [SerializeField] private Animation anim;
    

    private List<Note> noteList = new List<Note>();

    void Start()
    {
        anim.Play();
        for (int i = 0; i < noteMaxNum; i++)
        {
            GameObject noteGameObj = Instantiate(notePrefab);
            noteGameObj.transform.SetParent(noteSpwan.transform);
            noteGameObj.transform.localPosition = Vector3.up * noteList.Count * noteGap;

            Note note = noteGameObj.GetComponent<Note>();

            noteList.Add(note);
        }
    }

    void Update()


    {
        
    }

    public void OnInput(bool isSelect)
    {
        if (isSelect)
        {
            anim.Play();
            btnSpriteRenderer.sprite = selectBtnSrite;
        }


    }
    public void callAniDone()
    {
        btnSpriteRenderer.sprite = normalBtnSprite;
    }
}
   

