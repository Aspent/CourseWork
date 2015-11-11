using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Enemy : Person
    {
        #region Constructors

        public Enemy(float x, float y, float width, float height, float speed, double attackSpeed, 
            int texture, ShotCharacteristics shotChar, int hp) 
            : base(x, y, width, height, speed, attackSpeed, texture, shotChar, hp)
        {

        }

        #endregion
    }
}
