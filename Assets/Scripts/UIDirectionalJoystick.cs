using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(RectTransform))]
public class UIDirectionalJoystick : UIBehaviour, IPointerDownHandler, IPointerUpHandler, 
    IBeginDragHandler, IDragHandler, IEndDragHandler, IDeselectHandler {

    private Vector2 axis;
    private bool isDragging = false;
    private bool isClicking = false;

    [SerializeField]
    private float speedBackInitialPosition = 25.0f;
    [SerializeField]
    private RectTransform directionalJoystick = null;
    [SerializeField]
    private bool receiveMissedFocusNotification = false;

    private RectTransform _rectTransform;
    public RectTransform rectTransform {
        get {
            if (!_rectTransform) {
                _rectTransform = transform as RectTransform;
            }
            
            return _rectTransform;
        }
    }

    [HideInInspector]
    public float horizontal;
    [HideInInspector]
    public float vertical;

    /* Quando for dado um click */
    public void OnPointerDown(PointerEventData eventData) {
        if (IsActive() == false) {
            return;
        }

        //Define que o gameobject foi selecionado pelo EventSystem
        //Tambem para poder receber o OnDeselect
        if (receiveMissedFocusNotification) {
            EventSystem.current.SetSelectedGameObject(gameObject, eventData);
        }

        this.isClicking = true;
    }

    /* Quando soltar o botao */
    public void OnPointerUp(PointerEventData eventData) {
        this.isClicking = false;
    }

    /* Quando o gameobject vai comecar a ser arrastado */
    public void OnBeginDrag(PointerEventData eventData) {
        if (IsActive() == false) {
            return;
        }

        //Define que o gameobject foi selecionado pelo EventSystem
        //Tambem para poder receber o OnDeselect
        if (receiveMissedFocusNotification) {
            EventSystem.current.SetSelectedGameObject(gameObject, eventData);
        }

        //Transforma posicao do clique em espaco local do gameobject
        Vector2 newAxis = transform.InverseTransformPoint(eventData.position);

        //Calculo para os valores do eixo ficarem entre -1 e 1
        newAxis.x /= this.rectTransform.sizeDelta.x * 0.5f;
        newAxis.y /= this.rectTransform.sizeDelta.y * 0.5f;

        SetAxis(newAxis);
        this.isDragging = true;
    }

    /* Quando o gameobject eh movido enquanto esta sendo arrastado */
    public void OnDrag(PointerEventData eventData) {
        //Transforma ponto do espaco da tela em espaco local do gameobject
        RectTransformUtility.ScreenPointToLocalPointInRectangle(this.rectTransform, 
            eventData.position, eventData.pressEventCamera, out this.axis);
        
        //Calculo para os valores do eixo ficarem entre -1 e 1
        this.axis.x /= this.rectTransform.sizeDelta.x * 0.5f;
        this.axis.y /= this.rectTransform.sizeDelta.y * 0.5f;
        
        SetAxis(this.axis);
    }

    /* Quando deixa de arrastar o gameobject */
    public void OnEndDrag(PointerEventData eventData) {
        this.isDragging = false;
    }

    /* Quando o gameobject perde o foco */
    public void OnDeselect(BaseEventData data) {
        if (receiveMissedFocusNotification) {
            this.isDragging = false;
            this.isClicking = false;
        }
    }

    private void LateUpdate() {
        if (this.isDragging == false) {
            if (this.axis != Vector2.zero) {
                //Calculo para o directionalJoystick voltar para posicao inicial
                Vector2 newAxis = this.axis - (this.axis * Time.deltaTime * this.speedBackInitialPosition);

                if (newAxis.sqrMagnitude <= 0.1f) {
                    newAxis = Vector2.zero;
                }

                SetAxis(newAxis);
            }
        }
    }

    private void SetAxis(Vector2 newAxis) {
        //Retorna magnitude do newAxis limitando a 1
        //Limita para que o directionalJoystick não saia de dentro do seu espaco
        this.axis = Vector2.ClampMagnitude(newAxis, 1);
        
        UpdateDirectionalJoystick();

        horizontal = this.axis.x;
        vertical = this.axis.y;
    }

    /* Atualizar posicao do directionalJoystick */
    private void UpdateDirectionalJoystick() {
        if (directionalJoystick) {
            //Calculo recebe os valores entre -1 e 1 e ajusta proporcionalmente no espaco
            directionalJoystick.localPosition = (this.axis 
                * Mathf.Max(this.rectTransform.sizeDelta.x, this.rectTransform.sizeDelta.y) * 0.5f);
        }
    }

    public bool IsDragging() {
        return this.isDragging;
    }

    public bool IsClicking() {
        return this.isClicking;
    }

    #if UNITY_EDITOR
    protected override void OnValidate() {
        base.OnValidate();
        UpdateDirectionalJoystick();
    }
    #endif
}