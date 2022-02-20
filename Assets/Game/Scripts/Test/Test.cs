using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using NaughtyAttributes;
using CodeMonkey.Utils;
using UnityEditor;
using UnityEngine.EventSystems;

#region Ray Events
//public class Test : MonoBehaviour
//{
//    public Camera mainCam;
//    private bool canCarry;

//    //private void Awake() => GetComponent<Button_UI>().ClickFunc = () => { };
//    private void Update()
//    {
//        //HandleTouch();
//    }

//    private void HandleTouch()
//    {
//        //Debug.Log("Input.mousePosition = " + Input.mousePosition);
//        //Debug.Log("ScreenPointToRay(Input.mousePosition) = " + MarteUtilius.GetScreenToWorldPoint(Input.mousePosition));


//        if (!Input.GetMouseButtonDown(0)) return;
//        if (EventSystem.current.IsPointerOverGameObject()) return;

//        if (canCarry) transform.position = MarteUtilius.GetScreenToWorldPoint(Input.mousePosition);
//        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

//        if (Physics.Raycast(ray, out RaycastHit hit, 10000.0f))
//        {
//            //Destroy(hit.transform.gameObject);
//            Debug.Log("dokandý");

//            canCarry = !canCarry;
//        }
//    }
//} 
#endregion

public class Test : MonoBehaviour
{
    #region One Bool Stands - Fields
    private enum BoolNames
    {
        defaultDrag, oneClickDrag, thirdDrag, fourthDrag,
    };
    [SerializeField,BoxGroup("[Only One Bool Stands]")] 
    private bool defaultDrag, oneClickDrag, thirdOne, fourthOne;
    private Dictionary<BoolNames, bool> newDic, prevDic;
    #endregion

    #region Drag Events - Fields
    private Vector3 offset;
    private float screenPosZ;
    #endregion

    #region One Bool Stands - Functions
    private void OnValidate()
    {
        OneBoolStandsSystem();
    }
    private void OneBoolStandsSystem()
    {
        //yeni deðerler güncellenir
        RefreshNewDic();

        //prev dic null'sa
        CheckPrevDicIsNull();

        //1den fazla bool'u varsa bi daha güncellenir
        CheckTrueCount();
    }
    private void CheckTrueCount()
    {
        int totalTrue = newDic.Where((t, i) => newDic[(BoolNames)i].Equals(true)).Count();

        if (totalTrue < 1)
        {
            defaultDrag = true;
            RefreshNewDic();
            prevDic = newDic;
        }
        else if (totalTrue > 1)
        {
            //son true olan bool dýþýndakiler false olur
            for (int i = 0; i < newDic.Count; i++)
            {
                if (prevDic[(BoolNames)i] || !newDic[(BoolNames)i]) continue;

                SetBools((BoolNames)i);
            }
        }
    }
    private void SetBools(BoolNames boolName)
    {
        switch (boolName)
        {
            case BoolNames.oneClickDrag:
                oneClickDrag = true; defaultDrag = false; thirdOne = false; fourthOne = false; break;
            case BoolNames.defaultDrag:
                oneClickDrag = false; defaultDrag = true; thirdOne = false; fourthOne = false; break;
            case BoolNames.thirdDrag:
                oneClickDrag = false; defaultDrag = false; thirdOne = true; fourthOne = false; break;
            case BoolNames.fourthDrag:
                oneClickDrag = false; defaultDrag = false; thirdOne = false; fourthOne = true; break;
            default:
                oneClickDrag = false; defaultDrag = true; thirdOne = false; fourthOne = false; break;
        }
        RefreshNewDic();
        prevDic = newDic;
    }
    private void CheckPrevDicIsNull()
    {
        //eski liste ilk defa oluþuyorsa
        prevDic ??= newDic;
    }
    private void RefreshNewDic()
    {
        newDic = new Dictionary<BoolNames, bool>()
        {
            { BoolNames.defaultDrag, defaultDrag },
            { BoolNames.oneClickDrag, oneClickDrag },
            { BoolNames.thirdDrag, thirdOne },
            { BoolNames.fourthDrag, fourthOne },
        };
    }
    #endregion

    #region Drag Events - Functions
    private void OnMouseDown()
    {
        oneClickDrag = !oneClickDrag;
        var position = gameObject.transform.position;
        //world space'ten objenin screenPosZ koordinatýný al
        screenPosZ = MarteUtilius.GetWorldToScreenPoint(position).z;
        //dünyada offset = dünyada objenin yeni konumu - dünyada mouse pozisyonu
        offset = position - MarteUtilius.GetScreenToWorldPoint(screenPosZ: screenPosZ);
    }
    private void Update()
    {
        if (!oneClickDrag) return;
        //objenin yeni pozisyonu = dünyadaki mouse pozisyonu + offset
        transform.position = MarteUtilius.GetScreenToWorldPoint(screenPosZ: screenPosZ) + offset;
    }
    private void OnMouseDrag()
    {
        if (!defaultDrag) return;
        //objenin yeni pozisyonu = dünyadaki mouse pozisyonu + offset
        transform.position = MarteUtilius.GetScreenToWorldPoint(screenPosZ: screenPosZ) + offset;
    }

    #endregion

}