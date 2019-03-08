using HeroesOfCode.Messages;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace HeroesOfCode.Components
{
    public class GridCell : MonoBehaviour, IPointerClickHandler
    {
        [Inject]
        public IMessageBroker MessageBroker { get; set; }

        public Vector2Int Node;

        public void OnPointerClick(PointerEventData eventData)
        {
            MessageBroker.Publish(new GridInteractMessage()
            {
                Node = Node
            });
        }
    }
}