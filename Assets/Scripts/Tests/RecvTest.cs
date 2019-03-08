using HeroesOfCode.Messages;
using UniRx;
using UnityEngine;
using Zenject;

namespace HeroesOfCode.Tests
{
    public class RecvTest : MonoBehaviour
    {
        [Inject] public IMessageBroker mb;

        private void Start()
        {
            mb.Receive<GridInteractMessage>().Subscribe(GridInterract);
        }

        private void GridInterract(GridInteractMessage obj)
        {
            Debug.Log(obj);
        }
    }
}