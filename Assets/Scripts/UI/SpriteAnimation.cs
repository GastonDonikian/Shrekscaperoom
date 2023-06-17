using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteAnimation : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprites;

     private Image _element;

    [SerializeField] private float _speed;

    private float _timer = 1;

    private int _index = 0;

    [SerializeField] private int _repeats;
    // Start is called before the first frame update
    void Start()
    {
        _repeats = -1;
        _element = GetComponent<Image>();
        _element.sprite = _sprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime * _speed;
        if (_timer <= 0 && _repeats != 0)
        {
            _index = (_index + 1) >= _sprites.Count ? 0 : _index + 1;
            _element.sprite = _sprites[_index];
            _timer = 1;
            if (_index == 0)
                _repeats -= 1;
        }
        

    }
}
