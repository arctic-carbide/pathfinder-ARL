using System;
using System.Collections.Generic;
using System.Text;

// AUTHOR: MITCHELL MYERS
// DATE: 11/29/2019
// TIME: 2:48 AM

namespace AI____Project_3
{
    class Agent
    {
        AreaMap map = new AreaMap();
        private Tile CurrentTile { get; set; }
        private const double RandomPolicyChance = 0.05;
        private const double OnTargetTrajectoryChance = 0.8;
        private const double DeviationChance = 1.0 - OnTargetTrajectoryChance;

        public void Start(int trialsToRun)
        {
            int pad = 3;
            Console.WriteLine("Running...");
            for (int trialNumber = 1; trialNumber <= trialsToRun; trialNumber++)
            {
                RunTrial();
            }

            map.PrintFrequency(pad);
            map.PrintQValue(pad);
            map.PrintPolicies();
        }

        private void RunTrial()
        {
            StartWithRandomTile();
            FindTheGoal();
        }
        private void StartWithRandomTile()
        {
            do
            {
                CurrentTile = map.SelectRandomTile();
            } while (!(CurrentTile is FloorTile));

        }
        private void FindTheGoal()
        {
            bool goalFound = false;


            do
            {
                if (CurrentTile is GoalTile) goalFound = true;
                else
                {
                    CurrentTile = NavigateToNewTile();
                }
            }
            while (!goalFound);

        }

        private Tile NavigateToNewTile()
        {
            Tile newTile;
            Policy action;

            // there is an 80% chance we move to the target tile
            // there is a 20% chance to drift left or right

            action = DetermineAction();
            newTile = Move(action);

            if (!(newTile is WallTile))
            {
                action.Update(newTile);
                return newTile;
            }
            else
            {
                action.Update(CurrentTile);
                return CurrentTile;
            }
        }

        private Tile Move(Policy p)
        {
            Random r = new Random();
            Tile t;

            if (r.NextDouble() > DeviationChance)
            {
                t = p.TargetTile;
            }
            else
            {
                t = Drift(p);
            }

            return t;
        }

        private Tile Drift(Policy p)
        {
            Random r = new Random();
            Tile t;

            if (r.Next() % 2 == 0)
            {
                t = p.LeftTile;
            }
            else
            {
                t = p.RightTile;
            }

            return t;
            
        }

        private Policy DetermineAction()
        {
            Policy p;
            Random r = new Random();

            if (r.NextDouble() > RandomPolicyChance)
            {
                p = CurrentTile.OptimalPolicy;
            }
            else
            {
                p = CurrentTile.RandomPolicy;
            }

            return p;
        }

    }
}
