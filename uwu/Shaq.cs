﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uwu
{
    public class Shaq : Animation
    {
        public Dictionary<ShaqEnums.actuallyshaq, List<Frame>> animation2;
        ShaqEnums.actuallyshaq actuallyshaqStates;
        public ShaqEnums.actuallyshaq currentframestate2
        {
            get
            {
                return actuallyshaqStates;
            }
            set
            {
                if (actuallyshaqStates != value)
                {
                    actuallyshaqStates = value;
                    currentframeIndex = 0;
                }
            }
        }
        //public Rectangle gcfr()
        //{
        //    return frames[currentframeIndex]
        //}


        public bool cJump = false;
        public bool cBlock = false;
        public bool cCrouch = false;
        public bool cCrouchBlock = false;
        public bool cCrouchPunch = false;
        public bool cPunch = false;
        public bool cKick = false;
        public bool cJumpKick = false;
        public bool cCrouchKick = false;
        public int health = 480;

        private Vector2 BottomLeft(int width, int height)
        {
            return new Vector2(0, height);
        }

        public Shaq(Texture2D image, Vector2 position, Color color, List<Frame> frames)
            : base(image, position, color, frames)
        {
            List<Frame> idleA = new List<Frame>()
            {
                //new Frame(new Rectangle(1, 2, 23, 45),   BottomLeft(23, 45)),
                //new Frame(new Rectangle(29, 1, 23, 46),  BottomLeft(23, 46)),
                //new Frame(new Rectangle(57, 1, 24, 46),  BottomLeft(24, 46)),
                new Frame(new Rectangle(86, 1, 24, 46),  BottomLeft(24, 46)),
                //new Frame(new Rectangle(115, 2, 24, 45), BottomLeft(24, 45)),
                //new Frame(new Rectangle(144, 1, 24, 46), BottomLeft(24, 46)),
                //new Frame(new Rectangle(173, 1, 24, 46), BottomLeft(24, 46)),
                //new Frame(new Rectangle(202, 1, 23, 47), BottomLeft(23, 47)),
            };
            animation2 = new Dictionary<ShaqEnums.actuallyshaq, List<Frame>>();
            animation2.Add(ShaqEnums.actuallyshaq.aIdle, idleA);

            List<Frame> jumpA = new List<Frame>()
            {
                new Frame(new Rectangle(1, 256, 25, 45),   BottomLeft(25, 45)),
                new Frame(new Rectangle(31, 253, 24, 47),  BottomLeft(24, 47)),
                new Frame(new Rectangle(60, 253, 24, 41),  BottomLeft(24, 41)),
                new Frame(new Rectangle(89, 253, 26, 35),  BottomLeft(26, 35)),
                new Frame(new Rectangle(120, 253, 17, 43), BottomLeft(17, 43)),
                new Frame(new Rectangle(142, 253, 21, 47), BottomLeft(21, 47)),
                new Frame(new Rectangle(168, 264, 25, 37), BottomLeft(25, 37)),
            };
            animation2.Add(ShaqEnums.actuallyshaq.aJump, jumpA);
            //omae wa mou shindeiru
            List<Frame> blockA = new List<Frame>()
            {
                new Frame(new Rectangle(1, 1066, 17, 45),  BottomLeft(17, 45)),
                new Frame(new Rectangle(23, 1068, 17, 43), BottomLeft(17, 43)),
                new Frame(new Rectangle(45, 1066, 17, 45), BottomLeft(17, 45)),
                new Frame(new Rectangle(45, 1066, 17, 45), BottomLeft(17, 45)),
                new Frame(new Rectangle(45, 1066, 17, 45), BottomLeft(17, 45)),
                new Frame(new Rectangle(45, 1066, 17, 45), BottomLeft(17, 45)),
                new Frame(new Rectangle(45, 1066, 17, 45), BottomLeft(17, 45)),
                new Frame(new Rectangle(45, 1066, 17, 45), BottomLeft(17, 45)),
                new Frame(new Rectangle(45, 1066, 17, 45), BottomLeft(17, 45)),
                new Frame(new Rectangle(45, 1066, 17, 45), BottomLeft(17, 45)),
                new Frame(new Rectangle(45, 1066, 17, 45), BottomLeft(17, 45)),
            };
            animation2.Add(ShaqEnums.actuallyshaq.aBlock, blockA);
            //omae wa mou shindeiru
            List<Frame> crouchA = new List<Frame>()
            {
                new Frame(new Rectangle(1, 206, 22, 42),  BottomLeft(22, 42)),
                new Frame(new Rectangle(28, 206, 22, 42), BottomLeft(22, 42)),
                new Frame(new Rectangle(55, 206, 23, 42), BottomLeft(23, 42)),
                new Frame(new Rectangle(55, 206, 23, 42), BottomLeft(23, 42)),
                new Frame(new Rectangle(55, 206, 23, 42), BottomLeft(23, 42)),
                new Frame(new Rectangle(55, 206, 23, 42), BottomLeft(23, 42)),
                new Frame(new Rectangle(55, 206, 23, 42), BottomLeft(23, 42)),
                new Frame(new Rectangle(55, 206, 23, 42), BottomLeft(23, 42)),
                new Frame(new Rectangle(55, 206, 23, 42), BottomLeft(23, 42)),
            };
            animation2.Add(ShaqEnums.actuallyshaq.aCrouch, crouchA);
            
            List<Frame> crouchblockA = new List<Frame>()
            {
                new Frame(new Rectangle(104, 1094, 22, 44), BottomLeft(22, 44)),
            };
            animation2.Add(ShaqEnums.actuallyshaq.aCrouchBlock, crouchblockA);
           
            List<Frame> crouchpunchA = new List<Frame>()
            {
                new Frame(new Rectangle(1, 440, 30, 44),  BottomLeft(30, 44)),
                new Frame(new Rectangle(36, 440, 39, 44), BottomLeft(39, 44)),
                new Frame(new Rectangle(80, 440, 30, 44), BottomLeft(30, 44)),
            };
            animation2.Add(ShaqEnums.actuallyshaq.aCrouchPunch, crouchpunchA);
            
            List<Frame> punchA = new List<Frame>()
            {
                  new Frame(new Rectangle(1, 358, 24, 46), BottomLeft(24, 46)),
                 new Frame(new Rectangle(30, 358, 36, 45), BottomLeft(36, 45)),
                 new Frame(new Rectangle(71, 359, 27, 45), BottomLeft(27, 45)),
                new Frame(new Rectangle(103, 359, 24, 45), BottomLeft(24, 45)),
            };
            animation2.Add(ShaqEnums.actuallyshaq.aPunch, punchA);
            
            List<Frame> kickA = new List<Frame>()
            {
                  new Frame(new Rectangle(1, 555, 24, 45), BottomLeft(24, 45)),
                 new Frame(new Rectangle(30, 552, 40, 48), BottomLeft(40, 48)),
                 new Frame(new Rectangle(75, 557, 28, 43), BottomLeft(28, 43)),
                new Frame(new Rectangle(108, 554, 27, 46), BottomLeft(27, 46)),
            };
            animation2.Add(ShaqEnums.actuallyshaq.aKick, kickA);
            
            List<Frame> jumpkickA = new List<Frame>()
            {
                new Frame(new Rectangle(1, 722, 35, 31), BottomLeft(35, 31)),
            };
            animation2.Add(ShaqEnums.actuallyshaq.aJumpKick, jumpkickA);
            
            List<Frame> crouchkickA = new List<Frame>()
            {
                new Frame(new Rectangle(43,  657, 43, 24), BottomLeft(43, 24)),
            };
            animation2.Add(ShaqEnums.actuallyshaq.aCrouchKick, crouchkickA);
        }

        public void Update(GameTime gTime, KeyboardState ks)
        {
            frames = animation2[currentframestate2];

            if (cJump == true)
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aJump;
            }
            if (cBlock == true)
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aBlock;
            }
            if (cCrouch == true)
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aCrouch;
            }
            if (cCrouchBlock == true)
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aCrouchBlock;
            }
            if (cCrouchKick == true)
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aCrouchKick;
            }
            if (cCrouchPunch == true)
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aCrouchPunch;
            }
            if (cKick == true)
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aKick;
            }

            if (cPunch == true)
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aPunch;
            }

            if (cJumpKick == true)
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aJumpKick;
            }
          

         
            if (currentframestate2 == ShaqEnums.actuallyshaq.aBlock)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = ShaqEnums.actuallyshaq.aIdle;
                }
            }
  
            if (ks.IsKeyDown(Keys.S))
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aBlock;
                cBlock = true;
                cCrouch = false;
                cCrouchBlock = false;
                cCrouchKick = false;
                cCrouchPunch = false;
                cJump = false;
                cKick = false;
                cPunch = false;
                cJumpKick = false;

            }

            if (currentframestate2 == ShaqEnums.actuallyshaq.aCrouch)
            {
                if (currentframeIndex + 1 >= frames.Count)
            //anachronistic capitalism
                {
                    currentframestate2 = ShaqEnums.actuallyshaq.aIdle;
                }
            }
            if (ks.IsKeyDown(Keys.C))
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aCrouch;
                cBlock = false;
                cCrouch = true;
                cCrouchBlock = false;
                cCrouchKick = false;
                cCrouchPunch = false;
                cJump = false;
                cKick = false;
                cPunch = false;
                cJumpKick = false;
            }
            //anachronistic capitalism
            if (currentframestate2 == ShaqEnums.actuallyshaq.aCrouchBlock)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = ShaqEnums.actuallyshaq.aIdle;
                }
            }
            if (ks.IsKeyDown(Keys.V))
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aCrouchBlock;
                cBlock = false;
                cCrouch = false;
                cCrouchBlock = true;
                cCrouchKick = false;
                cCrouchPunch = false;
                cJump = false;
                cKick = false;
                cPunch = false;
                cJumpKick = false;
            }
            //anachronistic capitalism
            if (currentframestate2 == ShaqEnums.actuallyshaq.aCrouchKick)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = ShaqEnums.actuallyshaq.aIdle;
                }
            }
            if (ks.IsKeyDown(Keys.B))
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aCrouchKick;
                cBlock = false;
                cCrouch = false;
                cCrouchBlock = false;
                cCrouchKick = true;
                cCrouchPunch = false;
                cJump = false;
                cKick = false;
                cPunch = false;
                cJumpKick = false;
                //bCrouchKick = true;
            }
            //anachronistic capitalism
            if (currentframestate2 == ShaqEnums.actuallyshaq.aCrouchPunch)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = ShaqEnums.actuallyshaq.aIdle;
                }
            }
            if (ks.IsKeyDown(Keys.X))
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aCrouchPunch;
                cBlock = false;
                cCrouch = false;
                cCrouchBlock = false;
                cCrouchKick = false;
                cCrouchPunch = true;
                cJump = false;
                cKick = false;
                cPunch = false;
                cJumpKick = false;
            }
            //anachronistic capitalism
            if (currentframestate2 == ShaqEnums.actuallyshaq.aPunch)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = ShaqEnums.actuallyshaq.aIdle;
                }
            }
            if (ks.IsKeyDown(Keys.D))
            {               
                currentframestate2 = ShaqEnums.actuallyshaq.aPunch;
                cBlock = false;
                cCrouch = false;
                cCrouchBlock = false;
                cCrouchKick = false;
                cCrouchPunch = false;
                cJump = false;
                cKick = false;
                cPunch = true;
                cJumpKick = false;
                //bPunch = true;
            }
            //anachronistic capitalism
            if (currentframestate2 == ShaqEnums.actuallyshaq.aKick)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = ShaqEnums.actuallyshaq.aIdle;
                }
            }
            if (ks.IsKeyDown(Keys.A))
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aKick;
                cBlock = false;
                cCrouch = false;
                cCrouchBlock = false;
                cCrouchKick = false;
                cCrouchPunch = false;
                cJump = false;
                cKick = true;
                cPunch = false;
                cJumpKick = false;
            }
            //anachronistic capitalism
            if (currentframestate2 == ShaqEnums.actuallyshaq.aJump)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = ShaqEnums.actuallyshaq.aIdle;
                }
            }
            if (ks.IsKeyDown(Keys.W))
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aJump;
                cBlock = false;
                cCrouch = false;
                cCrouchBlock = false;
                cCrouchKick = false;
                cCrouchPunch = false;
                cJump = true;
                cKick = false;
                cPunch = false;
                cJumpKick = false;
            }
            //anachronistic capitalism
            if (currentframestate2 == ShaqEnums.actuallyshaq.aJumpKick)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = ShaqEnums.actuallyshaq.aIdle;
                }
            }
            if (ks.IsKeyDown(Keys.E))
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aJumpKick;
                cBlock = false;
                cCrouch = false;
                cCrouchBlock = false;
                cCrouchKick = false;
                cCrouchPunch = false;
                cJump = false;
                cKick = false;
                cPunch = false;
                cJumpKick = true;
            }

            base.Update(gTime);
        }
    }
}
