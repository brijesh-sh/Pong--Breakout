using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickFactory : MonoBehaviour
{

    [SerializeField] private GameObject _brick;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _brick1;
    [SerializeField] private Sprite _brick2;
    [SerializeField] private Sprite _brick3;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = _brick.GetComponent<SpriteRenderer>();
        MakeBricks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeBricks()
    {
        for (int i = 8; i > 0; i--)
        {
            for (int j = 0; j < 3; j++)
            {
                float rand = Random.Range(1, 4);
                //Debug.Log(rand);
                Instantiate(_brick, new Vector3((i - 4.4f) * 0.8f,
                (j + 2.6f) * 0.6f, 0), Quaternion.identity);
                
                if(rand == 1) _spriteRenderer.sprite = _brick1;
                else if (rand == 2) _spriteRenderer.sprite = _brick2;
                else if (rand == 3) _spriteRenderer.sprite = _brick3;
            }
        }
    }
}
