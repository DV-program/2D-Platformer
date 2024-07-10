using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Sripts.Interfaces
{
    public interface IDamageable
    {
        public void TakeDamage(int value);
        public void Heal(int value);
    }
}
