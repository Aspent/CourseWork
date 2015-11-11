using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;

namespace Test1
{
    class RoomDrawer
    {
        #region Fields

        int[] _textures;

        #endregion

        #region Constructors

        public RoomDrawer(int[] textures)
        {
            _textures = textures;
        }

        #endregion

        #region Methods

        public void Draw(Room room)
        {
            GL.BindTexture(TextureTarget.Texture2D, _textures[room.Texture]);            

            new RectangleDrawer().Draw(room.Form);

            var borderDrawer = new RoomBorderDrawer(_textures);
            borderDrawer.Draw(room, room.Border);

            foreach(var t in room.Obstacles)
            {
                var obsDrawer = new ObstacleDrawer(_textures);
                obsDrawer.Draw(room, t);
            }

            foreach (var t in room.Enemies)
            {
                var enemyDrawer = new EnemyDrawer(_textures);
                enemyDrawer.Draw(t);
            }

            foreach (var t in room.Shots)
            {
                var shotDrawer = new ShotDrawer(_textures);
                shotDrawer.Draw(t);
            }

            if(room.FinishZone.IsActive)
            {
                var finishZoneDrawer = new FinishZoneDrawer(_textures);
                finishZoneDrawer.Draw(room.FinishZone);
            }
        }

        #endregion
    }
}
