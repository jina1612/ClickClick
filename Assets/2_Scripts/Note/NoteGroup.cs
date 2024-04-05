using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private TextMeshPro keyCodeTmp;
    [SerializeField] private Animation anim;
    private KeyCode keyCode;
    public KeyCode KeyCode
    {
        get
        {
            return keyCode;
        }
    }

    private List<Note> noteList = new List<Note>();

    public void Create(KeyCode keyCode)
    {
        this.keyCode = keyCode;
        keyCodeTmp.text = keyCode.ToString();

        for (int i = 0; i < noteMaxNum; i++)
        {
            CreateNote(true);
        }

        InputManager.Instance.AddKeyCode(keyCode);
    }

    private void CreateNote(bool isApple)
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
        //��Ʈ ����
        Note delNote = noteList[0];
        delNote.DeleteNote();
        noteList.RemoveAt(0);

        for (int i = 0; i < noteList.Count; i++)
            noteList[i].transform.localPosition = Vector3.up * i * noteGap;

        //����
        CreateNote(isApple);

        anim.Play();
        btnSpriteRenderer.sprite = selectBtnSrite;
    }
    public void callAniDone()
    {
        btnSpriteRenderer.sprite = normalBtnSprite;
    }

}




