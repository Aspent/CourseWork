using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Test1
{
    class CollisionChecker
    {
        #region Methods

        public bool IsCollided(Player player, Room room)
        {

            var intersectionDeter = new IntersectionDeterminant();
            var border = room.Border;
            if (intersectionDeter.IsIntersected(player.Form,
                new RectangleF(room.Form.Left, room.Form.Top, border.Width, room.Form.Height))) 
            {
                return true;
            }

            if (intersectionDeter.IsIntersected(player.Form,
                new RectangleF(room.Form.Left, room.Form.Top, room.Form.Width, -border.Height)))
            {
                return true;
            }

            if (intersectionDeter.IsIntersected(player.Form,
                new RectangleF(room.Form.Right - border.Width, room.Form.Top, border.Width, room.Form.Height)))
            {
                return true;
            }

            if (intersectionDeter.IsIntersected(player.Form,
                new RectangleF(room.Form.Left, room.Form.Bottom + border.Height, room.Form.Width, -border.Height))) 
            {
                return true;
            }

            return false;
        }

        public bool IsCollided(Player player, Obstacle obstacle)
        {            
            var intersectionDeter = new IntersectionDeterminant();

            if (intersectionDeter.IsIntersected(player.Form, obstacle.Form)) 
            {
                return true;
            }
            return false;
        }

        public bool IsCollided(Player player, Enemy enemy)
        {
            var intersectionDeter = new IntersectionDeterminant();

            if (intersectionDeter.IsIntersected(player.Form, enemy.Form))
            {
                return true;
            }
            return false;
        }

        public bool IsCollided(Shot shot, Room room)
        {
            var intersectionDeter = new IntersectionDeterminant();
            var border = room.Border;
            if (intersectionDeter.IsIntersected(shot.Form,
                new RectangleF(room.Form.Left, room.Form.Top, border.Width, room.Form.Height)))
            {
                return true;
            }

            if (intersectionDeter.IsIntersected(shot.Form,
                new RectangleF(room.Form.Left, room.Form.Top, room.Form.Width, -border.Height)))
            {
                return true;
            }

            if (intersectionDeter.IsIntersected(shot.Form,
                new RectangleF(room.Form.Right - border.Width, room.Form.Top, border.Width, room.Form.Height)))
            {
                return true;
            }

            if (intersectionDeter.IsIntersected(shot.Form,
                new RectangleF(room.Form.Left, room.Form.Bottom + border.Height, room.Form.Width, -border.Height)))
            {
                return true;
            }

            return false;
        }

        public bool IsCollided(Shot shot, Player player)
        {
            var intersectionDeter = new IntersectionDeterminant();
            return intersectionDeter.IsIntersected(shot.Form, player.Form);         
        }

        public bool IsCollided(Shot shot, Enemy enemy)
        {
            var intersectionDeter = new IntersectionDeterminant();
            return intersectionDeter.IsIntersected(shot.Form, enemy.Form);
        }

        public bool IsCollided(Player player, FinishZone finishZone)
        {
            var intersectionDeter = new IntersectionDeterminant();
            return intersectionDeter.IsIntersected(player.Form, finishZone.Form);
        }

        #endregion
    }
}
