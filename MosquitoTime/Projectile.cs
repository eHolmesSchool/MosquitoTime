﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MosquitoTime
{
    public class Projectile : GameObject
    {

        float _velocityX;
        float _velocityY;
        float bounds;

        //projectileUpgradeState upgradeState;
        public ProjectileState currentProjectileState = ProjectileState.Dead; //Defaults to Inactive


        public Projectile(Sprite sprite, Transform transform, float velocityX, float velocityY) : base(sprite, transform)// Ask Angelo how Controls work
        {
            _transform = transform;
            _sprite = sprite;
            _velocityX = velocityX;
            _velocityY = velocityY;

        }

        public new void Update(GameTime gameTime)
        {
            base.Update(gameTime); ///////////

            switch (currentProjectileState)
            {
                case ProjectileState.Alive:
                    ProjectileMove();
                    break;
                case ProjectileState.Dead:
                    //Make It NOT Draw while dead and DO draw while alive  DONE
                    break;
                default:
                    break;
            }
        }


        public void Initialize()                                     //Initialize the projectiles in GameState.Init
        {
            currentProjectileState = ProjectileState.Dead;
            _transform.Position = Vector2.Zero;
        }

        public void Activate(Vector2 Position)
        {
            _transform.Position = Position;
            currentProjectileState = ProjectileState.Alive;
        }

        public void ProjectileMove()
        {
            _transform.TranslatePosition(new Vector2(_velocityX, _velocityY));
        }


        public enum ProjectileState
        {
            None,
            Alive,
            Dead,
        }
    }
}