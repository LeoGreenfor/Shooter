using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Memento
{
    class PlayerMemento
    {
        public float Health { get; private set; }
        public Weapon Weapon { get; private set; }

        public Vector3 Position { get; private set; }

        public int PlotArc { get; private set; }

        public PlayerMemento(float health, Weapon weapon, Vector3 position)
        {
            this.Health = health;
            this.Weapon = weapon;
            this.Position = position;
            this.PlotArc = 0;
        }
        public void RefreshPlayerMemento(int plotArc)
        {
            this.PlotArc = plotArc;
        }

        public override string ToString() 
            => $"Health: {Health}, Weapon: {Weapon}, Position: {Position}";
    }
}
