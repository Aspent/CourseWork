using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Test1
{
    class RoomSupervisor
    {
        #region Fields

        Game _game;

        #endregion

        #region Constructors

        public RoomSupervisor(Game game)
        {
            _game = game;
            OnShotBorderCollision += ShotBorderHandle;
            OnShotPlayerCollision += ShotPlayerHandle;
            OnShotEnemyCollision += ShotEnemyHandle;
            OnPlayerFinishZoneCollision += PlayerFinishZoneHandle;
        }

        #endregion

        #region Events

        public event ShotBorderHandler OnShotBorderCollision;

        public event ShotPlayerHandler OnShotPlayerCollision;

        public event ShotEnemyHandler OnShotEnemyCollision;

        public event PlayerFinishZoneHandler OnPlayerFinishZoneCollision;



        #endregion

        #region Handle Methods

        private void ShotBorderHandle(Shot shot, Room room)
        {
            shot.IsRemoved = true;
        }

        private void ShotPlayerHandle(Shot shot, Player player)
        {
            player.TakeDamage(shot.Damage);
            shot.IsRemoved = true;
        }

        private void ShotEnemyHandle(Shot shot, Enemy enemy)
        {
            enemy.TakeDamage(shot.Damage);
            shot.IsRemoved = true;
        }

        private void PlayerFinishZoneHandle(Player player, FinishZone finishZone)
        {
            if (_game.Mode == "SuperHero")
            {
                Console.WriteLine("You won! Your code phrase is 'Dog, dog never changes'");
            }
            else
            {
                Console.WriteLine("You won! But it was too easy");
            }
            _game.Exit();
        }

        #endregion

        #region Delegates

        public delegate void ShotBorderHandler(Shot shot, Room room);

        public delegate void ShotPlayerHandler(Shot shot, Player player);

        public delegate void ShotEnemyHandler(Shot shot, Enemy enemy);

        public delegate void PlayerFinishZoneHandler(Player player, FinishZone finishZone);

        #endregion

        #region Methods

        private static bool ShotIsRemoved(Shot shot)
        {
            return (shot.Range <= 0 || shot.IsRemoved);
        }

        private static bool EnemyIsDead(Enemy enemy)
        {
            return (enemy.Hp <= 0);
        }

        public void Run(Player player, Room room)
        {
            foreach (var t in room.Enemies)
            {
                var distance = new Vector2(player.X - t.X, player.Y - t.Y).Length;
                var direction = new Vector2(player.X - t.X, player.Y - t.Y);
                if (distance > 0.8f*t.ShotChar.Range)
                {
                    t.Move(direction);
                }
                else
                {
                    t.Shoot(room, new Shot(t.Form.Left, t.Form.Top, direction, t));
                }
            }
            
            foreach (var t in room.Shots)
            {
                t.Move();
            }
            room.Shots.RemoveAll(ShotIsRemoved);

            var collisionChecker = new CollisionChecker();
            foreach (var t in room.Shots)
            {
                if (collisionChecker.IsCollided(t, room))
                {
                    OnShotBorderCollision(t, room);
                }
                if (collisionChecker.IsCollided(t, player))
                {
                    if (t.Owner.GetType() != player.GetType())
                    {
                        OnShotPlayerCollision(t, player);
                    }
                }
                foreach(var item in room.Enemies)
                {
                    if (collisionChecker.IsCollided(t, item))
                    {
                        if (t.Owner != item)
                        {
                            OnShotEnemyCollision(t, item);
                        }
                    }
                }
            }

            if (collisionChecker.IsCollided(player, room.FinishZone) && room.FinishZone.IsActive)
            {
                OnPlayerFinishZoneCollision(player, room.FinishZone);
            }

            room.Shots.RemoveAll(ShotIsRemoved);
            room.Enemies.RemoveAll(EnemyIsDead);

        }

        #endregion
    }
}
