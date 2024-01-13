using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCreator : MonoBehaviour
{
    protected float timer;

    [SerializeField]
    protected float createInterval;

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }

    protected virtual void OnUpdate()
    {
        timer += Time.deltaTime;
        if(timer >= createInterval)
        {
            Create();
            timer = 0.0f;
        }
    }

    protected abstract void Create();

     protected void Create(BaseCharacter baseCharacter, Transform transform)
    {
        baseCharacter = Instantiate(baseCharacter, transform.position, transform.rotation);
        baseCharacter.Setup();
    }
}
