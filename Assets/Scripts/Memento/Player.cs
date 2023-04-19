using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Memento
{
    class Player : MonoBehaviour
    {
        public Weapon weapon;
        public PlayerHealth health;
        public StoryObserver story;

        private GameHistory history;
        private PlayerMemento memento;

        private void Start()
        {
            history = new GameHistory();
            health = GetComponent<PlayerHealth>();

            memento = new PlayerMemento(health.health, weapon, transform.position);

            history.Push(memento);
        }

        public PlayerMemento StartSaveState()
        {
            return memento = new PlayerMemento(health.health, weapon, transform.position);
        }
        public void RefreshMemento()
        {
            memento.RefreshPlayerMemento(story.storyArc);
        }

        public void RestoreState()
        {
            transform.position = memento.Position;
            weapon = memento.Weapon;
            health.health = memento.Health;
            story.storyArc = memento.PlotArc;
        }

    }
}
