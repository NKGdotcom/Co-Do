using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckClick();
        }
    }
    /// <summary>
    ///�A�C�e�����g���邩
    /// </summary>
    public void CheckClick()
    {
        Vector2 _worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D _hit = Physics2D.Raycast(_worldPoint, Vector2.zero);

        if(_hit.collider != null)
        {
            GameObject _clickedObject = _hit.collider.gameObject;

            if (_clickedObject.CompareTag("PieceOfGlass"))  //�K���X��
            {
                if (HouseState.Instance.IsSafeGlass) return;
                PieceOfGlass _pieceOfGlass = _clickedObject.GetComponent<PieceOfGlass>();
                _pieceOfGlass.SafeGlass();
            }
            else if (_clickedObject.CompareTag("Radio")) //���W�I
            {
                if (HouseState.Instance.IsFixRadio) return;
                Radio _radio =_clickedObject.GetComponent<Radio>();
                _radio.FixRadio();
            }
            else if (_clickedObject.CompareTag("Breaker")) //�u���[�J�[
            {
                if (HouseState.Instance.IsFixBreaker) return;
                Breaker _breaker = _clickedObject.GetComponent<Breaker>();
                _breaker.FixBreaker();
            }
            else if (_clickedObject.CompareTag("Window")) //��
            {
                Window _window = _clickedObject.GetComponent<Window>();

                if (!HouseState.Instance.IsBreakWindow && !_window.IsWindowBreak)
                {
                    _window.BreakWindow();
                }
                else
                {
                    _window.AvoidTheRain();
                }
            }
        }
    }
}
