using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;

    [SerializeField] private GameObject noteGroupRrefab;
    [SerializeField] private float noteGroupGap = 1f;
    [SerializeField]
    private KeyCode[] whoIeKeyCodesArr = new KeyCode[] {
         KeyCode.A,KeyCode.S, KeyCode.D, KeyCode.F,
         KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L
    };
    [SerializeField] private int initNoteGroupNum = 2;
    private List<NoteGroup> noteGroupList = new List<NoteGroup>();

    private void Awake()
    {
        Instance = this;
    }
    public void Create()
    {
        for (int i = 0; i < initNoteGroupNum; i++)
        {
            CreateNoteGroup(whoIeKeyCodesArr[i]);
        }
    }

    public void CreateNoteGroup()
    {
        int noteGroupCount = noteGroupList.Count;
        if (whoIeKeyCodesArr.Length <= noteGroupCount)
            return;

        KeyCode Keykode = whoIeKeyCodesArr[noteGroupList.Count];
        CreateNoteGroup(Keykode);

    }
    private void CreateNoteGroup(KeyCode keyCode)
    {
        GameObject noteGroupObj = Instantiate(noteGroupRrefab);
        noteGroupObj.transform.position = Vector3.right * noteGroupList.Count * noteGroupGap;

        NoteGroup noteGroup = noteGroupObj.GetComponent<NoteGroup>();
        noteGroup.Create(keyCode);

        noteGroupList.Add(noteGroup);
    }

    public void Onlnput(KeyCode keyCode)
    {
        int randld = Random.Range(0, 2);
        bool isApple = randld == 0 ? true : false;

        foreach (NoteGroup noteGroup in noteGroupList)
        {
            if (keyCode == noteGroup.KeyCode)
            {
                noteGroup.OnInput(isApple);
                break;
            }
        }
    }
}
