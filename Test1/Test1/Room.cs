using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Test1
{
    class Room
    {
        #region Fields

        RectangleF _form;
        int _texture;
        List<Obstacle> _obstacles = new List<Obstacle>();
        RoomBorder _border;
        List<Enemy> _enemies = new List<Enemy>();
        List<Shot> _shots = new List<Shot>();
        FinishZone _finishZone;
        

        #endregion

        #region Constructors

        public Room(RectangleF form, int texture)
        {
            _form = form;
            _texture = texture;
            //_obstacles.Add(new Obstacle(new RectangleF(form.Left + 0.84f, form.Bottom + 1.13f, 0.32f,
            //    -0.26f), 1));
            _border = new RoomBorder(0.15f, 0.15f, 0);
            _finishZone = new FinishZone(new RectangleF(form.Left + 0.85f, form.Bottom + 0.7f, 0.3f,
                -0.3f), 8);
            //_enemies.Add(new Enemy(form.Left + 0.5f, form.Bottom + 0.5f, 630.0f/2000, 371.0f/2000, 0.15f/60, 1000, 4));
        }

        #endregion

        #region Properties

        public RectangleF Form
        {
            get { return _form; }
        }

        public int Texture
        {
            get { return _texture; }
        }

        public List<Obstacle> Obstacles
        {
            get { return _obstacles; }
        }

        public RoomBorder Border
        {
            get { return _border; }
        }

        public List<Enemy> Enemies
        {
            get { return _enemies; }
        }

        public List<Shot> Shots
        {
            get { return _shots; }
        }

        public FinishZone FinishZone
        {
            get { return _finishZone; }
        }

        #endregion
    }    
}
