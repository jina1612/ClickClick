using System.Collections.Generic;
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
    [SerializeField] private KeyCode keyCode;
    public KeyCode KeyCode
    {
        get
        {
            return keyCode;
        }
    }


    private List<Note> noteList = new List<Note>();

    void Start()
    {
        anim.Play();
        for (int i = 0; i < noteMaxNum; i++)
        {
            SpawnNote(true);
        }
    }

    private void SpawnNote(bool isApple)
    {
        GameObject noteGameObj = Instantiate(notePrefab);
        noteGameObj.transform.SetParent(noteSpwan.transform);
        noteGameObj.transform.localPosition = Vector3.up * noteList.Count * noteGap;
        Note note = noteGameObj.GetComponent<Note>();
        note.SetSprite(isApple);

        noteList.Add(note);
    }

    public void OnInput(bool isApple)
    {
        //노트 삭제
        Note delNote = noteList[0];
        delNote.Destory();
        noteList.RemoveAt(0);

        for (int i = 0; i < noteList.Count; i++)
            noteList[i].transform.localPosition = Vector3.up * i * noteGap;

        //생성
        SpawnNote(isApple);

        anim.Play();
        btnSpriteRenderer.sprite = selectBtnSrite;
    }
    public void callAniDone()
    {
        btnSpriteRenderer.sprite = normalBtnSprite;
    }

}




