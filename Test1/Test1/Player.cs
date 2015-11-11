using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Timers;

namespace Test1
{
    class Player : Person
    {
        PlayerController _controller = new PlayerController();

        #region Constructors

        public Player(float x, float y, float width, float height, float speed, double attackSpeed, 
            int texture, ShotCharacteristics shotChar, int hp) 
            : base(x, y, width, height, speed, attackSpeed, texture, shotChar, hp)
        {

            
            
        }      

        public override bool CanMove(Vector2 direction, Room room)
        {
            var collisionChecker = new CollisionChecker();
            direction.Normalize();
            var movedPlayer = new Player(_x + _speed * direction.X, _y + _speed * direction.Y,
                _width, _height, _speed, _attackSpeed, _texture, _shotChar, _hp);
            if (collisionChecker.IsCollided(movedPlayer, room))
            {
                return false;
            }
            foreach (var t in room.Obstacles)
            {
                if (collisionChecker.IsCollided(movedPlayer, t))
                {
                    return false;
                }
            }
            foreach (var t in room.Enemies)
            {
                if (collisionChecker.IsCollided(movedPlayer, t))
                {
                    return false;
                }
            }
            return base.CanMove(direction, room);
        }

        #endregion

        public PlayerController Controller
        {
            get { return _controller; }
        }

    }
}
