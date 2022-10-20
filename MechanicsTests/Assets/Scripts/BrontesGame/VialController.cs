using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VialController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Header("References")]
    public Slider vial;
    public Image vialLiquid;
    private VialController targetVial = null;
    
    [Header("Liquid Variables")]
    public float currentAmount;
    public float maxAmount;
    public float amountLeft;
    public bool liquidSource;
    public LiquidType liquidType;
    public enum LiquidType
    {
        red,
        blue,
        green,
        yellow,
        none
    }

    [Header("Vial Variables")]
    private Vector3 startPosition;
    private bool isHeld = false;


    private void Start()
    {
        vial.maxValue = maxAmount;
        //currentAmount = 0;
        //liquidType = LiquidType.none;
        vial.value = currentAmount;
        startPosition = gameObject.transform.position;
        amountLeft = maxAmount - currentAmount;
    }

    public void SetSliderValue()
    {
        if (targetVial != null)
        {
            if (targetVial.liquidType == LiquidType.none || targetVial.liquidType == liquidType)
            {
                //sets the target liquid to this vials liquid type
                if (targetVial.liquidType == LiquidType.none)
                {
                    targetVial.liquidType = liquidType;
                }

                //fills the target vial as much as possible keeping any remainder still in the vial
                //if there is no liquid left the empty vial is set to have no liquid type
                if (liquidSource == true)
                {
                    targetVial.currentAmount = targetVial.maxAmount;
                }
                else if (currentAmount > targetVial.amountLeft)
                {
                    targetVial.currentAmount = targetVial.maxAmount;
                    currentAmount -= targetVial.amountLeft;
                }
                else if (currentAmount <= targetVial.amountLeft)
                {
                    targetVial.currentAmount += currentAmount;
                    currentAmount = 0;
                    liquidType = LiquidType.none;
                }
                targetVial.amountLeft = targetVial.maxAmount - targetVial.currentAmount;
                amountLeft = maxAmount - currentAmount;
                targetVial.SetSliderValue();
            }
        }

        vial.value = currentAmount;
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        Debug.Log("Down");
        isHeld = true;
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        Debug.Log("Up");
        isHeld = false;
        SetSliderValue();
        gameObject.transform.position = startPosition;
    }

    private void Update()
    {
        if (isHeld)
        {
            Debug.Log("Moving");
            gameObject.transform.position = Input.mousePosition;
        }

        if (currentAmount > 0 && liquidType == LiquidType.none)
        {
            Debug.LogError("Liquid exists with no type" + name);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isHeld)
        {
            if (collision.gameObject.CompareTag("Vial"))
            {
                targetVial = collision.gameObject.GetComponent<VialController>();
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        targetVial = null;
    }
}
