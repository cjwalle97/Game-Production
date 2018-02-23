﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class may need to be redone a bit
public class SetUpCharacter : MonoBehaviour
{

    #region Arms
    public Arm setArm1;
    public Arm setArm2;
    public List<Arm> characterArmList = new List<Arm>();
    public Arm currentArm;

    public GameObject ArmObject;
    #endregion

    #region Legs
    public Legs setLegs;
    public Legs currentLegs;

    public GameObject LegsObject;
    #endregion

    #region Head
    public Head setHead;
    public Head currentHead;

    public GameObject HeadObject;
    #endregion


    public Character currentCharacter;
    public List<GameObject> bodyPartList = new List<GameObject>();
    public List<GameObject> savedCharacter = new List<GameObject>();

    private Quaternion currentRotationSet;

    void Start()
    {
        tag = "Character";
        currentRotationSet.eulerAngles = new Vector3(0, 0, 0);

        setArm1 = currentCharacter.Left;
        setArm2 = currentCharacter.Right;
        setLegs = currentCharacter.LegSet;
        setHead = currentCharacter.HeadPiece;

        PositionCharacterParts();

        if (currentCharacter.Display != true)
            transform.position = new Vector3(0, 5, transform.position.z);

    }

    void Update()
    {
        
    }

    public void PositionCharacterParts()
    {
        PositionArm();
        PositionLegs();
        PositionHead();
        KeepCharacterSetup();
    }


    // Position arms based on Arm objects given
    public void PositionArm()
    {
        for (int i = 0; i < 2; i++)
        {
            currentArm = characterArmList[i];

            if (currentArm.isLeft)
            {
                GameObject LeftArm = Instantiate(currentArm.prefab);
                ArmObject.transform.SetParent(transform);
                ArmObject.transform.localScale = new Vector3(1, 1, 1);
                ArmObject.GetComponent<CapsuleCollider>().height = 1;
                currentRotationSet.eulerAngles = new Vector3(0, 0, 0);
                ArmObject.transform.position = transform.position + new Vector3(-3, 0, 0);
                ArmObject.transform.rotation = currentRotationSet;
                currentArm.armPos = ArmObject.transform.position;
                ArmObject.tag = "Character";
                bodyPartList.Add(ArmObject);
            }

            else if (currentArm.isRight)
            {
                GameObject RightArm = Instantiate(currentArm.prefab);
                ArmObject.transform.SetParent(transform);
                ArmObject.transform.localScale = new Vector3(1, 1, 1);
                ArmObject.GetComponent<CapsuleCollider>().height = 1;
                currentRotationSet.eulerAngles = new Vector3(0, 0, 0);
                ArmObject.transform.position = transform.position + new Vector3(3, 0, 0);
                ArmObject.transform.rotation = currentRotationSet;
                currentArm.armPos = ArmObject.transform.position;
                ArmObject.tag = "Character";
                bodyPartList.Add(ArmObject);
            }
        }
    }

    //  Position Legs based on given Legs object
    public void PositionLegs()
    {
        currentLegs = setLegs;

        GameObject LegSet = Instantiate(currentLegs.prefab);
        LegsObject.transform.SetParent(transform);
        LegsObject.transform.localScale = new Vector3(1, 1, 1);
        currentRotationSet.eulerAngles = new Vector3(0, 0, 0);
        LegsObject.transform.position = transform.position + new Vector3(0, -3f, 0);
        LegsObject.transform.rotation = currentRotationSet;
        LegsObject.tag = "Character";
        bodyPartList.Add(LegsObject);
    }

    //  Position head based on given Head object
    public void PositionHead()
    {
        currentHead = setHead;

        GameObject HeadPiece = Instantiate(currentHead.prefab);
        HeadObject.transform.SetParent(transform);
        HeadObject.transform.localScale = new Vector3(1, 1, 1);
        currentRotationSet.eulerAngles = new Vector3(0, 0, 0);
        HeadObject.transform.position = transform.position + new Vector3(0, 3f, 0);
        HeadObject.transform.rotation = currentRotationSet;
        LegsObject.tag = "Character";
        bodyPartList.Add(HeadObject);
    }

    public void DestroyParts()
    {
        for (int i = 4; i >= bodyPartList.Count; i--)
        {
            Destroy(bodyPartList[i]);
        }
    }

    // Keeping selected character for scene transition
    public void KeepCharacterSetup()
    {
        DontDestroyOnLoad(this);
        for (int i = 0; i < savedCharacter.Count; i++)
            DontDestroyOnLoad(savedCharacter[i]);
    }
}
