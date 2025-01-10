using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Pong;

class Globals
{
    public static SpriteBatch spriteBatch;
    public static int WIDTH = 640, HEIGHT = 480;
    public static Texture2D pixel;
    public static int playerOneScore, playerTwoScore;
    public static Random random = new Random();
}
