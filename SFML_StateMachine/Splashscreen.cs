﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML_StateMachine;

namespace StateMachine
{
    class Splashscreen : Scene
    {
        private Texture Splashtexture;
        private Sprite Splashsprite;

      //  Clock clock;
      //  Time time;
        Timer Timer;
        public Splashscreen(GameObject gameObject) : base(gameObject)
        {
            BackgroundColor = Color.Cyan;
        }

        public override void Initialize()
        {
            Splashtexture = new Texture("Splashscreen.png");
            Splashsprite = new Sprite(Splashtexture);

            Splashsprite.Position = new Vector2f();
            Splashsprite.Scale = new Vector2f(1.1f, 1.4f);

            Timer = new Timer();

            base.Initialize();
        }

        public override void Update()
        {
            Timer.Update();
            
            if (Timer.Current >= 3)
            {
                _gameObject.SceneManager.StartScene("main");
            }


            _gameObject.Window.Draw(Splashsprite);
            
        }

    }
}
