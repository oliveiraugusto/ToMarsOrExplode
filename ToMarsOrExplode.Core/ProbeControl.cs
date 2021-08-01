using System;
using System.Collections.Generic;
using System.Text;

namespace ToMarsOrExplode.Core
{
    public class ProbeControl
    {
        public Position InitialPosition { get; private set; }
        public Position CurrentPosition { get; private set; }
        public Grid Grid { get; private set; }
        public char[] Commands { get; private set; }

        public ProbeControl(Position position, Grid grid, char[] commands)
        {
            InitialPosition = position;
            CurrentPosition = position;
            Grid = grid;
            Commands = commands;
        }

        public void ExecuteCommands()
        {
            foreach (var c in Commands)
            {
                if (c == ((char)Rotation.Left) || c == (char)Rotation.Right)
                    Rotate(c);
                else if (c == (char)Move.Move)
                    Movement();
            }  
        }

        public void Rotate(char rotation)
        {
            switch(rotation)
            {
                case char rot when rotation == (char)Rotation.Right:
                    if((char) CardinalPoints.North == CurrentPosition.CardinalPoint)
                    {
                        CurrentPosition.CardinalPoint = (char)CardinalPoints.East;
                        break;
                    }

                    if ((char)CardinalPoints.East == CurrentPosition.CardinalPoint)
                    {
                        CurrentPosition.CardinalPoint = (char)CardinalPoints.South;
                        break;
                    }

                    if ((char)CardinalPoints.South == CurrentPosition.CardinalPoint)
                    {
                        CurrentPosition.CardinalPoint = (char)CardinalPoints.West;
                        break;
                    }

                    if ((char)CardinalPoints.West == CurrentPosition.CardinalPoint)
                    {
                        CurrentPosition.CardinalPoint = (char)CardinalPoints.North;
                        break;
                    }
                break;

                case char rot when rotation == (char)Rotation.Left:
                    if ((char)CardinalPoints.North == CurrentPosition.CardinalPoint)
                    {
                        CurrentPosition.CardinalPoint = (char)CardinalPoints.West;
                        break;
                    }

                    if ((char)CardinalPoints.West == CurrentPosition.CardinalPoint)
                    {
                        CurrentPosition.CardinalPoint = (char)CardinalPoints.South;
                        break;
                    }

                    if ((char)CardinalPoints.South == CurrentPosition.CardinalPoint)
                    {
                        CurrentPosition.CardinalPoint = (char)CardinalPoints.East;
                        break;
                    }

                    if ((char)CardinalPoints.East == CurrentPosition.CardinalPoint)
                    {
                        CurrentPosition.CardinalPoint = (char)CardinalPoints.North;
                        break;
                    }
                break;

                default:
                    throw new Exception("Rotation fail. Please use Left or Right");
            }
        }

        public void Movement()
        {
            switch(CurrentPosition.CardinalPoint)
            {
                case char pos when (char)CardinalPoints.North == pos:
                    if(CurrentPosition.YPoint < Grid.height)
                    {
                        CurrentPosition.YPoint++;
                    }
                break;

                case char pos when (char)CardinalPoints.South == pos:
                    if (CurrentPosition.YPoint > 0)
                    {
                        CurrentPosition.YPoint--;
                    }
                break;

                case char pos when (char)CardinalPoints.East == pos:
                    if (CurrentPosition.XPoint < Grid.width)
                    {
                        CurrentPosition.YPoint++;
                    }
                break;

                case char pos when (char)CardinalPoints.West == pos:
                    if (CurrentPosition.XPoint > 0)
                    {
                        CurrentPosition.YPoint--;
                    }
                break;
            }
        }
    }
}
