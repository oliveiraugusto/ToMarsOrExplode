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
        public string Commands { get; private set; }

        public ProbeControl(Position position, Grid grid, string commands)
        {
            InitialPosition = position;
            CurrentPosition = position;
            Grid = grid;
            Commands = commands;
        }

        public void ExecuteCommands()
        {
            if (Commands == Rotation.Left.ToString() || Commands == Rotation.Right.ToString())
                Rotate(Commands);
            else if (Commands == (string)Move.Move.ToString())
                Movement();
        }

        public void Rotate(string rotation)
        {
            switch(rotation)
            {
                case string rot when rotation == Rotation.Right.ToString():
                    if(CardinalPoints.North.ToString() == CurrentPosition.CardinalPoint)
                    {
                        CurrentPosition.CardinalPoint = CardinalPoints.East.ToString();
                        break;
                    }

                    if (CardinalPoints.East.ToString() == CurrentPosition.CardinalPoint)
                    {
                        CurrentPosition.CardinalPoint = CardinalPoints.South.ToString();
                        break;
                    }

                    if (CardinalPoints.South.ToString() == CurrentPosition.CardinalPoint)
                    {
                        CurrentPosition.CardinalPoint = CardinalPoints.West.ToString();
                        break;
                    }

                    if (CardinalPoints.West.ToString() == CurrentPosition.CardinalPoint)
                    {
                        CurrentPosition.CardinalPoint = CardinalPoints.North.ToString();
                        break;
                    }
                break;

                case string rot when rotation == Rotation.Left.ToString():
                    if (CardinalPoints.North.ToString() == CurrentPosition.CardinalPoint)
                    {
                        CurrentPosition.CardinalPoint = CardinalPoints.West.ToString();
                        break;
                    }

                    if (CardinalPoints.West.ToString() == CurrentPosition.CardinalPoint)
                    {
                        CurrentPosition.CardinalPoint = CardinalPoints.South.ToString();
                        break;
                    }

                    if (CardinalPoints.South.ToString() == CurrentPosition.CardinalPoint)
                    {
                        CurrentPosition.CardinalPoint = CardinalPoints.East.ToString();
                        break;
                    }

                    if (CardinalPoints.East.ToString() == CurrentPosition.CardinalPoint)
                    {
                        CurrentPosition.CardinalPoint = CardinalPoints.North.ToString();
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
                case string pos when CardinalPoints.North.ToString() == pos:
                    if(CurrentPosition.YPoint < Grid.height)
                    {
                        CurrentPosition.YPoint++;
                    }
                break;

                case string pos when CardinalPoints.South.ToString() == pos:
                    if (CurrentPosition.YPoint > 0)
                    {
                        CurrentPosition.YPoint--;
                    }
                break;

                case string pos when CardinalPoints.East.ToString() == pos:
                    if (CurrentPosition.XPoint < Grid.width)
                    {
                        CurrentPosition.YPoint++;
                    }
                break;

                case string pos when CardinalPoints.West.ToString() == pos:
                    if (CurrentPosition.XPoint > 0)
                    {
                        CurrentPosition.YPoint--;
                    }
                break;
            }
        }
    }
}
