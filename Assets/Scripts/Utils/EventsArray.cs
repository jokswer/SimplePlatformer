using UnityEngine;
using UnityEngine.Events;

namespace Utils
{
    public class EventsArray : MonoBehaviour
    {
        public UnityEvent[] Events;
        
        public void StartEvent(int index)
        {
            Events[index].Invoke();
        }
    }
}