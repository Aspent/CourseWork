using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class ShotCharacteristics
    {
        #region Fields

        float _width;
        float _height;
        int _damage;
        float _speed;
        float _range;
        int _texture;

        #endregion

        #region Constructors

        public ShotCharacteristics(float width, float height, int damage, float speed, 
            float range, int texture)
        {
            _width = width;
            _height = height;
            _damage = damage;
            _speed = speed;
            _range = range;
            _texture = texture;
        }

        #endregion

        #region Properties

        public float Width
        {
            get { return _width; }
        }

        public float Height
        {
            get { return _height; }
        }

        public int Damage
        {
            get { return _damage; }
        }

        public float Speed
        {
            get { return _speed; }
        }

        public float Range
        {
            get { return _range; }
            set { _range = value; }
        }

        public int Texture
        {
            get { return _texture; }
        }

        #endregion
    }
}
