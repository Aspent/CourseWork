﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Test1
{
    class Obstacle
    {
        #region Fields

        RectangleF _form;
        int _texture;
       
        #endregion

        #region Constructors

        public Obstacle(RectangleF form, int texture)
        {
            _form = form;
            _texture = texture;
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

        #endregion
    }
}
