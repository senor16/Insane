using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TexturePackerLoader;

namespace BCEngine
{
    public class Anim
    {
        public string name { get; set; }
        public List<SpriteFrame> frames { get; set; }
        public int currentFrame { get; set; }
        public int frameCounter { get; set; }
        public int frameSpeed { get; set; }
        public bool canLoop { get; set; }
        public bool hasEnded { get; set; }

        public Anim(string pName, int pFrameSpeed, bool pCanLoop)
        {
            name = pName;
            frameSpeed = pFrameSpeed;
            canLoop = pCanLoop;
            hasEnded = false;
            frames = new List<SpriteFrame>();
            currentFrame = 0;
            frameCounter = 0;
        }

        public void addFrame(SpriteFrame pFrame)
        {
            frames.Add(pFrame);
        }

        public void Update()
        {
            if (!hasEnded)
            {
                frameCounter++;
                if (frameCounter >= 60 / frameSpeed)
                {
                    currentFrame++;
                    frameCounter = 0;

                    if (currentFrame > frames.Count - 1)
                    {
                        if (canLoop)
                        {
                            currentFrame = 0;
                            hasEnded = false;
                        }
                        else
                        {
                            hasEnded = true;
                            currentFrame = frames.Count - 1;
                        }
                    }
                }
            }
        }

        public void reset(){
            currentFrame=0;
            frameCounter=0;
            hasEnded=false;
        }        
    }
}