using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MarkerScript : MonoBehaviour
{
    [SerializeField]
    Transform tip;
    [SerializeField]
    int thickness = 5;

    private Renderer _rend;
    private Color[] colors;

    [SerializeField]
    private float _tipHeight = 0.05f;

    private Board _board;
    RaycastHit hit;

    private Vector2 _hitPosition;
    private Vector2 _lastHitPosition;

    private bool isTouching;

    void Start()
    {
        _rend = tip.GetComponent<Renderer>();
        colors = Enumerable.Repeat(_rend.material.color, thickness * thickness).ToArray();
    }

    void Update()
    {
        Draw();
    }

    private void Draw()
    {
        if (Physics.Raycast(tip.position, transform.up, out hit, _tipHeight))
        {
            if (hit.transform.CompareTag("Board"))
            {
                if (_board == null)
                    _board = hit.transform.GetComponent<Board>();

            }
            Debug.Log(_board.gameObject.name);
            _hitPosition = new Vector2(hit.textureCoord.x, hit.textureCoord.y);

            var x = (int)(_hitPosition.x * _board.textureSize.x) - (thickness / 2);
            var y = (int)(_hitPosition.y * _board.textureSize.y) - (thickness / 2);

            if (y < 0 || y > _board.textureSize.y || x < 0 || x > _board.textureSize.x)
                return;

            if (isTouching) 
            {
                _board.texture.SetPixels(x, y, thickness, thickness, colors);

                for (float f = 0.005f; f < 1.00f; f += 0.005f) 
                {
                    var lerpX = (int)Mathf.Lerp(_lastHitPosition.x, x, f);
                    var lerpY = (int)Mathf.Lerp(_lastHitPosition.y, y, f);

                    _board.texture.SetPixels(lerpX, lerpY, thickness, thickness, colors);
                }

                _board.texture.Apply();
            }

            _lastHitPosition = new Vector2(x, y);
            isTouching = true;
            return;
        }
        _board = null;
        isTouching = false;
    }
}
