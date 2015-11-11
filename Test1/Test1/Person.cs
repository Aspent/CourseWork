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
    class Person
    {
        #region Fields
        
        protected float _x;
        protected float _y;
        protected float _height;
        protected float _width;
        protected float _speed;
        protected int _texture;
        protected bool _canShoot;
        protected int _hp;
        protected double _attackSpeed;
        protected bool _isDead;
        protected ShotCharacteristics _shotChar;

        #endregion

        #region Constructors

        public Person(float x, float y, float width, float height, float speed, double attackSpeed,
            int texture, ShotCharacteristics shotChar, int hp)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _speed = speed;
            _texture = texture;
            _attackSpeed = attackSpeed;
            _canShoot = true;
            _isDead = false;
            _shotChar = shotChar;
            _hp = hp;
        }

        #endregion

        #region Properties

        public float X
        {
            get { return _x; }
        }

        public float Y
        {
            get { return _y; }
        }

        public float Width
        {
            get { return _width; }
        }

        public float Height
        {
            get { return _height; }
        }

        public RectangleF Form
        {
            get { return new RectangleF(_x, _y, _width, -_height); }
        }

        public float Speed
        {
            get { return _speed; }
        }

        public int Texture
        {
            get { return _texture; }
        }

        public int Hp
        {
            get { return _hp; }
        }

        public bool IsDead
        {
            get { return _isDead; }
            set { _isDead = value; }
        }

        public ShotCharacteristics ShotChar
        {
            get { return _shotChar; }
        }

        #endregion

        #region Methods

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            _canShoot = true;
        }

        public virtual bool CanMove(Vector2 direction, Room room)
        {
            return true;
        }

        public void Move(Vector2 direction)
        {
            direction.Normalize();
            _x += _speed * direction.X;
            _y += _speed * direction.Y;
        }

        public void Shoot(Room room, Shot shot)
        {
            if (_canShoot)
            {
                room.Shots.Add(shot);
                _canShoot = false;
                var timer = new Timer(_attackSpeed);
                timer.AutoReset = false;
                timer.Elapsed += OnTimedEvent;
                timer.Start();
            }
            
        }

        public void TakeDamage(int damage)
        {
            _hp -= damage;
        }



        #endregion
    }
}
