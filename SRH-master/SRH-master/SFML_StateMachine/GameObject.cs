﻿using SFML.Graphics;
using SFML.Window;
using System;

namespace GameEngine
{
    public class GameObject : IDisposable
    {
        private RenderWindow _window;

        public RenderWindow Window { get { return this._window; } }

        public SceneManager SceneManager = new SceneManager();

        uint Xres = 800;

        uint Yres = 600; //change whatever u want lads

        public GameObject(string Title)
        {
            // initialize values
            _window = new RenderWindow(new VideoMode(Xres, Yres), Title, Styles.Default);

            _window.SetVisible(true);
            _window.SetVerticalSyncEnabled(true);
            _window.SetFramerateLimit(60);

            //  event handlers
            _window.Closed += _window_Closed;
            _window.KeyPressed += _window_KeyPressed;
            _window.KeyReleased += _window_KeyReleased;
        }

        private void _window_KeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            SceneManager.CurrentScene.HandleKeyPress(e);
        }

        private void _window_KeyReleased(object sender, SFML.Window.KeyEventArgs e)
        {
            SceneManager.CurrentScene.HandleKeyReleased(e);
        }

        private void _window_Closed(object sender, EventArgs e)
        {
            _window.Close();
        }

        public void Close()
        {
            this._window.Close();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _window.Dispose();
            }
        }
    }
}