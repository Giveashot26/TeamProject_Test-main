﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STM
{
    public class Lever : MonoBehaviour, IInteractable
    {
        [SerializeField] private bool isActivated = false; 
        [SerializeField] private List<GameObject> linkedObjects = new List<GameObject>(); 

        private SpriteRenderer spriteRenderer;
        private Color defaultColor;
        private Color redColor = Color.red;

        private bool isLeverOn = false; 

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            defaultColor = spriteRenderer.color;

            if (CompareTag("RedLever"))
            {
                isActivated = true; 
            }

            else if (CompareTag("BlackLever"))
            {
                isActivated = false; 
            }

            UpdateLeverColor();
            
        }

        private void UpdateLeverColor()
        {
            spriteRenderer.color = isActivated ? redColor : defaultColor;
        }


        public void OnInteract()
        {
            isLeverOn = !isLeverOn;
            Debug.Log(isLeverOn ? "Lever가 켜졌습니다!" : "Lever가 꺼졌습니다!");

            if (isActivated)
            {
                foreach (GameObject obj in linkedObjects)
                {
                    Hor_ActivateObject(obj);
                    Ver_ActivateObject(obj);
                }
            }
        }


        private void Hor_ActivateObject(GameObject obj)
        {
            HorizontalMoveObject horMove = obj.GetComponent<HorizontalMoveObject>();
            if (horMove != null)
            {
                horMove.ToggleMovement(isLeverOn);
            }
           
        }

   
        private void Ver_ActivateObject(GameObject obj)
        {
            VerticalMoveObject verMove = obj.GetComponent<VerticalMoveObject>();

            if (verMove != null)
            {
                verMove.ToggleMovement(isLeverOn);
            }
          
        }

        public void ToggleLever() //검정레버
        {
            if (CompareTag("BlackLever"))
            {
                isActivated = !isActivated; 
                UpdateLeverColor();

                Debug.Log(isActivated ? "BlackLever가 빨간 상태로 변경됨!" : "BlackLever가 검정 상태로 변경됨!");
            }
        }

       
    }
}
