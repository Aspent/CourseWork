using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;

namespace Test1
{
    class Game : GameWindow
    {
        #region Fields

        int[] _textures = new int[10];
        Room firstRoom = new Room(new RectangleF(-0.85f, 0.5f, 1.7f, -1.4f), 3);
        RoomDrawer roomDrawer;
        Player player;
        PlayerDrawer playerDrawer;
        RoomSupervisor roomSupervisor;
        string _mode;

        #endregion

        #region Constructors

        public Game(int width, int height, string mode) : base(width, height)
        {
            _mode = mode;
            roomSupervisor = new RoomSupervisor(this);
            if(mode == "SuperHero")
            {                
                player = new Player(-0.4f, 0.0f, 0.1f, 0.2f, 0.3f/60, 1200, 2,
                     new ShotCharacteristics(0.1f, 0.1f, 1, 0.3f/60, 0.5f, 6), 5);


                firstRoom.Enemies.Add(new Enemy(firstRoom.Form.Left + 0.5f,
                    firstRoom.Form.Bottom + 0.5f, 630.0f / 1000, 371.0f / 1000, 0.2f / 60, 900, 4,
                    new ShotCharacteristics(0.1f, 0.1f, 2, 0.25f / 60, 0.9f, 5), 25));

                return;
            }
            if (mode == "SuperCancer")
            {
                player = new Player(-0.4f, 0.0f, 600.0f / 2500, 426.0f / 2500, 0.3f / 60, 1200, 7,
                     new ShotCharacteristics(0.1f, 0.1f, 1, 0.3f / 60, 0.5f, 6), 7);


                firstRoom.Enemies.Add(new Enemy(firstRoom.Form.Left + 0.5f,
                    firstRoom.Form.Bottom + 0.5f, 630.0f / 2000, 371.0f / 2000, 0.2f / 60, 1200, 4,
                    new ShotCharacteristics(0.08f, 0.08f, 1, 0.2f / 60, 0.5f, 5), 10));

                return;
            }

        }

        #endregion

        #region Methods

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.Enable(EnableCap.Texture2D);
            _textures[0] = new TextureLoader().LoadTexture("wood.jpg");
            _textures[1] = new TextureLoader().LoadTexture("water.jpeg");
            _textures[2] = new TextureLoader().LoadTexture("persKover1.png");
            _textures[3] = new TextureLoader().LoadTexture("grass.jpg");
            _textures[4] = new TextureLoader().LoadTexture("dog1.png");
            _textures[5] = new TextureLoader().LoadTexture("fireball2.png");
            _textures[6] = new TextureLoader().LoadTexture("dust1.png");
            _textures[7] = new TextureLoader().LoadTexture("Cancer1.png");
            _textures[8] = new TextureLoader().LoadTexture("portal1.png");
            roomDrawer = new RoomDrawer(_textures);
            playerDrawer = new PlayerDrawer(_textures);
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            base.OnKeyDown(e);
            var state = OpenTK.Input.Keyboard.GetState();
            
            if (state[Key.Escape])
            {
                Exit();
            }

        }



        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            var nRange = 1.0f;
            int w = this.Width;
            int h = this.Height;
            GL.Viewport(0, 0, w, h);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            if (w <= h)
            {
                GL.Ortho(-nRange, nRange, -nRange * h / w, nRange * h / w, -nRange, nRange);
            }
            else
            {
                GL.Ortho(-nRange * w / h, nRange * w / h, -nRange, nRange, -nRange, nRange);
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            roomDrawer.Draw(firstRoom);

            GL.PushMatrix();
            playerDrawer.Draw(player);
            GL.PopMatrix();

            roomSupervisor.Run(player, firstRoom);

            player.Controller.Control(player, firstRoom);

            if(player.Hp <= 0)
            {
                Console.WriteLine("Dog killed ypu =(");
                Exit();
            }

            var collisionChecker = new CollisionChecker();
            if(firstRoom.Enemies.Count == 0 && !collisionChecker.IsCollided(player, firstRoom.FinishZone))
            {
                firstRoom.FinishZone.IsActive = true;
            }

            SwapBuffers();           
        }

        #endregion

        public string Mode
        {
            get { return _mode; }
        }
    }
}
